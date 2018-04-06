using DataBase;
using Reptile.Project;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Data
{
    public class data
    {
        #region Add
        public static void AddFinancialData(DataTable dt, string url)
        {
            Task.Factory.StartNew(() =>
            {
                List<FinancialData> list = new List<FinancialData>();
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(new FinancialData
                    {
                        Time = item["时间"].ToString(),
                        Zone = item["区域"].ToString(),
                        Affect_The_Currency = item["时间"].ToString(),
                        Indicator = item["指标"].ToString(),
                        Indicator_Url = item["Url"].ToString(),
                        Interpretation = item["解读"].ToString(),
                        Level = item["重要性"].ToString(),
                        Lido_Free = item[8].ToString(),
                        OperDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Pre = item["前值"].ToString(),
                        PredictiveValue = item["预测值"].ToString(),
                        PublishedValue = item["公布值"].ToString(),
                        URL = url,
                        ID = System.Guid.NewGuid().ToString("N")
                    });
                }
                string Sql = @"insert into FinancialData(ID,Time,Zone,Indicator ,Pre,PredictiveValue ,PublishedValue,Level,Affect_The_Currency,Lido_Free ,Interpretation,Indicator_Url,OperDate,URL)values(@ID,@Time,@Zone,@Indicator,@Pre,@PredictiveValue,@PublishedValue,@Level,@Affect_The_Currency,@Lido_Free,@Interpretation,@Indicator_Url,@OperDate,@URL)";
                DBHelper.SaveCollectionTask(Sql, list);
            });
        }
        public static void AddFinancial_Events(DataTable dt, string url)
        {
            Task.Factory.StartNew(() =>
            {
                List<DSJ> list = new List<DSJ>();
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(new DSJ
                    {
                        Time = item["时间"].ToString(),
                        Events = item["事件"].ToString(),
                        Location = item["地点"].ToString(),
                        Region = item["国家地区"].ToString(),
                        Level = item["重要性"].ToString(),
                        OperDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        URL = url,
                        ID = System.Guid.NewGuid().ToString("N")
                    });
                }
                string Sql = @"insert into Financial_Events(ID,Time,Region,Location,Level,Events,URL,OperDate)values(@ID,@Time,@Region,@Location,@Level,@Events,@URL,@OperDate)";
                DBHelper.SaveCollectionTask(Sql, list);
            });
        }
        public static void AddFinancial_History(DataTable dt,string id)
        {
            Task task = new Task(() =>
            {
                List<Financial_History> list = new List<Financial_History>();
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(new Financial_History
                    {
                        Published_Time = item["公布时间"].ToString(),
                        Indicator_Cycle = item["指标周期"].ToString(),
                        Before_Value = item["前值"].ToString(),
                        Predictive_Value = item["预测值"].ToString(),
                        Present_Value = item["现值"].ToString(),
                        OperDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        ID = id
                    });
                }
                string Sql = @"insert into Financial_History(Published_Time,ID,Indicator_Cycle,Present_Value,Before_Value,Predictive_Value,OperDate)values(@Published_Time,@ID,@Indicator_Cycle,@Present_Value,@Before_Value,@Predictive_Value,@OperDate)";
                DBHelper.SaveCollectionTask(Sql, list);
            });
            task.Start();
        }
        public static int AddSetUp(SetUP setup)
        {
            if (DBHelper.ReadObject<SetUP>(string.Format("select Key,Value,OperDate from setup where key='{0}'", setup.Key), null) != null)
            {
                string Sql = string.Format("update setup set Value='{0}',OperDate='{1}' where key='{2}'", setup.Value, setup.OperDate, setup.Key);
                return DBHelper.ExcuteSQL(Sql, null);
            }
            else
            {
                string Sql = @"insert into setup(Key,Value,OperDate)values(@Key,@Value,@OperDate)";
                return DBHelper.SaveCollection(Sql, new List<SetUP> { setup });
            }

        }
        public static List<SetUP> FindSetUp()
        {
            string Sql = @"select Key,Value,OperDate from setup";
            return DBHelper.ReadCollection<SetUP>(Sql, null);
        }
        public static SetUP SetUp(string key)
        {
            var data = FindSetUp();
            var setup = data == null || data.Count <= 0 ? null : data.Find(n => n.Key == key);
            return setup == null ? new SetUP() : setup;
        }
        public static List<Financial_History> Financial_HistoryList(string id)
        {
            string Sql = $"select Published_Time,ID,Indicator_Cycle,Present_Value,Before_Value,Predictive_Value,OperDate from Financial_History where id='{id}'";
            return DBHelper.ReadCollection<Financial_History>(Sql, null);
        }
        #endregion
    }
}
