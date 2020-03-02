using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaskBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model.Tests
{
    [TestClass()]
    public class isvDataHelperTests
    {
        [TestMethod()]
        public void hex_hmac_md5Test()
        {
            // 密钥
            var app_key = "123";
            string baseString = "app_id=app_weixin&code=11183&timestamp=1583062831&version=1";
            var sign = Utils.hex_hmac_md5(app_key, baseString);
            var expected = "de8b6386ce3a03c65ad0dddbd05a8b9d";
            Assert.AreEqual(sign, expected);
        }

        /// <summary>
        /// 由于时间戳变动，使用固定时间戳测试
        /// </summary>
        [TestMethod()]
        public void isvDataTest()
        {
            var url =    @"http://kzgm.bbshjz.cn:8000/ncms/mask/pharmacy-stock?code=11183";
            var expect = @"http://kzgm.bbshjz.cn:8000/ncms/mask/pharmacy-stock?code=11183&app_id=app_weixin&timestamp=1583062831&version=1&sign=de8b6386ce3a03c65ad0dddbd05a8b9d";
            var real = UrlHandler.MordifyByTimeStampMD5(url, "1583062831");
            Assert.AreEqual(real, expect);
        }
    }
}