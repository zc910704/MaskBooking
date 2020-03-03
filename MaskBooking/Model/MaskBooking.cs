using MaskBookingTests.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    public class MaskBooking
    {
        public string RequestCaptchaImg()
        {
            string url = Config.baseUrl + "/mask/captcha";
            string UntouchedImgBase64 = WebHelper.GetMethod(url);
            return Utils.TouchCaptchaString(UntouchedImgBase64);
        }

        /// <summary>
        /// 获得库存
        /// </summary>
        /// <returns></returns>
        public string RequestMaskStock()
        {
            var EncodedUrl = UrlHandler.isvData(Config.baseUrl + "/mask/pharmacy-stock?code=" + UserInfo.pharmacyCode);
            var jsonResponse = WebHelper.GetMethod(EncodedUrl);
            return jsonResponse;
        }

        /// <summary>
        /// 提交预约信息
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public string PostPurchaseInfo(List<StockInfo> stocks)
        {
            var EncodedUrl = UrlHandler.isvData(Config.baseUrl + "/mask/book");
            var stock = GetAviliableStock(stocks);
            var response = WebHelper.PostMethod(stock, EncodedUrl);
            return response;

        }

        /// <summary>
        /// 调用脚本提交信息
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public void PostPurchaseINfoByScript(List<StockInfo> stocks)
        {
            var EncodedUrl = UrlHandler.isvData(Config.baseUrl + "/mask/book");
            var stock = GetAviliableStock(stocks);

            var timestamp = (Utils.GetMilliSecondsTime() - Config.timeDifference).ToString();
            string hash = Utils.hex_md5(timestamp + "c7c7405208624ed90976f0672c09b884");

            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
                {"name", UserInfo.name},
                {"cardNo", UserInfo.cardNo},
                {"phone", UserInfo.phone},
                {"reservationNumber", UserInfo.reservationNumber},
                {"pharmacyName", UserInfo.pharmacyName},
                {"pharmacyCode", UserInfo.pharmacyCode},
                {"hash", hash},
                {"pharmacyPhase", stock.value},
                {"pharmacyPhaseName", stock.text},
                {"captcha", UserInfo.captcha},
                {"timestamp", timestamp}
            };
            var requestJsonBody = JsonConvert.SerializeObject(dic);

            RunPythonScript("post.py", "-u",EncodedUrl,Config.cookie, requestJsonBody);

        }

        public static void RunPythonScript(string sArgName, string args = "-u", params string[] teps)
        {
            Process p = new Process();
            string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + sArgName;
            p.StartInfo.FileName = @"python.exe";
            string sArguments = path;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }

            sArguments += " " + args;

            p.StartInfo.Arguments = sArguments;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            p.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            p.Start();
            p.BeginOutputReadLine();
            Console.ReadLine();
            p.WaitForExit();
        }

        private static void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        /// <summary>
        /// 计算该天是否能抢到库存
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public bool GetMaskIsRemainHandler(List<StockInfo> stocks)
        {
            int count = 0;
            foreach (var info in stocks)
            {
                count += info.remain;
            }

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 将json转化为库存信息
        /// </summary>
        /// <param name="jsonResponseStr"></param>
        /// <returns></returns>
        public List<StockInfo> ConvertJsonToStock(string jsonResponseStr)
        {
            var touched = jsonResponseStr.Replace("\\", "").Replace("\"[", "[").Replace("]\"", "]");
            dynamic results = JsonConvert.DeserializeObject<dynamic>(touched);
            List<StockInfo> stocks = new List<StockInfo>();
            stocks.Add(
                new StockInfo()
                {
                    remain = Convert.ToInt32(results["msg"][0]["remain"]),
                    text =   results["msg"][0]["text"],
                    value =  results["msg"][0]["value"],
                });
            stocks.Add(
                new StockInfo()
                {
                    remain = Convert.ToInt32(results["msg"][1]["remain"]),
                    text =   results["msg"][1]["text"],
                    value =  results["msg"][1]["value"],
                });
            return stocks;
        }

        /// <summary>
        /// 获得可用库存
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public StockInfo GetAviliableStock(List<StockInfo> stocks)
        {
            foreach (StockInfo stockInfo in stocks)
            {
                if (stockInfo.remain > 0)
                    return stockInfo;
            }
            return stocks[0];
        }

    }
}
