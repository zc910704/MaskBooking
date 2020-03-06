using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    public static class BaiduOcr
    {
        /// <summary>
        /// 百度识别接口
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string GetOcrResult(string base64String,OCRConfig oCRConfig)
        {

            Baidu.Aip.Ocr.Ocr client = new Baidu.Aip.Ocr.Ocr(oCRConfig.API_KEY, oCRConfig.SECRET_KEY);
            client.Timeout = 1000;  //修改超时时间

            byte[] imageBytes = Convert.FromBase64String(base64String);

            // 如果有可选参数
            var options = new Dictionary<string, object>{
                {"language_type", "CHN_ENG"},
                {"detect_direction", "true"},
                {"detect_language", "true"},
                {"probability", "true"}
                };
            // 带参数调用通用文字识别, 图片参数为本地图片
            var result = client.GeneralBasic(imageBytes, options);
            Console.WriteLine(result);
            var s = result["words_result"][0]["words"];

            return s.ToString();
        }
    }
}
