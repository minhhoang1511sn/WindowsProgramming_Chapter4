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
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối
        string connstr = "Data Source =DESKTOP-BBMR07S ;Initial Catalog =Sales; Integrated Security = True";
        //string connstr = "Data Source=(localdb)\mssqllocaldb;InitialCatalog=Sales;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào Data Table SqlStore
        SqlDataAdapter adStock = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtStock = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        // Phuong thuc dung chung
        void ResetAllTextBox()
        {
            txtQuanity.ResetText();
            txtProductsID.ResetText();
            txtStoreID.ResetText();
        }
        void SetBtEdit_On()
        {
            btSave.Enabled = true;
            btCancel.Enabled = true;
            grPanel.Enabled = true;
            // Enable các control Add, Edit, Delete, Exit...
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
            // Enable các control Add, Edit, Delete, Exit...
            btAdd.Enabled = true;
            //btEdit.Enabled = true;
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
            // Không kích hoạt các control Save, Cancel, Panel chưa các text
            //Tạo kết nối
            try
            {
                conn = new SqlConnection(connstr);
                adStock = new SqlDataAdapter("SELECT * FROM stocks", conn);
                dtStock = new DataTable();
                adStock.Fill(dtStock);
                dtGridView.DataSource = dtStock;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng stocks", "Lỗi dữ liệu!");
            }
        }
        void CheckStockIDExit()
        {
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                // Thực hiện lệnh
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh kiem tra thanh pho ton tai ?
                cmd.CommandText = "SELECT Count(*) FROM stocks WHERE store_id = '" +
               txtStoreID.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("StoreID (" + txtStoreID.Text.Trim() + ") đã có. Nhập lại!");

                    txtStoreID.ResetText();
                    txtStoreID.Focus();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu!");
            }
            finally
            {
                conn.Close();
            }
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            // Kich hoạt biến Them
            Add = true;
            // Xóa trống các đối tượng trong Panel
            ResetAllTextBox();
            // Kích hoạt chế độ nhập/sửa dữ liệu
            SetBtEdit_On();
            // Đưa con trỏ đến đầu TextBox Stores ID
            txtStoreID.Focus();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_CellClick(null, null);
            SetBtEdit_On();
            txtStoreID.Focus();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtStoreID.Text.Trim().Equals(""))
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                if (Add) // Thêm dữ liệu
                {
                    try
                    {
                        // Thực hiện lệnh
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        // Lệnh Insert InTo
                        cmd.CommandText = "INSERT INTO stocks(store_id,product_id, quantity)VALUES('" + txtStoreID.Text
                        + "'," +Convert.ToInt32( txtProductsID.Text) + "," +Convert.ToInt32( txtQuanity.Text) +")";
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi không chèn dữ liệu không hợp lệ!");
                    }
                }
                else // sua doi
                {
                    try
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        // Thứ tự dòng hiện hành
                        int r = dtGridView.CurrentCell.RowIndex;// MaKH hiện hành
                        string strStoreID =
                       dtGridView.Rows[r].Cells[0].Value.ToString();
                        // Câu lệnh SQL
                        cmd.CommandText = "UPDATE stocks SET " + "',storeID ='"+
                        txtStoreID.Text + "',product_id="  + txtProductsID.Text + ", quanity=" +
                        txtQuanity.Text;
                        // Cập nhật
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi không cập nhật dữ liệu không hợp lệ!");// "Không sửa được. Lỗi rồi!");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                MessageBox.Show("Stock chưa có. Lỗi rồi!");
                txtStoreID.Focus();
            }
        }
        private void btCancel_Click(object sender, EventArgs e)
        {
            this.SetBtEdit_Off();
            ResetAllTextBox();
        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra User có muốn xóa hàng dữ liệu
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy Row hiện tại
                    int r = dtGridView.CurrentCell.RowIndex;
                    // Store_ID của record hiện hành
                    string StoreID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    // Lệnh truy vấn SQL
                    cmd.CommandText = "DELETE FROM stocks WHERE store_id='" + StoreID +
                   "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công StoreID =" + StoreID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Stock hiện hành.");
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
        private void dtGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy Row hiện tại
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtProductsID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtStoreID.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtQuanity.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            btEdit.Enabled = true;
        }
        private void dtGridView_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
        }

        private void txtQuanity_TextChanged(object sender, EventArgs e)
        {

        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtStoreID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT store_id FROM stores WHERE store_id LIKE @store_id", connection);
            command.Parameters.Add(new SqlParameter("@store_id", "%" + txtStoreID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            txtStoreID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void txtProductsID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT product_id FROM products WHERE product_id LIKE @product_id", connection);
            command.Parameters.Add(new SqlParameter("@product_id", "%" + txtProductsID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetInt32(0).ToString());
            }
            txtProductsID.AutoCompleteCustomSource = col;
            connection.Close();
        }
    }
}
