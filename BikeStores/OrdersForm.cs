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
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối
        string connstr = "Data Source =DESKTOP-BBMR07S ;Initial Catalog =Sales; Integrated Security = True";
        //string connstr = "Data Source=(localdb)\mssqllocaldb;InitialCatalog=Sales;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào Data Table SqlStore
        SqlDataAdapter adOrder = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtOrder = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        // Phuong thuc dung chung
        void ResetAllTextBox()
        {
            txtShipped_date.ResetText();
            txtCustoID.ResetText();
            txtStore_ID.ResetText();
            TxtStaffsID.ResetText();
            txtOrderstatus.ResetText();
            txtrequireddate.ResetText();
            txtxOrderdate.ResetText();
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
                adOrder = new SqlDataAdapter("SELECT * FROM orders", conn);
                dtOrder = new DataTable();
                adOrder.Fill(dtOrder);
                dtGridView.DataSource = dtOrder;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng Order", "Lỗi dữ liệu!");
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
            txtCustoID.Focus();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_CellClick(null, null);
            SetBtEdit_On();
            txtCustoID.Focus();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtShipped_date.Text.Trim().Equals(""))
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
                        cmd.CommandText = "INSERT INTO orders (customer_id,order_status, order_date,required_date,shipped_date, store_id,staff_id) VALUES('" + txtCustoID.Text
                         +"',"+ Convert.ToInt32(txtOrderstatus.Text) + ",'" +Convert.ToDateTime(txtxOrderdate.Text)+ "','" +
                       Convert.ToDateTime(txtrequireddate.Text)+ "','" +Convert.ToDateTime(txtShipped_date.Text) + "','" + txtStore_ID.Text + "','" +
                        TxtStaffsID.Text + "')";
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
                        cmd.CommandText = "UPDATE INTO orders SET" +"order_id ='"
                        + "',customer_id='" + txtCustoID.Text+ "',store_id='" + txtStore_ID.Text+ "',staff_id='" +
                         TxtStaffsID.Text + "',order_status='" + txtOrderstatus.Text + "',order_date='" +  txtxOrderdate.Text + "',required_date='" +
                        txtrequireddate.Text + "',shipped_date='" + txtShipped_date.Text +
                         "')";
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
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!");
                txtCustoID.Focus();
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
                    string OrderID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    // Lệnh truy vấn SQL
                    cmd.CommandText = "DELETE FROM orders WHERE order_id='" + OrderID +
                   "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công OrderID =" + OrderID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Orders hiện hành.");
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
            txtCustoID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtStore_ID.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            TxtStaffsID.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtOrderstatus.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
            txtxOrderdate.Text = dtGridView.Rows[r].Cells[4].Value.ToString();
            txtrequireddate.Text = dtGridView.Rows[r].Cells[5].Value.ToString();
            txtShipped_date.Text = dtGridView.Rows[r].Cells[6].Value.ToString();
            btEdit.Enabled = true;
        }


        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        
        private void txtCustoID_stt_TextChanged(object sender, EventArgs e)
            {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT customer_id FROM customers WHERE customer_id LIKE @customer_id", connection);
            command.Parameters.Add(new SqlParameter("@customer_id", "%" + txtCustoID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            txtCustoID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void txtStore_ID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT store_id FROM stores WHERE store_id LIKE @store_id", connection);
            command.Parameters.Add(new SqlParameter("@store_id", "%" + txtStore_ID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            txtStore_ID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void TxtStaffsID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT staff_id FROM staffs WHERE staff_id LIKE @staff_id", connection);
            command.Parameters.Add(new SqlParameter("@staff_id", "%" + TxtStaffsID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            TxtStaffsID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void txtxOrderdate_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
