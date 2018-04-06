using System;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

namespace System.Data
{
    public static class Ext
    {
        public static int Index(this string str, string filter)
        {
            return str != null && str.Length >= 1 ? str.IndexOf(filter) : 0;
        }
        public static int LastIndex(this string str, string filter)
        {
            return str != null && str.Length >= 1 ? str.LastIndexOf(filter) : 0;
        }
        public static bool ToIsDate(this object strDate)
        {
            try
            {
                DateTime.Parse(strDate.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNull(this string str)
        {
            if (str == null || string.IsNullOrEmpty(str.ToString()) || str.ToString().Trim().Length <= 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 为指定用户组，授权目录指定完全访问权限
        /// </summary>
        /// <param name="user">用户组，如Users</param>
        /// <param name="folder">实际的目录</param>
        /// <returns></returns>
        public static bool SetAccess(string user, string folder)
        {
            //定义为完全控制的权限
            const FileSystemRights Rights = FileSystemRights.FullControl;

            //添加访问规则到实际目录
            var AccessRule = new FileSystemAccessRule(user, Rights,
                InheritanceFlags.None,
                PropagationFlags.NoPropagateInherit,
                AccessControlType.Allow);

            var Info = new DirectoryInfo(folder);
            var Security = Info.GetAccessControl(AccessControlSections.Access);

            bool Result;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
            if (!Result) return false;

            //总是允许再目录上进行对象继承
            const InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            //为继承关系添加访问规则
            AccessRule = new FileSystemAccessRule(user, Rights,
                iFlags,
                PropagationFlags.InheritOnly,
                AccessControlType.Allow);

            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
            if (!Result) return false;

            Info.SetAccessControl(Security);

            return true;
        }

        public static string DownloadData(string url)
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            var result = Encoding.UTF8.GetString(MyWebClient.DownloadData(url));
            Thread.Sleep(1000);
                return result;
        }
    }
}
