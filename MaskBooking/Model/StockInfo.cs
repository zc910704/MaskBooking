using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskBookingTests.Model
{
    public class StockInfo
    {
        /// <summary>
        /// 选择框显示文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 实际库存信息
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 剩余个数
        /// </summary>
        public int remain { get; set; }
    }
}
