using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    /// <summary>
    /// URL加密算法类
    /// </summary>
    public static class UrlHandler
    {
        /// <summary>
        /// 使用当前时间的时间戳加密请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string isvData(string url)
        {
            string sub_time = GetTimeStampInTenCount();
            url = MordifyByTimeStampMD5(url, sub_time);
            return url;
        }
        /// <summary>
        /// 利用时间戳与加密算法进行加密
        /// </summary>
        /// <param name="url"></param>
        /// <param name="sub_time">10位时间戳</param>
        /// <returns></returns>
        public static string MordifyByTimeStampMD5(string url, string sub_time)
        {
            // 密钥
            var app_key = "123";
            // 公共参数
            Dictionary<string, string> publicParm = new Dictionary<string, string> {
                {"app_id","app_weixin"},
                {"timestamp",sub_time},
                {"version","1"}
            };
            var parmStr = sortParm(publicParm);
            // 业务参数
            var urlParm = new Dictionary<string, string>();
            var urlParmArr = url.Split('?');
            var urlParmStr = "";

            if (urlParmArr.Length > 1)
            {
                urlParmStr = urlParmArr[1];
            }
            urlParmArr = urlParmStr.Split('&');
            for (var i = 0; i < urlParmArr.Length; i++)
            {
                var kv = urlParmArr[i].Split('=');
                var obj = new Dictionary<string, string>();
                if (kv.Length > 1)
                {
                    obj[kv[0]] = kv[1];
                    urlParm = assign(urlParm, obj);
                }
            }
            // 所有参数集合
            var init = assign(publicParm, urlParm);
            // 1、序列化参数
            var baseString = sortParm(init);
            // 2、使用密钥(app_key)对待签字符串baseString进行HmacMD5数字签名
            var sign = Utils.hex_hmac_md5(app_key, baseString);
            // 3、小写处理签名字符串
            sign = sign.ToLower();
            // 4、拼接新的url
            if (url.IndexOf("?") != -1)
            {
                url += "&" + parmStr + "&sign=" + sign;
            }
            else
            {
                url += "?" + parmStr + "&sign=" + sign;
            }
            return url;
        }
        /// <summary>
        /// 获取秒数的前十位
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampInTenCount()
        {
            // 截取前十位
            var sub_time = Utils.GetMilliSecondsTime().ToString().Substring(0, 10);
            return sub_time;
        }
        /// <summary>
        /// 字典排序参数
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        private static string sortParm(Dictionary<string, string> keyValuePairs)
        {
            // 声明一个空数组
            var array = new List<string>();
            foreach(KeyValuePair<string,string> pair in keyValuePairs)
            {
                // 取出对象里面的键  添加到数组中
                array.Add(pair.Key);
            }
            // 进行字典排序
            array.Sort();
            // 根据排序拼接baseString用于加密
            var baseString = "";
            foreach (string key in array)
            {
                baseString +=  key + "=" + keyValuePairs[key] + "&";
            }
            // 去除最后一位&
            baseString = baseString.Substring(0, baseString.Length-1);
            return baseString;
        }
        /// <summary>
        /// Object.assign方法
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        private static Dictionary<string, string> assign(Dictionary<string, string> target, Dictionary<string, string> source = null)
        {
            if (source == null)
                return target;
            foreach (KeyValuePair<string, string> keyValuePair in source)
            {
                target[keyValuePair.Key] = keyValuePair.Value;
            }
            return target;
        }
    }

}
