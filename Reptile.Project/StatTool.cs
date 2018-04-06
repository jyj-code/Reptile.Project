using System;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Reptile.Project
{
    public class StatTool
    {
        public static string Url = "http://rl.fx678.com/";
        public const string SavefilePath = "SavefilePath";
        public const string TimingInterval = "Timing interval";
        public const long hm = 60000;

        public static void CreateTask(string url, DateTime datetime)
        {
            Task.Factory.StartNew(() =>
            {
                ABS(url, datetime);
            });
        }
        public static DataSet ABS(string url, DateTime datetime)
        {
            DataSet ds = new DataSet();
            var data = GetString(url);
            #region 财经数据
            var str = data;
            string filter = "</table>";
            if (str.Contains(filter))
                str = str.Substring(0, str.Index(filter) + filter.Length);
            var dt = ConvertTool.HtmlTableToFinancialData_current_data(str, "财经数据");
            str = data;
            if (str.Contains(filter))
                str = str.Substring(str.Index(filter) + filter.Length);
            if (str.Contains(filter))
                str = str.Substring(0, str.Index(filter) + filter.Length);
            var FinancialData = ConvertTool.HtmlTableToFinancialData_moreData(str, dt);
            DataTableWritertxt(FinancialData, $"{GetPath}\\财经数据", datetime.ToString("yyyyMMddHHmmss"));
            Data.data.AddFinancialData(FinancialData, url);
            ds.Tables.Add(FinancialData);
            #endregion
            #region 财经大事件
            str = data;
            filter = " <!--<div class=\"sq_logo mar_top_40\">-->";
            if (str.Contains(filter))
                str = str.Substring(0, str.Index(filter)-filter.Length+40);
            filter = " <div class=\"clear\"></div>";
            if (str.Contains(filter))
                str = str.Substring(str.LastIndex(filter)+ filter.Length);
            data = str;
            filter = "</table>";
            if (str.Contains(filter))
                str = str.Substring(0, str.Index(filter) + filter.Length);
            var Financial_Events = ConvertTool.HtmlTableToDSJ(str, "财经大事件");

            filter = "<table ";
            if (data.Contains(filter))
                data = data.Substring(data.LastIndex(filter));
            Financial_Events = ConvertTool.HtmlTableToDSJ(data, ref Financial_Events);

            Data.data.AddFinancial_Events(Financial_Events, url);
            DataTableWritertxt(Financial_Events, $"{GetPath}\\财经大事件", datetime.ToString("yyyyMMddHHmmss"));
            ds.Tables.Add(Financial_Events);
            #endregion
            GetHistory(ref ds, datetime);
            return ds;
        }

        #region 财经数据和财经大事件爬取
        static string GetString(string url)
        {
            string StarStr = "<div class=\"table-cont\">";
            string endStr = "<!--<div class=\"sq_logo mar_top_40\">-->"; var html = Ext.DownloadData(url);
            var index = html.Index(StarStr) + StarStr.Length;
            var end = html.Index(endStr);
            string str = html.Substring(0, end);
            str = html.Substring(index);
            return str;
        } 
        #endregion
        #region 抓取财经历史数据
        static void GetHistory(ref DataSet ds, DateTime datetime)
        {
            foreach (DataRow item in ds.Tables["财经数据"].Rows)
            {
                if (item["Url"] != null && item["Url"].ToString() != null && item["Url"].ToString().Length > 4)
                {
                    var hisStrHtml = Ext.DownloadData(string.Format("{0}{1}", Url, item["Url"].ToString()));
                    hisStrHtml = hisStrHtml.Substring(hisStrHtml.Index("<table class=\"choose_table1\">"));
                    var dt = ConvertTool.HtmlTable(hisStrHtml.Substring(0, hisStrHtml.Index("</table>") + 8), "财经历史数据" + item["Url"].ToString());
                    Data.data.AddFinancial_History(dt, item["Url"].ToString());
                    var id = item["Url"].ToString();
                    if (id.Contains("/"))
                    {
                        id = id.Split('/')[2].Trim();
                        id = id.Substring(0, id.Length - 5);
                    }
                    DataTableWritertxt(dt, $"{GetPath}\\财经历史数据", id);
                    ds.Tables.Add(dt);
                }
            }
        }
        #endregion
        #region 写Txt
        static string GetPath
        {
            get
            {
                var path = Data.data.SetUp(StatTool.SavefilePath);
                if (path == null || path.Value.IsNull())
                    return Environment.CurrentDirectory;
                else
                    return path.Value;
            }
        }
        static void DataTableWritertxt(DataTable dt, string strPath, string fileName)
        {
            Task.Factory.StartNew(() =>
            {
                LogHelper.WriteLog(strPath, fileName, DataTableConvertStr(dt));
            });
        }
        static string DataTableConvertStr(DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var value = dt.Rows[i][j].ToString();
                    if (value.StartsWith("/id/") && value.Contains(".html") && value.Contains("/"))
                    {
                        value = value.Split('/')[2].Trim();
                        value = value.Substring(0, value.Length - 5);
                    }
                    str.Append(value + "\t ");
                }
                str.Append(System.Environment.NewLine);
            }
            return str.ToString();
        } 
        #endregion
    }

}
