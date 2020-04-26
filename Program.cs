using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadSharp
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private static ResourceManager LocRM = new ResourceManager("NotepadSharp.frmMain", typeof(frmMain).Assembly);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
#if !DEBUG
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException +=
                    new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException +=
                    new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
#endif
                if (Environment.OSVersion.Version.Major <= 6)
                    SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, LocRM.GetString("SystemError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            switch (e.Exception.GetType().ToString())
            {
                case "System.OutOfMemoryException":

                    MessageBox.Show(LocRM.GetString("OutOfMemory"), LocRM.GetString("$this.Text"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
                default:
                    string str = GetExceptionMsg(e.Exception, e.ToString());
                    MessageBox.Show(str, LocRM.GetString("SystemError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            switch ((e.ExceptionObject as Exception).GetType().ToString())
            {
                case "System.OutOfMemoryException":

                    MessageBox.Show(LocRM.GetString("OutOfMemory"), LocRM.GetString("$this.Text"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    break;
                default:
                    string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
                    MessageBox.Show(str, LocRM.GetString("SystemError"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// 生成自定义异常消息
        /// </summary>
        /// <param name="ex">异常对象</param>
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>
        /// <returns>异常字符串文本</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*********************An Error Occured*************************");
            sb.AppendLine("[Occured When]:"    + DateTime.Now.ToString());
            sb.AppendLine("[Program Version]:" + Application.ProductVersion);
            if (ex != null)
            {
                sb.AppendLine("[Exception Type]:" + ex.GetType().Name);
                sb.AppendLine("[Message]:"        + ex.Message);
                sb.AppendLine("[StackTrace]:"     + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("[Uncaught Exception]:" + backStr);
            }

            sb.AppendLine("***************************************************************");
            sb.AppendLine("Please create an issue at https://github.com/XHSofts/NotepadSharp/issues");
            sb.AppendLine("Copy (Ctrl+C) these messages and paste on your issue post, thank you!");
            return sb.ToString();
        }
    }
}