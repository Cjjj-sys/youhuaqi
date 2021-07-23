using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电脑优化器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetCmdOutput(string arg,bool nowindow)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = nowindow;
                //p.StartInfo.Arguments = arg;

                p.Start();

                p.StandardInput.WriteLine(arg);
                p.StandardInput.WriteLine("exit");
                //powercfg /list
                return p.StandardOutput.ReadToEnd();
            }
            catch (Exception)
            {

                return "";
            }
            
        }

        private void CmdRun(string arg, bool nowindow)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = nowindow;
                //p.StartInfo.Arguments = arg;

                p.Start();

                p.StandardInput.WriteLine(arg);
                p.StandardInput.WriteLine("exit");
                //powercfg /list
                //return p.StandardOutput.ReadToEnd();
            }
            catch (Exception)
            {

                //return "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cfg =
            GetCmdOutput("powercfg /list",true);

            if (cfg.Contains("卓越性能"))
            {
                MessageBox.Show("已生成卓越性能,正在尝试开启...");
                //cfg = cfg.Replace("Microsoft Windows [版本 10.0.19042.746]","");
                //cfg = cfg.Replace("(c) 2020 Microsoft Corporation. 保留所有权利。","");
                //cfg = cfg.Replace("C:\\Users\\ws200\\source\\repos\\电脑优化器\\电脑优化器\\bin\\Debug>powercfg /list","");
                //cfg = cfg.Replace("现有电源使用方案 (* Active)","");
                //cfg

                //File.WriteAllText("xfg.txt",cfg);
                tb.Text = cfg;
                string[] tlist = tb.Lines;
                int i = 1;
                string id = "?";
                foreach (var t in tlist)
                {
                    if (t.Contains("卓越性能")&&i==1&&!t.Contains("*"))
                    {
                        id = t.Replace("电源方案 GUID: ","");
                        id = id.Replace("  (卓越性能)","");
                        i++;
                    }
                }
                if (id == "?")
                {
                    MessageBox.Show("你已经启用卓越性能");
                }
                else
                {
                    string result = GetCmdOutput("powercfg /S " + id, true);
                    //string r = GetCmdOutput("powercfg /list", true);
                    MessageBox.Show(result);
                    string b = GetCmdOutput("powercfg /list", true);
                    MessageBox.Show(b);
                }
                

            }
            else
            {
                string a = GetCmdOutput("powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61",true);
                MessageBox.Show(a);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "杀掉资源管理器")
            {
                string a = GetCmdOutput("taskkill /f /im explorer.exe", true);
                MessageBox.Show(a);
                button2.Text = "打开资源管理器";
            }
            else
            {
                CmdRun("%SystemRoot%\\explorer.exe", true);
                button2.Text = "杀掉资源管理器";
                //MessageBox.Show(b);
            }
            
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
