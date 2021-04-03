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
using System.Data.OleDb;

namespace BikeStores
{
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }
        // Chuỗi kết nối
        string connstr = "Data Source =DESKTOP-BBMR07S ;Initial Catalog =Sales; Integrated Security = True";
        //string connstr = "Data Source=(localdb)\mssqllocaldb;InitialCatalog=Sales;Integrated Security = True";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào Data Table SqlStore
        SqlDataAdapter adStaff = null;
        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtStaff = null;
        // Khai báo biến kiểm tra việc Thêm hay Sửa dữ liệu
        bool Add = false;
        // Phuong thuc dung chung
        void ResetAllTextBox()
        {
            txtStaffID.ResetText();
            txtManagerID.ResetText();
            txtxFname.ResetText();
            txtPhone.ResetText();
            txtLname.ResetText();
            txtStoreID.ResetText();
            txtEmail.ResetText();
            txtActive.ResetText();
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
                adStaff = new SqlDataAdapter("SELECT * FROM staffs", conn);
                dtStaff = new DataTable();
                adStaff.Fill(dtStaff);
                dtGridView.DataSource = dtStaff;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng Staff", "Lỗi dữ liệu!");
            }
        }
        void CheckStaffsIDExit()
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
                // Lệnh kiem tra nhan vien ton tai ?
                cmd.CommandText = "SELECT Count(*) FROM staffs WHERE staff_id = '" +
               txtStaffID.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("StaffID (" + txtStaffID.Text.Trim() + ") đã có. Nhập lại!");
                    txtStaffID.ResetText();
                    txtStaffID.Focus();
                }
                else
                {
                    txtManagerID.Focus();
                    txtxFname.Focus();
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
        void CheckStaffsNameExit()
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
                // Lệnh kiem tra nhân viên ton tai ?
                cmd.CommandText = "SELECT Count(*) FROM staffs WHERE last_name = '" +
               txtLname.Text.Trim()+ "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("Lastname ("  + txtLname.Text.Trim() + ") đã có.  Nhập lại!");

                    txtLname.ResetText();
                    txtLname.Focus();
                }
                else
                {
                    txtPhone.Focus();
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
            txtStaffID.Focus();
        }
        private void btEdit_Click(object sender, EventArgs e)
        {
            Add = false;
            dtGridView_CellClick(null, null);
            SetBtEdit_On();
            txtStaffID.Focus();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (!txtStaffID.Text.Trim().Equals(""))
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
                        cmd.CommandText = "INSERT INTO staffs VALUES('" + txtStaffID.Text
                    + "','" + txtxFname.Text + "','" + txtLname.Text + "','" + txtPhone.Text + "','" +
                    txtEmail.Text + "','" +Convert.ToInt32( txtActive.Text) + "','" + txtStoreID.Text +
                    "','" + txtManagerID.Text  + "')";
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã thêm dữ liệu thành công!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi chèn dữ liệu không hợp lệ!");
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
                        string strStaffsID =
                       dtGridView.Rows[r].Cells[0].Value.ToString();
                        // Câu lệnh SQL
                        cmd.CommandText = "UPDATE staffs SET " + "staff_id='" +
                        txtStaffID.Text + "', first_name='" + txtxFname.Text+ "',last_name = '  " + txtLname.Text + "',email ='" +
                        txtEmail.Text + "',phone ='" + txtPhone.Text + "', active = " +
                        Convert.ToInt32(txtActive.Text) + ",storeID ='" + txtStoreID.Text + "', ManagerID='" +
                         txtManagerID.Text+ "'  WHERE staff_id = '" + strStaffsID + "'";
                        // Cập nhật
                        cmd.ExecuteNonQuery();
                        // Load lại dữ liệu trên DataGridView
                        LoadData();
                        // Thông báo
                        MessageBox.Show("Đã sửa xong!");
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Lỗi cập nhật dữ liệu không hợp lệ!");// "Không sửa được. Lỗi rồi!");
                    }
                }
                // Đóng kết nối
                conn.Close();
            }
            else
            {
                MessageBox.Show("Nhân viên chưa có. Lỗi rồi!");
                txtStaffID.Focus();
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
                    string StaffID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    // Lệnh truy vấn SQL
                    cmd.CommandText = "DELETE FROM staffs WHERE staff_id='" + StaffID +
                   "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công StaffID =" + StaffID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Staff hiện hành.");
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
            txtStaffID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtManagerID.Text = dtGridView.Rows[r].Cells[7].Value.ToString();
            txtxFname.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtLname.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtPhone.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
            txtEmail.Text = dtGridView.Rows[r].Cells[4].Value.ToString();
            txtStoreID.Text = dtGridView.Rows[r].Cells[6].Value.ToString();
            txtActive.Text = dtGridView.Rows[r].Cells[5].Value.ToString();
            btEdit.Enabled = true;
        }
        private void dtGridView_CellContentClick(object sender,
       DataGridViewCellEventArgs e)
        {
        }
        private void grPanel_Enter(object sender, EventArgs e)
        {

        }

        private void StaffForm_Load(object sender, EventArgs e)
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
            SqlCommand command = new SqlCommand("SELECT store_id FROM stores WHERE store_id LIKE @store_id",connection);
            command.Parameters.Add(new SqlParameter("@store_id", "%" + txtStoreID.Text + "%"));
            command.ExecuteNonQuery();
            dr=command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while(dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            txtStoreID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void txtManagerID_TextChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            connection.Open();
            SqlDataReader dr;
            SqlCommand command = new SqlCommand("SELECT staff_id FROM staffs WHERE staff_id LIKE @manager_id", connection);
            command.Parameters.Add(new SqlParameter("@manager_id", "%" + txtManagerID.Text + "%"));
            command.ExecuteNonQuery();
            dr = command.ExecuteReader();
            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                col.Add(dr.GetString(0));
            }
            txtManagerID.AutoCompleteCustomSource = col;
            connection.Close();
        }

        private void txtActive_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

