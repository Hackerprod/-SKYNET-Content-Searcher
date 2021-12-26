using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.Logging;

namespace SKYNET
{
    static class Program
    {
        static string CustomLocation;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            OpenForm(modCommon.Hackerprod ? true : false, args);
        }
        static AppController app;
        private static void OpenForm(bool normal, string[] args)
        {
            try
            {
                CustomLocation = Path.Combine(modCommon.GetPath(), "Data");

                if (normal)
                {
                    Application.ThreadException += UIThreadExceptionHandler; 
                    AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmMain());
                }
                else
                {
                    Application.SetCompatibleTextRenderingDefault(false);
                    app = new AppController();
                    ConfigureLogSystem(app);
                    app.Run(args);
                }
            }
            catch (Exception ex)
            {

            }
        }


        public static void UIThreadExceptionHandler(object sender, ThreadExceptionEventArgs t)
        {
            WriteException(t.Exception);
        }

        public static void UnhandledExceptionHandler(object sender, System.UnhandledExceptionEventArgs t)
        {
            WriteException(t.ExceptionObject);
        }
        class AppController : WindowsFormsApplicationBase
        {
            public AppController() : base(AuthenticationMode.Windows)
            {
                this.IsSingleInstance = true;
                this.EnableVisualStyles = true;
                this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
            }

            protected override bool OnStartup(StartupEventArgs eventArgs)
            {
                this.MainForm = new frmMain();
                return base.OnStartup(eventArgs);
            }
        }
        private static void ConfigureLogSystem(AppController app)
        {
            app.UnhandledException += App_UnhandledException;
            app.Log.DefaultFileLogWriter.BaseFileName = "[SKYNET] Content Searcher";
            app.Log.DefaultFileLogWriter.CustomLocation = CustomLocation;
            app.Log.DefaultFileLogWriter.Location = LogFileLocation.Custom;
            app.Log.DefaultFileLogWriter.Append = false;
            app.Log.DefaultFileLogWriter.AutoFlush = true;
        }
        private static void App_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
        {
            e.ExitApplication = false;
            WriteException(e.Exception);
        }
        public static void WriteException(object msg)
        {
            if (msg is Exception)
            {
                Exception ex = (Exception)msg;
                Write(ex, Path.Combine(CustomLocation, "[SKYNET] Content Searcher.log"));
            }
        }
        public static void Write(Exception ex, string Filename)
        {
            string returns = "";

            modCommon.EnsureDirectoryExists(Filename);

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("");
                stringBuilder.Append(ex.Message);
                if (ex.InnerException != null)
                    stringBuilder.Append("\r\n").Append((object)ex.InnerException);
                if (ex.StackTrace != null)
                    stringBuilder.Append("\r\n").Append(ex.StackTrace);
                returns = string.Format($"{(object)stringBuilder.ToString()}:");
                AppendFile(returns, Filename);
            }
            catch { }
        }
        public static void AppendFile(string s, string fname)
        {
            string path = Path.Combine(Application.StartupPath, fname);
            StreamWriter streamWriter = null;
            try
            {
                mutexFile = LogMutex.mutexFile;
                mutexFile.WaitOne();
                FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
                streamWriter = new StreamWriter(stream);
                streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
                streamWriter.WriteLine(Conversions.ToString(DateAndTime.Now) + ":" + s);
                streamWriter.Close();
                modCommon.Show(s);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                streamWriter?.Close();
                ProjectData.ClearProjectError();
            }
            finally
            {
                mutexFile.ReleaseMutex();
            }
        }
        public static Mutex mutexFile;
        public class LogMutex
        {
            public static Mutex mutexFile = new Mutex(false, "LogMutex");
        }
    }
}
