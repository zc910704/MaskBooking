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
        public UserInfo UserInfo { set; get; }
        public OCRConfig OCRConfig { set; get; }

        public MaskBooking()
        {
            this.LoadConfig();
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        private void LoadConfig()
        {
            try
            {
                UserInfo = Utils.LoadUserInfoConfig();
            }
            catch{ }
            try
            {
                OCRConfig = Utils.LoadOCRConfig();
            }
            catch
            { }
        }

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
            var EncodedUrl = UrlHandler.isvData(Config.baseUrl + "/mask/pharmacy-stock?code=" + UserInfo.PharmacyCode);
            var jsonResponse = WebHelper.GetMethod(EncodedUrl);
            return jsonResponse;
        }

        /// <summary>
        /// 提交预约信息
        /// </summary>
        /// <param name="stocks"></param>
        /// <returns></returns>
        public string PostPurchaseInfo(List<StockInfo> stocks, string timestamp)
        {
            var EncodedUrl = UrlHandler.isvData(Config.baseUrl + "/mask/book");
            var stock = GetAviliableStock(stocks);
            var response = WebHelper.PostMethod(stock, EncodedUrl, timestamp, UserInfo);
            return response;

        }

        public string RequestIndexPage()
        {
            var url = Config.baseUrl + "/mask/book-view";
            var htmlResponse = WebHelper.GetMethod(url);
            return htmlResponse;
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
