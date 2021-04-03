using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BikeStores
{
    public partial class BrandForm : Form
    {
        public BrandForm()
        {
            InitializeComponent();
        }

        string connstr = "Data Source =DESKTOP-BBMR07S ;Initial Catalog =Sales; Integrated Security = True";
        SqlConnection conn = null;

        SqlDataAdapter adBrand = null;

        DataTable dtBrand = null;

        bool Add = false;

        void ResetAllTextBox()
        {
            txtBrandname.ResetText();
        }

        void SetBtEdit_On()
        {
            btSave.Enabled = true;
            btCancel.Enabled = true;
            grPanel.Enabled = true;
            btAdd.Enabled = false;
            btEdit.Enabled = false;
            btDelete.Enabled = false;
            btExit.Enabled = false;
            dtGridView.Enabled = false;
        }

        void SetBtEdit_Off()
        {
            btSave.Enabled = false;
            btCancel.Enabled = false;
            grPanel.Enabled = false;
            btAdd.Enabled = true;
            btDelete.Enabled = true;
            btReload.Enabled = true;
            btExit.Enabled = true;
            dtGridView.Enabled = true;
            Add = false;
        }

        void LoadData()
        {
            ResetAllTextBox();
            SetBtEdit_Off();
            try
            {
                conn = new SqlConnection(connstr);
                adBrand = new SqlDataAdapter("SELECT * FROM  brands ", conn);
                dtBrand = new DataTable();
                adBrand.Fill(dtBrand);
                dtGridView.DataSource = dtBrand;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng brands ", "Lỗi dữ liệu!");
            }
        }


        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            ResetAllTextBox();
            SetBtEdit_On();
            txtBrandname.Focus();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_Click(null, null);
            SetBtEdit_On();
            txtBrandname.Focus();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtBrandname.Text.Trim().Equals(""))
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                if (Add)
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "INSERT INTO  brands  VALUES('" + txtBrandname.Text + "')";
                        cmd.ExecuteNonQuery();
                        LoadData();
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show(cmd.CommandText);
                    }
                }
                else
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dtGridView.CurrentCell.RowIndex;
                        string strBrandID = dtGridView.Rows[r].Cells[0].Value.ToString();
                        cmd.CommandText = "UPDATE  brands  SET " + " brand_name ='" + txtBrandname.Text + "'WHERE brand_name = '" + strBrandID + "'"; ;
                        cmd.ExecuteNonQuery();
                        LoadData();
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show(cmd.CommandText);
                    }
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Brand chưa có. Lỗi rồi!");
                txtBrandname.Focus();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.SetBtEdit_Off();
            ResetAllTextBox();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    int r = dtGridView.CurrentCell.RowIndex;
                    string BrandName = dtGridView.Rows[r].Cells[1].Value.ToString();
                    cmd.CommandText = "DELETE FROM  brands  WHERE brand_name='" + BrandName + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã xóa thành công Brand name =" + BrandName + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Brand hiện hành.");
                }
                finally
                {
                    conn.Close();
                }
            }
            SetBtEdit_Off();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult CheckExit = MessageBox.Show("Có muốn Exit không?", "Exit confirm!",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckExit == DialogResult.Yes) this.Close();
        }

        private void dtGridView_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            txtBrandname.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            btEdit.Enabled = true;
        }


        private void BrandForm_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
