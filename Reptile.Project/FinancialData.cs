using System;

namespace Reptile.Project
{
    public class FinancialData
    {
        public string ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 区域
        /// </summary>
        public string Zone { get; set; }
        /// <summary>
        /// 指标
        /// </summary>
        public string Indicator { get; set; }
        /// <summary>
        /// 指标链接
        /// </summary>
        public string Indicator_Url { get; set; }
        /// <summary>
        /// 前值
        /// </summary>
        public string Pre { get; set; }
        /// <summary>
        /// 预测值
        /// </summary>
        public string PredictiveValue { get; set; }
        /// <summary>
        /// 公布值
        /// </summary>
        public string PublishedValue { get; set; }
        /// <summary>
        /// 重要性
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 影响币种
        /// </summary>
        public string Affect_The_Currency { get; set; }
        /// <summary>
        /// 利多 利空
        /// </summary>
        public string Lido_Free { get; set; }
        /// <summary>
        /// 解读
        /// </summary>
        public string Interpretation { get; set; }
        public string URL { get; set; }
        public string OperDate { get; set; }
    }

    public class DSJ
    {
        public string ID { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 地点
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 重要性
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 事件
        /// </summary>
        public string Events { get; set; }
        public string URL { get; set; }
        public string OperDate { get; set; }
    }

    public class Financial_History
    {
        /// <summary>
        /// 公布时间	
        /// </summary>
        public string Published_Time { get; set; }
        /// <summary>
        /// 指标周期	
        /// </summary>
        public string Indicator_Cycle { get; set; }
        /// <summary>
        /// 现值	
        /// </summary>
        public string Present_Value { get; set; }
        /// <summary>
        /// 前值	
        /// </summary>
        public string Before_Value { get; set; }
        /// <summary>
        /// 预测值
        /// </summary>
        public string Predictive_Value { get; set; }
        public string OperDate { get; set; }
        public string ID { get; set; }
    }

    public class SetUP
    {

        public string Key { get; set; }
        public string Value { get; set; }
        public string OperDate { get; set; }
    }
}
