using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
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

        private static string GetCmdOutput(string arg,bool nowindow)
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

                cfg = GetCmdOutput("powercfg /list", true);

                MessageBox.Show("已生成卓越性能,正在尝试开启...");
                tb.Text = cfg;
                string[] tlist = tb.Lines;
                int i = 1;
                string id = "?";
                foreach (var t in tlist)
                {
                    if (t.Contains("卓越性能") && i == 1 && !t.Contains("*"))
                    {
                        id = t.Replace("电源方案 GUID: ", "");
                        id = id.Replace("  (卓越性能)", "");
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

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "正在清理...";
            ClearMemory();
            button4.Text = "清理内存";
        }

        [DllImport("psapi.dll")]
        static extern int EmptyWorkingSet(IntPtr hwProc);

        /// <summary>
        /// 释放内存
        /// </summary>
        public void ClearMemory()
        {
            long before = GetAvailablePhysicalMemory();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                //对于系统进程会拒绝访问，导致出错，此处对异常不进行处理。
                try
                {
                    EmptyWorkingSet(process.Handle);
                }
                catch
                {
                }
            }
            long after = GetAvailablePhysicalMemory();
            double result = (after - before)/ 1048576;
            MessageBox.Show("清理了 " + result.ToString() + "MB 的内存") ;
        }

        /// <summary>
        /// 获得已使用的物理内存的大小，单位 (Byte)，如果获取失败，返回 -1.
        /// </summary>
        /// <returns></returns>
        public static long GetTotalPhysicalMemory()
        {
            long capacity = 0;
            try
            {
                foreach (ManagementObject mo1 in new ManagementClass("Win32_PhysicalMemory").GetInstances())
                    capacity += long.Parse(mo1.Properties["Capacity"].Value.ToString());
            }
            catch (Exception ex)
            {
                capacity = -1;
                Console.WriteLine(ex.Message);
            }
            return capacity;
        }


        /// <summary>
        /// 获得已使用的物理内存的大小，单位 (Byte)，如果获取失败，返回 -1.
        /// </summary>
        /// <returns></returns>
        public static long GetAvailablePhysicalMemory()
        {
            long capacity = 0;
            try
            {
                foreach (ManagementObject mo1 in new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory").GetInstances())
                    capacity += long.Parse(mo1.Properties["AvailableBytes"].Value.ToString());
            }
            catch (Exception ex)
            {
                capacity = -1;
                Console.WriteLine(ex.Message);
            }
            return capacity;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KillP killP = new KillP();
            killP.ShowDialog();
        }
    }
}
