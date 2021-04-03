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
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối
        string connstr = "Data Source =DESKTOP-BBMR07S ;Initial Catalog =Sales; Integrated Security = True";
        //string connstr = "Data Source=(localdb)\mssqllocaldb;InitialCatalog=Sales;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào Data Table SqlStore
        SqlDataAdapter adCustomer = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtCustomer = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        // Phuong thuc dung chung
        void ResetAllTextBox()
        {
            txtCusID.ResetText();
            txtZipcode.ResetText();
            txtFName.ResetText();
            txtPhone.ResetText();
            txtLname.ResetText();
            txtEmail.ResetText();
            txtStreet.ResetText();
            txtCity.ResetText();
            txtState.ResetText();
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
                adCustomer = new SqlDataAdapter("SELECT * FROM customers", conn);
                dtCustomer = new DataTable();
                adCustomer.Fill(dtCustomer);
                dtGridView.DataSource = dtCustomer;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng customers", "Lỗi dữ liệu!");
            }
        }
        void CheckCustomersIDExit()
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
                cmd.CommandText = "SELECT Count(*) FROM customers WHERE customer_id = '" +
               txtCusID.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("CustomerID (" + txtCusID.Text.Trim() + ") đã có. Nhập lại!");

                    txtCusID.ResetText();
                    txtCusID.Focus();
                }
                else
                {
                    txtFName.Focus();
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
        void CheckCustomerNameExit()
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
                cmd.CommandText = "SELECT Count(*) FROM customers WHERE first_name = '" +txtZipcode.Text.Trim()+"'"+txtFName.Text+"'"+
               txtFName.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("Customers name (" + txtZipcode.Text.Trim() +
               txtFName.Text.Trim() + ") đã có.  Nhập lại!");
                    txtZipcode.ResetText();
                    txtZipcode.Focus();
                    txtFName.ResetText();
                    txtFName.Focus();
                }
                else
                {
                    txtLname.Focus();
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
            txtCusID.Focus();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_CellClick(null, null);
            SetBtEdit_On();
            txtCusID.Focus();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtCusID.Text.Trim().Equals(""))
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
                        cmd.CommandText = "INSERT INTO customers VALUES('" +
                        txtCusID.Text + "','" + txtFName.Text + "','" + txtLname.Text + "','" +
                        txtPhone.Text + "','" + txtEmail.Text + "','" +
                        txtStreet.Text + "','" + txtCity.Text + "','" +
                         txtState.Text + "','" + txtZipcode.Text + "')";
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show(cmd.CommandText);
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
                        string strCustomerID =
                       dtGridView.Rows[r].Cells[0].Value.ToString();
                        // Câu lệnh SQL
                        cmd.CommandText = "UPDATE customers SET " + "customer_id='" +
                        txtCusID.Text + "', first_name='" + txtFName.Text+ "',last_name='" + txtLname.Text + "',phone ='" +
                        txtPhone.Text + "',email ='" + txtEmail.Text + "', street='" +
                        txtStreet.Text + "',city ='" + txtCity.Text + "', state='" +
                         txtState.Text + "',zip_code='" + txtZipcode.Text + "'  WHERE customer_id = '" + strCustomerID + "'";
                        // Cập nhật
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show(cmd.CommandText);// "Không sửa được. Lỗi rồi!");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                MessageBox.Show("Thành phố chưa có. Lỗi rồi!");
                txtCusID.Focus();
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
                    string customerID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    // Lệnh truy vấn SQL
                    cmd.CommandText = "DELETE FROM customers WHERE customer_id='" + customerID +
                   "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công CustomerID =" + customerID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Customer hiện hành.");
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
            txtCusID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtZipcode.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtFName.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtLname.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtPhone.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dtGridView.Rows[r].Cells[4].Value.ToString();
            txtStreet.Text = dtGridView.Rows[r].Cells[5].Value.ToString();
            txtCity.Text = dtGridView.Rows[r].Cells[6].Value.ToString();
            txtState.Text = dtGridView.Rows[r].Cells[7].Value.ToString();
            btEdit.Enabled = true;
        }
        private void dtGridView_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grPanel_Enter_1(object sender, EventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
