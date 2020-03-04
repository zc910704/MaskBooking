using MaskBookingTests.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    public class WebHelper
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetMethod(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            WebHeaderCollection header = new WebHeaderCollection();
            // 去除gzip 不然请求回来的是乱码
            // "Accept-Encoding": "gzip, deflate",
            header.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9");
            header.Add("X-Requested-With", "XMLHttpRequest");
            if (string.IsNullOrEmpty(Config.cookie) == false)
            {
                header.Add("Cookie", Config.cookie);
            }
            httpWebRequest.Headers = header;
            httpWebRequest.Connection = "close";
            httpWebRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            httpWebRequest.KeepAlive = false;
            httpWebRequest.Host = "kzgm.bbshjz.cn:8000";
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
            httpWebRequest.Method = "GET";
            httpWebRequest.UserAgent = "Mozilla/5.0 (Linux; U; Android 2.3.6; zh-cn; GT-S5660 Build/GINGERBREAD) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1 MicroMessenger/4.5.255";
            var response = httpWebRequest.GetResponse();
            //处理cookie
            try
            {
                var cookie = response.Headers["set-cookie"].Split(';')[0];
                if (string.IsNullOrEmpty(cookie) == false)
                {
                    Config.cookie = cookie;
                }

            }
            catch
            { }

            var responseJsonStr = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                {
                    responseJsonStr = reader.ReadToEnd();
                }
            }
            httpWebRequest = null;
            GC.Collect();
            return responseJsonStr;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="EncodedUrl"></param>
        /// <returns></returns>
        public static string PostMethod(StockInfo stock, string EncodedUrl)
        {
            var requestJsonBody = string.Empty;
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
            requestJsonBody = JsonConvert.SerializeObject(dic);

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(EncodedUrl);
            WebHeaderCollection header = new WebHeaderCollection();
            // 去除gzip 不然请求回来的是乱码
            // "Accept-Encoding": "gzip, deflate",
            header.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9");
            header.Add("X-Requested-With", "XMLHttpRequest");
            if (string.IsNullOrEmpty(Config.cookie) == false)
            {
                header.Add("Cookie", Config.cookie);
            }
            httpWebRequest.Headers = header;
            httpWebRequest.Accept = "application/json, text/javascript, */*; q=0.01";
            httpWebRequest.KeepAlive = false;
            httpWebRequest.Connection = "close";
            httpWebRequest.Host = "kzgm.bbshjz.cn:8000";
            httpWebRequest.ContentType = "application/json;charset=UTF-8";
            httpWebRequest.Method = "POST";
            //httpWebRequest.SendChunked = true;
            httpWebRequest.ServicePoint.Expect100Continue = false;
            //这里会引发System.IO.IOException: 在写入所有字节之前不能关闭流。错误
            //原因：https://blog.csdn.net/zhouyingge1104/article/details/43883319?utm_source=blogxgwz0
            //httpWebRequest.ContentLength = requestJsonBody.Length;
            httpWebRequest.UserAgent = "Mozilla/5.0 (Linux; U; Android 2.3.6; zh-cn; GT-S5660 Build/GINGERBREAD) AppleWebKit/533.1 (KHTML, like Gecko) Version/4.0 Mobile Safari/533.1 MicroMessenger/4.5.255";

            if (!string.IsNullOrEmpty(requestJsonBody))
            {
                using (var postStream = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    postStream.Write(requestJsonBody);
                }
            }
            var responseJsonStr = string.Empty;
            var response = httpWebRequest.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding("UTF-8")))
                {
                    responseJsonStr = reader.ReadToEnd();
                }
            }
            return responseJsonStr;
        }
}
}
