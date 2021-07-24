using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 电脑优化器;

namespace 电脑优化器
{
    public partial class KillP : Form
    {
        public KillP()
        {
            InitializeComponent();
        }

        private void KillP_Load(object sender, EventArgs e)
        {
            try
            {
                RefreshServerList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static string[] GetServerList()
        {
            WebClient wc = new WebClient();
            string temp = Encoding.UTF8.GetString(wc.DownloadData("https://gitee.com/cjjj-sya/dnyhqconfig/raw/master/list.txt"));
            return Regex.Split(temp,",");
        }
        private void RefreshServerList()
        {
            string[] list = GetServerList();
            cbServer.Items.Clear();
            cbServer.Items.AddRange(list);
        }

        private static string[] GetServerConfig(string name)
        {
            WebClient wc = new WebClient();
            string temp = Encoding.UTF8.GetString(wc.DownloadData("https://gitee.com/cjjj-sya/dnyhqconfig/raw/master/"+ name +".txt"));
            return Regex.Split(temp,",");
        }

        private static string GetCmdOutput(string arg, bool nowindow)
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



        private void button1_Click(object sender, EventArgs e)
        {
            RefreshServerList();
        }

        private void cbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbConfig.Clear();
            string[] list = GetServerConfig(cbServer.SelectedItem.ToString());
            foreach (var name in list)
            {
                if (!name.Contains("\n"))
                {
                    if (rtbConfig.Text == "")
                    {
                        rtbConfig.AppendText(name);
                    }
                    else
                    {
                        rtbConfig.AppendText(Environment.NewLine + name);
                    }
                }
                else
                {
                    rtbConfig.AppendText(name);
                }
                
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] runlist = rtbConfig.Lines;
                foreach (var run in runlist)
                {
                    string result =
                        GetCmdOutput("taskkill /f /im " + run, true);
                    if (doShow.Checked)
                    {
                        MessageBox.Show(result);
                    }
                    
                }
                MessageBox.Show("执行成功");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            
        }
    }
}
