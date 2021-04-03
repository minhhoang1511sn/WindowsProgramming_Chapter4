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
    public partial class CommuneForm : Form
    {
        public CommuneForm()
        {
            InitializeComponent();
        }
        SalesDataContextDataContext db = null;
        private void MySetProvince()
        {
            db = new SalesDataContextDataContext();
            var DisQ = from DisList in db.districts select DisList.district_name;
            foreach (string DisName in DisQ)
            {
                cbDist.Items.Add(DisName);
            }
            cbDist.SelectedIndex = 0;
        }
        private void MySetCommune()
        {
            var DistQ = from ComList in db.communes
                        join DisList in db.districts on ComList.district_id equals
                       DisList.district_id
                        where (DisList.district_name == cbDist.Text)
                        select ComList;
            dtGridView.DataSource = DistQ;
        }
        private void CommuneForm_Load(object sender, EventArgs e)
        {
            MySetProvince();
        }
        private void cbProv_SelectedValueChanged(object sender, EventArgs e)
        {
            MySetCommune();
        }
        private void cbProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string tempCID = dtGridView.Rows[r].Cells[0].Value.ToString();
            commune ComQ = db.communes.Single(x => x.commune_id == tempCID);
            ComQ.district_id = txtDID.Text;
            ComQ.commune_id = txtCID.Text;
            ComQ.commune_name = txtCName.Text;
            ComQ.degree = Convert.ToInt32(txtDegree.Text);
            db.SubmitChanges();
        }
        private void dtGridView_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtDID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtCID.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtCName.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtDegree.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string tempDID = dtGridView.Rows[r].Cells[0].Value.ToString();
            district DistQ = db.districts.Single(x => x.district_id == tempDID);
            db.districts.DeleteOnSubmit(DistQ);
            db.SubmitChanges();
            MySetCommune();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            db.communes.InsertOnSubmit(new commune
            {
                district_id = txtDID.Text,
                commune_name = txtCName.Text,
                commune_id = txtCName.Text,
                degree= Convert.ToInt32(txtDegree.Text)
        }) ;
            db.SubmitChanges();
            MySetCommune();

        }
        private void btReload_Click(object sender, EventArgs e)
        {
            MySetProvince();
        }

        private void grPanel_Enter(object sender, EventArgs e)
        {

        }

        private void dtGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
