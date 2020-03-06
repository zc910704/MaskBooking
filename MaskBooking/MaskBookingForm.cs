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
        private Model.MaskBooking booker = null;
        //重复尝试计数器(次)
        private int retryTime = 3;
        //等待发送计时(s)
        private int waitSecond = 15;

        public MaskBookingForm()
        {
            InitializeComponent();
            try
            {
                booker = new Model.MaskBooking();
            }
            catch (UserInfoLoadException)
            {
                MessageBox.Show("用户信息配置文件加载失败，请检查。");
            }
        }
        //开始
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            ThreadPool.QueueUserWorkItem(new WaitCallback(
                (m) =>
                {
                    for (int i = 0; i < retryTime; i++)
                    {
                        try
                        {
                            Log($"正在进行第{i + 1}次尝试，共{retryTime}次");
                            var html = booker.RequestIndexPage();

                            string timestamp = Utils.GetHtmlTimestamp(html);
                            Log($"获取首页成功，md5加密用时间戳为{timestamp}");
                            var imageBase64 = booker.RequestCaptchaImg();
                            var img = Utils.Base64ToImage(imageBase64);
                            var ocr = string.Empty;
                            try
                            {
                                ocr = BaiduOcr.GetOcrResult(imageBase64, booker.OCRConfig);
                            }
                            catch (Exception baiduException)
                            {
                                Log("百度api调用失败");

                            }
                            this.BeginInvoke(new Action(
                                () =>
                                {
                                    this.pbxImg.Image = img;
                                    tbxCaptcha.Text = ocr;
                                }
                            ));
                            countDown();
                            var stocksStr = booker.RequestMaskStock();
                            Log(stocksStr);
                            List<StockInfo> stocks = booker.ConvertJsonToStock(stocksStr);
                            if (stocks == null)
                                return;
                            booker.UserInfo.captcha = tbxCaptcha.Text;
                            var response = booker.PostPurchaseInfo(stocks, timestamp);
                            Log(response);
                        }
                        catch (Exception ex)
                        {
                            Log(ex.Message);
                        }
                    }
                    this.BeginInvoke(new Action(
                                () =>
                                {
                                    btnSend.Enabled = true;
                                }
                            ));
                    
                }
                ));
        }

        /// <summary>
        /// 阻塞线程，倒计时x秒
        /// </summary>
        private void countDown()
        {
            for (int i = waitSecond; i > 0; i--)
            {
                this.BeginInvoke(new Action(
                                () =>
                                {
                                    lbHint.Text = $"验证码将于{i}秒后发送";
                                }
                            ));
                Thread.Sleep(1000);
            }
            this.BeginInvoke(new Action(
                () =>
                {
                    lbHint.Text = "";
                }
            ));
            
        }

        private void Log(string msg)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(
                   () =>
                   {
                       tbxMsg.AppendText(msg);
                       tbxMsg.AppendText("\n");
                   }
                   ));
            }
            else
            {
                tbxMsg.AppendText(msg);
                tbxMsg.AppendText("\n");
            }
        }
        private void about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

    }
}
