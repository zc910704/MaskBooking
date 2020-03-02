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
    public class RequestTests
    {
        [TestMethod()]
        public void GetMaskCountTest()
        {
            MaskBooking r = new MaskBooking();
            r.RequestMaskStock();
        }

        [TestMethod()]
        public void GetMaskCountHandlerTest()
        {
            //json字符串需要处理掉[]外的的双引号。
            string str = "{\"msg\":[{\"remain\":0,\"text\":\"9:00-13:00/剩余:0个\",\"value\":\"9:00-13:00\"},{\"remain\":0,\"text\":\"13:00-17:00/剩余:0个\",\"value\":\"13:00-17:00\"}],\"succeed\":true,\"status\":1}";
            MaskBooking r = new MaskBooking();
            //r.GetMaskIsRemainHandler(str);
        }
    }
}