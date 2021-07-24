
namespace 电脑优化器
{
    partial class KillP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rtbConfig = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.bCreate = new System.Windows.Forms.Button();
            this.rtbCreate = new System.Windows.Forms.RichTextBox();
            this.doShow = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(8, 6);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(158, 20);
            this.cbServer.TabIndex = 0;
            this.cbServer.SelectedIndexChanged += new System.EventHandler(this.cbServer_SelectedIndexChanged);
            // 
            // cbClient
            // 
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(8, 6);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(144, 20);
            this.cbClient.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(408, 188);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.doShow);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.rtbConfig);
            this.tabPage1.Controls.Add(this.cbServer);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(400, 162);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "云端配置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rtbCreate);
            this.tabPage2.Controls.Add(this.bCreate);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.cbClient);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(400, 162);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "本地配置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rtbConfig
            // 
            this.rtbConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtbConfig.Location = new System.Drawing.Point(172, 3);
            this.rtbConfig.Name = "rtbConfig";
            this.rtbConfig.Size = new System.Drawing.Size(225, 156);
            this.rtbConfig.TabIndex = 1;
            this.rtbConfig.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "刷新列表";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(89, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "执行";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(239, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "刷新列表";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(315, 7);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 20);
            this.button4.TabIndex = 2;
            this.button4.Text = "执行";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // bCreate
            // 
            this.bCreate.Location = new System.Drawing.Point(158, 7);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(75, 20);
            this.bCreate.TabIndex = 3;
            this.bCreate.Text = "新建配置";
            this.bCreate.UseVisualStyleBackColor = true;
            // 
            // rtbCreate
            // 
            this.rtbCreate.Enabled = false;
            this.rtbCreate.Location = new System.Drawing.Point(6, 32);
            this.rtbCreate.Name = "rtbCreate";
            this.rtbCreate.Size = new System.Drawing.Size(379, 122);
            this.rtbCreate.TabIndex = 4;
            this.rtbCreate.Text = "";
            // 
            // doShow
            // 
            this.doShow.AutoSize = true;
            this.doShow.Location = new System.Drawing.Point(8, 32);
            this.doShow.Name = "doShow";
            this.doShow.Size = new System.Drawing.Size(132, 16);
            this.doShow.TabIndex = 3;
            this.doShow.Text = "消息框显示执行结果";
            this.doShow.UseVisualStyleBackColor = true;
            // 
            // KillP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 188);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KillP";
            this.Text = "选择杀进程的配置";
            this.Load += new System.EventHandler(this.KillP_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbConfig;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbCreate;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox doShow;
    }
}