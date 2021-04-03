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
    public partial class HDMDIForm : Form
    {
        
        public void getvalue(bool t)
        {
            quanlyDanhMucToolStripMenuItem.Enabled = t;
            quanlydonToolStripMenuItem.Enabled = t;
            baocaoToolStripMenuItem1.Enabled = t;
        }

        public HDMDIForm()
        {
            InitializeComponent();
        }

        public void HDMDIForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            turnoff();
        }
       
        public void turnoff()
        {
            quanlyDanhMucToolStripMenuItem.Enabled = false;
            quanlydonToolStripMenuItem.Enabled = false;
            baocaoToolStripMenuItem1.Enabled = false;
        }

        private void menustripHeThong_Click(object sender, EventArgs e)
        {
            
        }

  
        private void brandListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BrandForm Bf = new BrandForm();
            Bf.Show();
            
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CatagoriesForm Bf = new CatagoriesForm();
            Bf.Show();
        }

        private void storeListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StoreForm Bf = new StoreForm();
            Bf.Show();
        }

        private void staffsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CustomerForm Cf = new CustomerForm();
            Cf.Show();
        }

        private void stateProviceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StaffForm SF = new StaffForm();
            SF.Show();
        }

        private void stateProvinceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cityListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

      

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OrdersForm OdF = new OrdersForm();
            OdF.Show();
        }

        private void productsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ProductsForm PrF = new ProductsForm();
            PrF.Show();
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {

            StockForm StF = new StockForm();
            StF.Show();
        }

        private void ordersitemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Orders_itemsForm Ordit = new Orders_itemsForm();
            Ordit.Show();
        }

        private void baoCaoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void quanlydonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quanlydanhmucToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dangnhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            LoginForm Lg = new LoginForm();
            Lg.kiemtra = new LoginForm.check(getvalue);
            Lg.ShowDialog();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void HDMDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông Báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(quanlyDanhMucToolStripMenuItem.Enabled == false)
            {
                MessageBox.Show("Bạn chưa đăng nhập!");
            }
            else if (MessageBox.Show("Bạn có thật sự muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                getvalue(false);
            }
        }

        private void hethongToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void quanlyDanhMucToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void hethongToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void quanlyDanhMucToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
           
        }
    }
}
