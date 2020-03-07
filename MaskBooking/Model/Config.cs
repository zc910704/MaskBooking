using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        //调整信息
        // 不填
        public static string cookie = "";
    }

    //百度AI OCR接口：APPID/AK/SK
    [Serializable]
    public class OCRConfig : INotifyPropertyChanged
    {
        private string _APP_ID = "";
        public string APP_ID
        {
            get
            {
                return _APP_ID;
            }
            set
            {
                _APP_ID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("APP_ID"));
            }
        }

        private string _API_KEY = "";
        public string API_KEY
        {
            get
            {
                return _API_KEY;
            }
            set
            {
                _API_KEY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("API_KEY"));
            }
        }

        private string _SECRET_KEY = "";
        public string SECRET_KEY
        {
            get
            {
                return _SECRET_KEY;
            }
            set
            {
                _SECRET_KEY = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SECRET_KEY"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    // 信息配置
    [Serializable]
    public class UserInfo : INotifyPropertyChanged
    {
        // 姓名
        private string _Name = "";
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        // 身份证
        private string _CardNo = "343245194502050567";
        public string CardNo
        {
            get
            {
                return _CardNo;
            }
            set
            {
                _CardNo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CardNo"));
            }
        }

        // 手机号
        private string _Phone = "13133378665";
        public string Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Phone"));
            }
        }

        // 口罩数量 固定5 切勿更改
        private string _ReservationNumber = "5";
        public string ReservationNumber
        {
            get
            {
                return _ReservationNumber;
            }
            set
            {
                _ReservationNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReservationNumber"));
            }
        }
        // 领取口罩的药店名称 
        private string _PharmacyName = "国胜大药房坝下路店";
        public string PharmacyName
        {
            get
            {
                return _PharmacyName;
            }
            set
            {
                _PharmacyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PharmacyName"));
            }
        }
        // 领取口罩的药店编号ID 
        private string _PharmacyCode = "11183";
        public string PharmacyCode
        {
            get
            {
                return _PharmacyCode;
            }
            set
            {
                _PharmacyCode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PharmacyCode"));
            }
        }
        // 通过上次请求获取到的有效的口罩信息 数量和时间点 请勿填写，自动获取生成
        //public static string pharmacyPhase = "";
        // 请勿填写，自动获取生成
        //public static string pharmacyPhaseName = "";

        // 验证码 自动获取
        private string _Captcha = "";
        public string Captcha
        {
            get
            {
                return _Captcha;
            }
            set
            {
                _Captcha = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
