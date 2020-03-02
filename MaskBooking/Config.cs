using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaskBooking.Model
{
    /// <summary>
    /// 程序配置
    /// </summary>
    public class Config
    {
        //入口
        public const string baseUrl = "http://kzgm.bbshjz.cn:8000/ncms";

        //百度AI OCR接口：APPID/AK/SK
        public const string APP_ID = "";
        public const string API_KEY = "";
        public const string SECRET_KEY = "";

        //调整信息
        // 不填
        public static string cookie = "";
        // 当前时间与对方服务端的时间差，我的时间和对方服务端大概差了 30s  如果出现一直请求频繁，可以尝试更改这个时间
        public static int timeDifference = 30000;
    }

    // 信息配置
    [Serializable]
    public class UserInfo
    {
        // 姓名
        public static string name = "李四";
        // 身份证
        public static string cardNo = "343245194502050567";
        // 手机号
        public static string phone = "13966278665";
        // 口罩数量 固定5 切勿更改
        public static string reservationNumber = "5";
        // 领取口罩的药店名称 
        public static string pharmacyName = "国胜大药房坝下路店";
        // 领取口罩的药店编号ID 
        public static string pharmacyCode = "11183";
        // 通过上次请求获取到的有效的口罩信息 数量和时间点 请勿填写，自动获取生成
        public static string pharmacyPhase = "";
        // 请勿填写，自动获取生成
        public static string pharmacyPhaseName = "";
        // 验证码 自动获取
        public static string captcha = "";
    }

}
