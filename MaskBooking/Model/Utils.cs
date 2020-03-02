using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    public class Utils
    {
        /// <summary>
        /// hex_hmac_md5加密
        /// </summary>
        /// <param name="app_key"></param>
        /// <param name="baseString"></param>
        /// <returns></returns>
        public static string hex_hmac_md5(string app_key, string baseString)
        {
            HMACMD5 provider = new HMACMD5(Encoding.UTF8.GetBytes(app_key));
            byte[] hashedPassword = provider.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            StringBuilder displayString = new StringBuilder();
            for (int i = 0; i < hashedPassword.Length; i++)
            {
                displayString.Append(hashedPassword[i].ToString("x2"));
            }
            Console.WriteLine(displayString);
            return displayString.ToString();
        }

        /// <summary>
        /// hex md5加密
        /// </summary>
        /// <param name="baseString"></param>
        /// <returns></returns>
        public static string hex_md5(string baseString)
        {
            MD5 provider = MD5.Create();
            byte[] hashedPassword = provider.ComputeHash(Encoding.UTF8.GetBytes(baseString));
            StringBuilder displayString = new StringBuilder();
            for (int i = 0; i < hashedPassword.Length; i++)
            {
                displayString.Append(hashedPassword[i].ToString("x2"));
            }
            Console.WriteLine(displayString);
            return displayString.ToString();
        }

        /// <summary>
        /// base64转图片
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        /// <summary>
        /// 处理base64字符串
        /// </summary>
        /// <param name="UntouchedImgBase64"></param>
        /// <returns></returns>
        public static string TouchCaptchaString(string UntouchedImgBase64)
        {
            var base64Reg = new Regex(@"^data:image\/\w+;base64,");
            var SPLIT_STR = "EAPwD";
            var splitReg = new Regex(SPLIT_STR);

            var imgData = UntouchedImgBase64;

            if (splitReg.IsMatch(UntouchedImgBase64))
            {
                var tmp = Regex.Replace(UntouchedImgBase64, @"/\n/g", "");
                var startStr = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAgAAAQABAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAAlAFYDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD";
                var index = tmp.IndexOf(SPLIT_STR) + 5;
                imgData = startStr + tmp.Substring(index);

            }
            if (base64Reg.IsMatch(imgData))
            {
                var base64Data = Regex.Replace(imgData, @"^data:image\/\w+;base64,", "");
                //过滤特殊字符
                //string dummyData = base64Data.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
                //if (dummyData.Length % 4 > 0)
                //{
                //    dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
                //}
                return base64Data;
            }
            throw new Exception();
        }

        /// <summary>
        /// 获取当前时间的毫秒数
        /// </summary>
        /// <returns></returns>
        public static long GetMilliSecondsTime()
        {
            //或var time = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000
            // 时间毫秒数
            long currentTicks = DateTime.Now.Ticks;
            DateTime dtFrom = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long currentMillis = (currentTicks - dtFrom.Ticks) / 10000;
            return currentMillis;
        }
    }
}
