using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reptile.Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dgvFinads.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvFinads_RowsAdded);
            this.dgvFinacial.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvFinacial_RowsAdded);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.myIcon.Text = "财经爬虫";
            timer1.Enabled = false;
            this.skinEngine1.SkinFile = "MSN.ssk";
            Task.Factory.StartNew(() =>
            {
                //var currDay = System.DateTime.Now;
                //var ds = StatTool.ABS(string.Format("{0}/date/{1}.html", StatTool.Url, currDay.ToString("yyyyMMdd")), currDay);
                BeginInvoke(new MethodInvoker(delegate ()
                {
                    _ic = Cale(txtTime.Text);
                    EnabledTrue();
                    //dgvFinacial.DataSource = ds.Tables["财经数据"];
                    //dgvFinads.DataSource = ds.Tables["财经大事件"];
                    txtPath.Text = Data.data.SetUp(StatTool.SavefilePath).Value;
                    txtTime.Text = Data.data.SetUp(StatTool.TimingInterval).Value;
                    label6.Text = $"毫秒后开始第{ICount}次爬取";
                    label5.Text = _ic.ToString();
                    timer1.Enabled = true;
                }));
            });
        }
        public string Cale(string txt)
        {
            var lg = Convert.ToUInt64(txt) * StatTool.hm;
            return lg.ToString();
        }
        public DataSet Pz(int i = 0)
        {
            label6.Text = $"毫秒后开始第{ICount}次爬取";
            var date = System.DateTime.Now;
            string url = string.Format("{0}/date/{1}.html", StatTool.Url, date.ToString("yyyyMMdd"));
            var ds = StatTool.ABS(url, date);
            if (i > 0)
                MessageBox.Show($"{url} 已执行完成");
            return ds;
        }
        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("输入发生异常，Exception：{0}，StackTrace：{1}", ex.ToString(), ex.StackTrace));
            }
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("输入发生异常，Exception：{0}，StackTrace：{1}", ex.ToString(), ex.StackTrace));
            }
        }
        void EnabledFale()
        {
            btnStart.Enabled = false;
            btnSave.Enabled = false;
            btnImmed.Enabled = false;
            btnSavePath.Enabled = false;
            txtDay.Enabled = false;
            txtTime.Enabled = false;
            label5.Visible = false;
            label6.Visible = false;
        }
        void EnabledTrue()
        {
            btnStart.Enabled = true;
            btnSave.Enabled = true;
            btnImmed.Enabled = true;
            btnSavePath.Enabled = true;
            txtDay.Enabled = true;
            txtTime.Enabled = true;
            label5.Visible = true;
            label6.Visible = true;
            Thread.Sleep(1000);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            EnabledFale();
            Task.Factory.StartNew(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    txtDay.Enabled = false;
                    DataSet ds = new DataSet();
                    int day = Convert.ToInt32(txtDay.Text) + 1;
                    for (int i = 0; i < day; i++)
                    {
                        var currDay = System.DateTime.Now.AddDays(-i);
                        ds = StatTool.ABS(string.Format("{0}/date/{1}.html", StatTool.Url, currDay.ToString("yyyyMMdd")), currDay);
                        Thread.Sleep(5);
                    }
                    this.BeginInvoke(new MethodInvoker(delegate ()
                    {
                        dgvFinacial.DataSource = ds.Tables["财经数据"];
                        dgvFinads.DataSource = ds.Tables["财经大事件"];
                        txtPath.Text = Data.data.SetUp(StatTool.SavefilePath).Value;
                        txtTime.Text = Data.data.SetUp(StatTool.TimingInterval).Value;
                        label6.Text = $"毫秒后开始第{ICount}次爬取";
                        EnabledTrue();
                    }));
                    ICount++;
                    MessageBox.Show("抓取完成");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("抓取发生异常，Exception：{0}，StackTrace：{1}", ex.ToString(), ex.StackTrace));
                }
            });

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            try
            {
                Data.data.AddSetUp(new SetUP { Key = StatTool.TimingInterval, Value = txtTime.Text.Trim(), OperDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
                timer1.Stop();
                _ic = Cale(txtTime.Text);
                label5.Text = _ic.ToString();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("保存发生异常，Exception：{0}，StackTrace：{1}", ex.ToString(), ex.StackTrace));
            }
            MessageBox.Show("保存成功");
            btnSave.Enabled = true;
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                if (txtPath.Text != null && !string.IsNullOrEmpty(txtPath.Text) && !txtPath.Text.IsNull())
                    Data.data.AddSetUp(new SetUP { Key = StatTool.SavefilePath, Value = txtPath.Text, OperDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("路径选择发生异常，Exception：{0}，StackTrace：{1}", ex.ToString(), ex.StackTrace));
            }
        }

        private void btnImmed_Click(object sender, EventArgs e)
        {

            EnabledFale();
            Task.Factory.StartNew(() =>
            {
                var currDay = System.DateTime.Now;
                var ds = StatTool.ABS(string.Format("{0}/date/{1}.html", StatTool.Url, currDay.ToString("yyyyMMdd")), currDay);
                Thread.Sleep(1000);
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    EnabledTrue();
                    dgvFinacial.DataSource = ds.Tables["财经数据"];
                    dgvFinads.DataSource = ds.Tables["财经大事件"];
                    txtPath.Text = Data.data.SetUp(StatTool.SavefilePath).Value;
                    txtTime.Text = Data.data.SetUp(StatTool.TimingInterval).Value;
                    label6.Text = $"毫秒后开始第{ICount}次爬取";
                    label6.Text = $"毫秒后开始第{ICount}次爬取";

                }));
                MessageBox.Show("爬取成功");
            });
        }

        private void dgvFinacial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = dgvFinacial.Rows[e.RowIndex].Cells[10].Value.ToString();
            frmFinancial_History frm = new frmFinancial_History(id);
            frm.ShowDialog();
        }

        private void dgvFinacial_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow dgr = dgvFinacial.Rows[e.RowIndex];
            try
            {
                if (e.ColumnIndex == 2)
                {
                    e.CellStyle.ForeColor = Color.Blue;
                    e.CellStyle.Font = new Font("宋体", 12, FontStyle.Underline);
                    //e.CellStyle.BackColor = Color.Green;
                }
            }
            catch
            {

            }
        }
        private void dgvFinads_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                this.dgvFinads.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
        }
        private void dgvFinacial_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                this.dgvFinacial.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
        }
        string _ic;
        public string Ic
        {
            get
            {
                return _ic;
            }
            set
            {
                value = _ic;
            }
        }
        public int ICount = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            StartShowTime();
        }
        public void StartShowTime()
        {
            Thread threadShowTime = new Thread(new ThreadStart(() =>
            {
                label5.BeginInvoke(new MethodInvoker(() => StartTime()));
                Thread.Sleep(1000);
            }));
            threadShowTime.IsBackground = true;
            threadShowTime.Start();
        }
        void StartTime()
        {
            var lb = Convert.ToUInt64(string.IsNullOrEmpty(label5.Text) ? "0" : label5.Text);
            if (lb <= 0)
            {
                Pz();
                label5.Text = Ic.ToString();
            }
            else
            {
                label5.Text = Convert.ToString(lb - 1);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)//当用户点击窗体右上角X按钮或(Alt + F4)时 发生          
            {
                DialogResult dr = MessageBox.Show("是否进入右下角任务栏？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    e.Cancel = true;
                    this.ShowInTaskbar = false;
                    this.myIcon.Icon = this.Icon;
                    this.Hide();
                }
                else
                {
                    Application.Exit();
                }

            }
        }
        private void myIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                Activate();
                Visible = true;
                ShowInTaskbar = true;
            }
        }
        private void myIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                myMenu.Show();
            }
            if (e.Button == MouseButtons.Left)
            {
                WindowState = new Form1().WindowState;
                Visible = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #region
        //NotifyIcon notifyicon = new NotifyIcon();
        //ContextMenu notifyContextMenu = new ContextMenu();
        #endregion
        //private void Form1_SizeChanged(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        myIcon.Icon = this.Icon;
        //        this.ShowInTaskbar = false;
        //        notifyicon.Visible = true;
        //    }
        //}


    }
}
