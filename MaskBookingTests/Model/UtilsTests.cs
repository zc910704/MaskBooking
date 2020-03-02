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
    public class UtilsTests
    {
        [TestMethod()]
        public void hex_md5Test()
        {
            var time = "1583154289591";
            var hashexpect = "0b574ed4f224752eb81c8bb49dc2af00";
            var hashed = Utils.hex_md5(time + "c7c7405208624ed90976f0672c09b884");
            Assert.AreEqual(hashexpect, hashed);
        }
    }
}