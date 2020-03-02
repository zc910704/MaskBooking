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
    public class MaskBookingTests
    {
        [TestMethod()]
        public void PostPurchaseInfoTest()
        {
            List<StockInfo> info = new List<StockInfo>();
            Model.MaskBooking booker = new Model.MaskBooking();
            booker.PostPurchaseInfo(info);
        }
    }
}