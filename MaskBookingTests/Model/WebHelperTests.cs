using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaskBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaskBookingTests.Model;

namespace MaskBooking.Model.Tests
{
    [TestClass()]
    public class WebHelperTests
    {
        [TestMethod()]
        public void GetMethodTest()
        {
            var url = "http://kzgm.bbshjz.cn:8000/ncms/mask/captcha";
            var s = WebHelper.GetMethod(url);
            if (string.IsNullOrEmpty(s))
                Assert.Fail();
        }

        [TestMethod()]
        public void GetMethodTest1()
        {
            var url = "http://kzgm.bbshjz.cn:8000/ncms/mask/captcha";
            var cookie = "JSESSIONID=NjE3NzcxNWYtZDk4MC00NTY4LTg2ZjYtZGRmYjVhNzQ5OGQ0";
            Config.cookie = cookie;
            var s = WebHelper.GetMethod(url);
            if (string.IsNullOrEmpty(s))
                Assert.Fail();

        }

        [TestMethod()]
        public void PostMethodTest()
        {
            var url = "http://kzgm.bbshjz.cn:8000/ncms/mask/book";
            var s = WebHelper.PostMethod(new StockInfo(),url);
            if (string.IsNullOrEmpty(s))
                Assert.Fail();
        }
    }
}