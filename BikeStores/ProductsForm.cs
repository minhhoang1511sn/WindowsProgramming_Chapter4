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
    public partial class ProductsForm : Form
    {
        public ProductsForm()
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
            txtProductname.ResetText();
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
                adBrand = new SqlDataAdapter("SELECT * FROM  products ", conn);
                dtBrand = new DataTable();
                adBrand.Fill(dtBrand);
                dtGridView.DataSource = dtBrand;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng products ", "Lỗi dữ liệu!");
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Add = true;
            ResetAllTextBox();
            SetBtEdit_On();
            txtBrandId.Focus();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_Click(null, null);
            SetBtEdit_On();
            txtBrandId.Focus();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtlistprice.Text.Trim().Equals(""))
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
                        cmd.CommandText = "INSERT INTO products ( product_name, brand_id,category_id,model_year,list_price) VALUES ('"+ 
                            txtProductname.Text + "'," +Convert.ToInt32(txtBrandId.Text)+","
                            + Convert.ToInt32(textCataID.Text )+"," +Convert.ToInt16( txtModelyears.Text) +"," 
                            +Convert.ToDecimal( txtlistprice.Text)+ ")";
                        cmd.ExecuteNonQuery();
                        LoadData();
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi không chèn dữ liệu không hợp lệ!");
                    }
                }
                else
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        int r = dtGridView.CurrentCell.RowIndex;
                        string strProductID = dtGridView.Rows[r].Cells[0].Value.ToString();
                        cmd.CommandText = "UPDATE  products  SET "+ " brand_id ='" + txtBrandId.Text + " categories_id ='" + textCataID.Text + " product_name ='" + txtlistprice.Text + "'model_year ='"
                            +txtProductname+ "'list_price ='"+txtModelyears.Text+ "'WHERE product_name = '" + strProductID + "'"; ;
                        cmd.ExecuteNonQuery();
                        LoadData();
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi không cập nhật dữ liệu không hợp lệ!");
                    }
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("product chưa có. Lỗi rồi!");
                txtBrandId.Focus();
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
                    string BrandName = dtGridView.Rows[r].Cells[3].Value.ToString();
                    cmd.CommandText = "DELETE FROM  products  WHERE product_name='" + BrandName + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Đã xóa thành công Product name =" + BrandName + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Product hiện hành.");
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
            txtProductname.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
            txtlistprice.Text = dtGridView.Rows[r].Cells[5].Value.ToString();
            txtModelyears.Text = dtGridView.Rows[r].Cells[4].Value.ToString();
            textCataID.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtBrandId.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            btEdit.Enabled = true;
        }


        private void ProductsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtBrandId_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT brand_id FROM brands WHERE brand_id LIKE @brand_id", connection);
            command.Parameters.Add(new SqlParameter("@brand_id", "%" + txtBrandId.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetInt32(0).ToString());
            }
            txtBrandId.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void textCataID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT category_id FROM categories WHERE category_id LIKE @category_id", connection);
            command.Parameters.Add(new SqlParameter("@category_id", "%" + textCataID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetInt32(0).ToString());
            }
            textCataID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void grPanel_Enter(object sender, EventArgs e)
        {

        }

        private void txtlistprice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
