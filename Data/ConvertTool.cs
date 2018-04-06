using System.Text.RegularExpressions;

namespace System.Data
{
    public class ConvertTool
    {
        public static DataTable HtmlTableToFinancialData_current_data(string htmlTable, string tableName)
        {
            DataTable dt = new DataTable(tableName);
            try
            {
                #region 第一步：将HtmlTable转换为DataTable  
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    if (i == 0)
                    {
                        foreach (var rd in tdMatchCollection)
                        {
                            var tdValue = RemoveHtml("<td " + rd.ToString().Trim() + "</td>");
                            DataColumn dc = new DataColumn(tdValue);
                            dt.Columns.Add(dc);
                        }
                        dt.Columns.Add(new DataColumn("Url"));
                    }
                    if (i > 1)
                    {
                        string filter = string.Empty;
                        int index = 0;
                        DataRow dr = dt.NewRow();
                        #region MyRegion
                        if (tdMatchCollection.Count == 10)
                        {
                            for (int j = 0; j < tdMatchCollection.Count; j++)
                            {
                                #region MyRegion
                                string tdValue = tdMatchCollection[j].ToString().Trim();
                                if (j == 3 && tdValue.Contains("/Public/images/star_"))
                                {
                                    filter = "/Public/images/star_";
                                    index = tdValue.Index(filter) + filter.Length;
                                    tdValue = tdValue.Substring(index);
                                    tdValue = RemoveHtml(tdValue.Substring(0, tdValue.Length - 6));
                                }
                                #endregion
                                #region MyRegion
                                else if (tdValue.Contains("<div class='c_") && tdValue.Contains("_flag'></div>"))
                                {
                                    filter = "<div class='c_";
                                    tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                                    filter = " circle_flag'></div>";
                                    tdValue = tdValue.Substring(0, tdValue.Index(filter));
                                }
                                #endregion
                                #region MyRegion
                                else if (tdValue.Contains("<a class='nowrap' target='_blank' href='/id") && tdValue.Contains(".html'>"))
                                {
                                    filter = "<a class='nowrap' target='_blank' href='/id";
                                    if (tdValue.Contains(filter))
                                    {
                                        var x = tdValue;
                                        var y = x.Substring(x.Index(filter) + filter.Length - 3);
                                        filter = ".html'>";
                                        dr["Url"] = y.Substring(0, y.Index(filter) + 5);
                                        tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                    }
                                    else
                                    {
                                        tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                    }
                                }
                                #endregion
                                #region MyRegion
                                else
                                {
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                                #endregion
                                dr[j] = tdValue;
                            }
                        }
                        #endregion
                        #region MyRegion
                        else
                        {
                            for (int j = 0; j < tdMatchCollection.Count; j++)
                            {
                                dr[0] = "";
                                dr[1] = "";
                                #region MyRegion
                                string tdValue = tdMatchCollection[j].ToString().Trim();
                                if (j == 3 && tdValue.Contains("/Public/images/star_"))
                                {
                                    filter = "/Public/images/star_";
                                    index = tdValue.Index(filter) + filter.Length;
                                    tdValue = tdValue.Substring(index);
                                    tdValue = RemoveHtml(tdValue.Substring(0, tdValue.Length - 6));
                                }
                                #endregion
                                #region MyRegion
                                else if (tdValue.Contains("<div class='c_") && tdValue.Contains("_flag'></div>"))
                                {
                                    filter = "<div class='c_";
                                    tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                                    filter = " circle_flag'></div>";
                                    tdValue = tdValue.Substring(0, tdValue.Index(filter));
                                }
                                #endregion
                                #region MyRegion
                                else if (tdValue.Contains("<a class='nowrap' target='_blank' href='/id") && tdValue.Contains(".html'>"))
                                {
                                    filter = "<a class='nowrap' target='_blank' href='/id";
                                    if (tdValue.Contains(filter))
                                    {
                                        var x = tdValue;
                                        var y = x.Substring(x.Index(filter) + filter.Length - 3);
                                        filter = ".html'>";
                                        dr["Url"] = y.Substring(0, y.Index(filter) + 5);
                                        tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                    }
                                    else
                                    {
                                        tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                    }
                                }
                                #endregion
                                #region MyRegion
                                else
                                {
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                                #endregion
                                dr[j + 2] = tdValue;
                            }
                        }
                        #endregion
                        dt.Rows.Add(dr);
                    }
                }
                #endregion
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().IsNull() &&
                        dt.Rows[i][1].ToString().IsNull() &&
                        dt.Rows[i][2].ToString().IsNull() &&
                        dt.Rows[i][3].ToString().IsNull() &&
                        dt.Rows[i][4].ToString().IsNull() &&
                        dt.Rows[i][5].ToString().IsNull() &&
                        dt.Rows[i][6].ToString().IsNull() &&
                        dt.Rows[i][7].ToString().IsNull() &&
                        dt.Rows[i][8].ToString().IsNull()&&
                        dt.Rows[i][9].ToString().IsNull()&&
                        dt.Rows[i][10].ToString().IsNull()) { dt.Rows.RemoveAt(i); continue; }

                    if (dt.Rows[i][0].ToString().IsNull())
                    {
                        dt.Rows[i][0] = dt.Rows[i - 1][0];
                    }
                    if (dt.Rows[i][1].ToString().IsNull())
                    {
                        dt.Rows[i][1] = dt.Rows[i - 1][1];
                    }
                }
            }
            catch { }
            return dt;
        }
        public static DataTable HtmlTableToFinancialData_moreData(string htmlTable, DataTable dt)
        {
            try
            {
                #region 第一步：将HtmlTable转换为DataTable  
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    string filter = string.Empty;
                    int index = 0;
                    DataRow dr = dt.NewRow();
                    #region MyRegion
                    if (tdMatchCollection.Count == 10)
                    {
                        for (int j = 0; j < tdMatchCollection.Count; j++)
                        {
                            #region MyRegion
                            string tdValue = tdMatchCollection[j].ToString().Trim();
                            if (j == 3 && tdValue.Contains("/Public/images/star_"))
                            {
                                filter = "/Public/images/star_";
                                index = tdValue.Index(filter) + filter.Length;
                                tdValue = tdValue.Substring(index);
                                tdValue = RemoveHtml(tdValue.Substring(0, tdValue.Length - 6));
                            }
                            #endregion
                            #region MyRegion
                            else if (tdValue.Contains("<div class='c_") && tdValue.Contains("_flag'></div>"))
                            {
                                filter = "<div class='c_";
                                tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                                filter = " circle_flag'></div>";
                                tdValue = tdValue.Substring(0, tdValue.Index(filter));
                            }
                            #endregion
                            #region MyRegion
                            else if (tdValue.Contains("<a class='nowrap' target='_blank' href='/id") && tdValue.Contains(".html'>"))
                            {
                                filter = "<a class='nowrap' target='_blank' href='/id";
                                if (tdValue.Contains(filter))
                                {
                                    var x = tdValue;
                                    var y = x.Substring(x.Index(filter) + filter.Length - 3);
                                    filter = ".html'>";
                                    dr["Url"] = y.Substring(0, y.Index(filter) + 5);
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                                else
                                {
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                            }
                            #endregion
                            #region MyRegion
                            else
                            {
                                tdValue = RemoveHtml("<td " + tdValue + "</td>");
                            }
                            #endregion
                            dr[j] = tdValue;
                        }
                    }
                    #endregion
                    #region MyRegion
                    else
                    {
                        for (int j = 0; j < tdMatchCollection.Count; j++)
                        {
                            dr[0] = "";
                            dr[1] = "";
                            #region MyRegion
                            string tdValue = tdMatchCollection[j].ToString().Trim();
                            if (j == 3)
                            {
                                filter = "/Public/images/star_";
                                index = tdValue.Index(filter) + filter.Length;
                                tdValue = tdValue.Substring(index);
                                tdValue = RemoveHtml(tdValue.Substring(0, tdValue.Length - 6));
                            }
                            #endregion
                            #region MyRegion
                            else if (tdValue.Contains("<div class='c_") && tdValue.Contains("_flag'></div>"))
                            {
                                filter = "<div class='c_";
                                tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                                filter = " circle_flag'></div>";
                                tdValue = tdValue.Substring(0, tdValue.Index(filter));
                            }
                            #endregion
                            #region MyRegion
                            else if (tdValue.Contains("<a class='nowrap' target='_blank' href='/id") && tdValue.Contains(".html'>"))
                            {
                                filter = "<a class='nowrap' target='_blank' href='/id";
                                if (tdValue.Contains(filter))
                                {
                                    var x = tdValue;
                                    var y = x.Substring(x.Index(filter) + filter.Length - 3);
                                    filter = ".html'>";
                                    dr["Url"] = y.Substring(0, y.Index(filter) + 5);
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                                else
                                {
                                    tdValue = RemoveHtml("<td " + tdValue + "</td>");
                                }
                            }
                            #endregion
                            #region MyRegion
                            else
                            {
                                tdValue = RemoveHtml("<td " + tdValue + "</td>");
                            }
                            #endregion
                            dr[j + 2] = tdValue;
                        }
                    }
                    #endregion
                    dt.Rows.Add(dr);
                }
                #endregion

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().IsNull())
                    {
                        dt.Rows[i][0] = dt.Rows[i - 1][0];
                    }
                    if (dt.Rows[i][1].ToString().IsNull())
                    {
                        dt.Rows[i][1] = dt.Rows[i - 1][1];
                    }
                }
            }
            catch { }
            return dt;
        }
        public static DataTable HtmlTableToDSJ(string htmlTable, string tableName)
        {
            DataTable dt = new DataTable(tableName);
            try
            {
                #region 第一步：将HtmlTable转换为DataTable  
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    if (i == 0)
                    {
                        foreach (var rd in tdMatchCollection)
                        {
                            var tdValue = RemoveHtml("<td " + rd.ToString().Trim() + "</td>");
                            DataColumn dc = new DataColumn(tdValue);
                            dt.Columns.Add(dc);
                        }
                    }
                    if (i > 0)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < tdMatchCollection.Count; j++)
                        {
                            string tdValue = tdMatchCollection[j].ToString().Trim();
                            string filter = "/Public/images/star_";
                            if (j == 3 && tdValue.Contains(filter))
                            {
                                tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                                tdValue = tdValue.Substring(0, 1);
                            }
                            else { tdValue = RemoveHtml("<td " + tdValue + "</td>"); }
                            dr[j] = tdValue;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                #endregion
            }
            catch { }
            return dt;
        }
        public static DataTable HtmlTableToDSJ(string htmlTable,ref DataTable dt)
        {
            try
            {
                #region 第一步：将HtmlTable转换为DataTable  
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < tdMatchCollection.Count; j++)
                    {
                        string tdValue = tdMatchCollection[j].ToString().Trim();
                        string filter = "/Public/images/star_";
                        if (j == 3 && tdValue.Contains(filter))
                        {
                            tdValue = tdValue.Substring(tdValue.Index(filter) + filter.Length);
                            tdValue = tdValue.Substring(0, 1);
                        }
                        else { tdValue = RemoveHtml("<td " + tdValue + "</td>"); }
                        dr[j] = tdValue;
                    }
                    dt.Rows.Add(dr);
                }
                #endregion
            }
            catch { }
            return dt;
        }
        public static DataTable HtmlTable(string htmlTable, string tableName)
        {
            DataTable dt = new DataTable(tableName);
            try
            {
                #region 第一步：将HtmlTable转换为DataTable  
                htmlTable = htmlTable.Replace("\"", "'");
                var trReg = new Regex(pattern: @"(?<=(<[t|T][r|R]))[\s\S]*?(?=(</[t|T][r|R]>))");
                var trMatchCollection = trReg.Matches(htmlTable);
                for (int i = 0; i < trMatchCollection.Count; i++)
                {
                    var row = "<tr " + trMatchCollection[i].ToString().Trim() + "</tr>";
                    var tdReg = new Regex(pattern: @"(?<=(<[t|T][d|D|h|H]))[\s\S]*?(?=(</[t|T][d|D|h|H]>))");
                    var tdMatchCollection = tdReg.Matches(row);
                    if (i == 0)
                    {
                        foreach (var rd in tdMatchCollection)
                        {
                            var tdValue = RemoveHtml("<td " + rd.ToString().Trim() + "</td>");
                            DataColumn dc = new DataColumn(tdValue);
                            dt.Columns.Add(dc);
                        }
                    }
                    if (i > 0)
                    {
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < tdMatchCollection.Count; j++)
                        {
                            string tdValue = tdMatchCollection[j].ToString().Trim();
                            tdValue = RemoveHtml("<td " + tdValue + "</td>");
                            dr[j] = tdValue;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                #endregion
            }
            catch { }
            return dt;
        }
        static string RemoveHtml(string htmlstring)
        {
            //删除脚本      
            htmlstring =
                Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>",
                              "", RegexOptions.IgnoreCase);
            //删除HTML      
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);


            htmlstring = htmlstring.Replace("<", "");
            htmlstring = htmlstring.Replace(">", "");
            htmlstring = htmlstring.Replace("\r\n", "");
            string filter = "rowspan=";
            if (htmlstring.Trim().Contains(filter))
            {
                htmlstring = "<" + htmlstring;
                RemoveHtml(htmlstring);
            }
            filter = "'img src='/Public/images/loading";
            return htmlstring.Trim().Contains(filter) ? "" : htmlstring.Trim();
        }
    }
}
