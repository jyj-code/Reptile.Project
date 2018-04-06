using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reptile.Project
{
    public partial class frmFinancial_History : Form
    {
        public frmFinancial_History(string id)
        {
            InitializeComponent();
            dgvHistory.DataSource = Data.data.Financial_HistoryList(id);
            dgvHistory.Columns["ID"].Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.dgvHistory.RowsAdded += new DataGridViewRowsAddedEventHandler(dgvHistory_RowsAdded);
        }
        
        private void dgvHistory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
                this.dgvHistory.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
        }

    }
}
