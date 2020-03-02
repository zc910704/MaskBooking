namespace MaskBooking
{
    partial class MaskBookingForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbxCaptcha = new System.Windows.Forms.TextBox();
            this.pbxImg = new System.Windows.Forms.PictureBox();
            this.btnSendPost = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbxMsg = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbxCaptcha);
            this.splitContainer1.Panel1.Controls.Add(this.pbxImg);
            this.splitContainer1.Panel1.Controls.Add(this.btnSendPost);
            this.splitContainer1.Panel1.Controls.Add(this.btnSend);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbxMsg);
            this.splitContainer1.Size = new System.Drawing.Size(381, 451);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbxCaptcha
            // 
            this.tbxCaptcha.Location = new System.Drawing.Point(114, 83);
            this.tbxCaptcha.Margin = new System.Windows.Forms.Padding(2);
            this.tbxCaptcha.Name = "tbxCaptcha";
            this.tbxCaptcha.Size = new System.Drawing.Size(68, 21);
            this.tbxCaptcha.TabIndex = 3;
            // 
            // pbxImg
            // 
            this.pbxImg.BackColor = System.Drawing.Color.White;
            this.pbxImg.Location = new System.Drawing.Point(27, 76);
            this.pbxImg.Margin = new System.Windows.Forms.Padding(2);
            this.pbxImg.Name = "pbxImg";
            this.pbxImg.Size = new System.Drawing.Size(83, 33);
            this.pbxImg.TabIndex = 2;
            this.pbxImg.TabStop = false;
            // 
            // btnSendPost
            // 
            this.btnSendPost.Location = new System.Drawing.Point(186, 80);
            this.btnSendPost.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendPost.Name = "btnSendPost";
            this.btnSendPost.Size = new System.Drawing.Size(70, 25);
            this.btnSendPost.TabIndex = 1;
            this.btnSendPost.Text = "确认";
            this.btnSendPost.UseVisualStyleBackColor = true;
            this.btnSendPost.Click += new System.EventHandler(this.btnSendPost_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(27, 47);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 25);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "开始请求";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关闭ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(381, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.关闭ToolStripMenuItem.Text = "菜单";
            // 
            // tbxMsg
            // 
            this.tbxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxMsg.Location = new System.Drawing.Point(0, 0);
            this.tbxMsg.Name = "tbxMsg";
            this.tbxMsg.Size = new System.Drawing.Size(381, 335);
            this.tbxMsg.TabIndex = 0;
            this.tbxMsg.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MaskBookingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 451);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MaskBookingForm";
            this.Text = "预定";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.TextBox tbxCaptcha;
        private System.Windows.Forms.PictureBox pbxImg;
        private System.Windows.Forms.Button btnSendPost;
        private System.Windows.Forms.RichTextBox tbxMsg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

