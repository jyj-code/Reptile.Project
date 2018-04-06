using System.IO;

namespace System.Data
{
    public class LogHelper
    {
        public static object obj = new object();
        public static void WriteLog(string strPath, string fileName, string txtContent)
        {
            lock (obj)
            {
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }
                Ext.SetAccess("Users", strPath);
                FileStream fs = new FileStream($"{strPath}/{fileName}.txt", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter thisStreamWriter = new StreamWriter(fs);
                thisStreamWriter.BaseStream.Seek(0, SeekOrigin.End);
                thisStreamWriter.WriteLine(txtContent);
                thisStreamWriter.Flush();
                thisStreamWriter.Close();
                fs.Close();
            }
        }
    }
}
