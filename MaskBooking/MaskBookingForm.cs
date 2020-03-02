using MaskBooking.Model;
using MaskBookingTests.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskBooking
{
    public partial class MaskBookingForm : Form
    {
        Model.MaskBooking booker = new Model.MaskBooking();
        //库存信息
        List<StockInfo> stocks = null;
        public MaskBookingForm()
        {
            InitializeComponent();
        }
        //接收验证码
        private void btnStart_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(
            (m)=>
            {
                
                var imageBase64 = booker.RequestCaptchaImg();
                var img = Utils.Base64ToImage(imageBase64);
                var ocr = string.Empty;
                try
                {
                    ocr = BaiduOcr.GetOcrResult(imageBase64);
                }
                catch(Exception baiduException)
                {
                    this.BeginInvoke(new Action(
                      () => {
                          tbxMsg.AppendText(baiduException.StackTrace);
                          tbxMsg.AppendText("百度api失败");
                          tbxMsg.AppendText("\n");
                      }
                      ));
                    
                }
                this.BeginInvoke(new Action(
                    () => {
                        this.pbxImg.Image = img;
                        tbxCaptcha.Text = ocr;
                    }
                    ));
                var stocksStr = booker.RequestMaskStock();
                this.BeginInvoke(new Action(
                    () => {
                        tbxMsg.AppendText(stocksStr);
                        tbxMsg.AppendText("\n");
                    }
                    ));
                stocks = booker.ConvertJsonToStock(stocksStr);
            }
            ));

        }

        //发送信息
        private void btnSendPost_Click(object sender, EventArgs e)
        {
            if (stocks == null)
                return;
            UserInfo.captcha = tbxCaptcha.Text;
            var response = booker.PostPurchaseInfo(stocks);
            this.BeginInvoke(new Action(
            () =>
            {
                tbxMsg.AppendText(response);
                tbxMsg.AppendText("\n");
            }
            ));
        }
    }
}
