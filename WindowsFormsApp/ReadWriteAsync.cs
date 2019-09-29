using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public class ReadWriteAsync
    {
        public static readonly string PathLog = (Application.StartupPath + @"\AppLog.log");
        public static async void WriteLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(PathLog, false))
            {
                await writer.WriteAsync(message);
            }
        }

        public static async Task<string> ReadLog()
        {
            using (StreamReader reader = new StreamReader(PathLog, false))
            {
                string message = await reader.ReadToEndAsync();
                return message;
            }
        }

    }
}
