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
    public partial class LoginForm : Form
    {
        public bool temp = true;
        public delegate void check(bool hoanthanh);
        public check kiemtra;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BBMR07S;Initial Catalog=sales;Integrated Security=True   ");
        private string getID()
         {
             string id = "";
             try {
                 con.Open();
                 SqlCommand cmd =  new SqlCommand("select * from _USER where _USER1= '" +txtUser.Text+ "'AND PASSWORD='"+txtpass.Text+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill( dt);
                if(dt!=null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["_USER1"].ToString();

                    }
                }

             }
             catch(Exception)
             {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                con.Close();
            }
             return id;
         }
        public LoginForm()
        {
            InitializeComponent();
        }
        public static string ID_user = "";
        public void btndangnhap_Click(object sender, EventArgs e)
        {
            ID_user = getID();
            if(ID_user!="")
            {
                kiemtra(temp);
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi Tài khoản hoăc mật khẩu!");
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btndangnhap.PerformClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
