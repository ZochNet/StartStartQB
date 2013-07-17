using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StartStartQB
{
    class Program
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.Write("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.Write(" :");
            w.WriteLine(" {0}", logMessage);
        }

        static void Main(string[] args)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo process = new
                System.Diagnostics.ProcessStartInfo(@"StartQB.exe");
                process.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.UseShellExecute = true;
                System.Diagnostics.Process.Start(process);
            }
            catch (Exception e)
            {
                using (StreamWriter w = File.AppendText("StartQBlog.txt"))
                {
                    Log("Unable to launch StartQB. Exception message: " + e.Message, w);
                }
            }
        }
    }
}
