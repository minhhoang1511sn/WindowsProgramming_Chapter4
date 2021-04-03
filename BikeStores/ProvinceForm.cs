using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeStores
{
    public partial class ProvinceForm : Form
    {
        public ProvinceForm()
        {
            InitializeComponent();
        }
        SalesDataContextDataContext db = null;
 
        private void MySetProvince()
        {
            var ProQ = from ProList in db.provinces
                        select ProList;
            dtGridView.DataSource = ProQ;
        }
        private void cbProv_SelectedValueChanged(object sender, EventArgs e)
        {
            MySetProvince();
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string tempDID = dtGridView.Rows[r].Cells[0].Value.ToString();
            district ProvQ = db.districts.Single(x => x.province_id == tempDID);
            ProvQ.district_id = txtPID.Text;
            ProvQ.district_name = txtPName.Text;
            db.SubmitChanges();
        }
        private void dtGridView_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtPID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtPName.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string tempDID = dtGridView.Rows[r].Cells[0].Value.ToString();
            province ProQ = db.provinces.Single(x => x.province_id == tempDID);
            db.provinces.DeleteOnSubmit(ProQ);
            db.SubmitChanges();
            MySetProvince();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            db.provinces.InsertOnSubmit(new province
            {
                province_id = txtPID.Text,
                province_name = txtPName.Text,
            });
            db.SubmitChanges();
            MySetProvince();

        }
        private void btReload_Click(object sender, EventArgs e)
        {
            MySetProvince();
        }

    }
}
