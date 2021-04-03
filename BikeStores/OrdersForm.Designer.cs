
namespace BikeStores
{
    partial class OrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersForm));
            this.dtGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btExit = new System.Windows.Forms.Button();
            this.btReload = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.grPanel = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtShipped_date = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtrequireddate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtxOrderdate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOrderstatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtStaffsID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStore_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustoID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGridView
            // 
            this.dtGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView.Location = new System.Drawing.Point(32, 274);
            this.dtGridView.Name = "dtGridView";
            this.dtGridView.RowHeadersWidth = 51;
            this.dtGridView.RowTemplate.Height = 24;
            this.dtGridView.Size = new System.Drawing.Size(736, 113);
            this.dtGridView.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btExit);
            this.groupBox2.Controls.Add(this.btReload);
            this.groupBox2.Controls.Add(this.btDelete);
            this.groupBox2.Controls.Add(this.btCancel);
            this.groupBox2.Controls.Add(this.btSave);
            this.groupBox2.Controls.Add(this.btEdit);
            this.groupBox2.Controls.Add(this.btAdd);
            this.groupBox2.Location = new System.Drawing.Point(32, 393);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(736, 44);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btExit.ForeColor = System.Drawing.SystemColors.Info;
            this.btExit.Location = new System.Drawing.Point(634, 15);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 23);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btReload
            // 
            this.btReload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btReload.ForeColor = System.Drawing.SystemColors.Info;
            this.btReload.Location = new System.Drawing.Point(530, 15);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 5;
            this.btReload.Text = "Reload";
            this.btReload.UseVisualStyleBackColor = false;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // btDelete
            // 
            this.btDelete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btDelete.ForeColor = System.Drawing.SystemColors.Info;
            this.btDelete.Location = new System.Drawing.Point(426, 15);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = false;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btCancel.ForeColor = System.Drawing.SystemColors.Info;
            this.btCancel.Location = new System.Drawing.Point(322, 15);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 3;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSave.ForeColor = System.Drawing.SystemColors.Info;
            this.btSave.Location = new System.Drawing.Point(218, 15);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 2;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = false;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btEdit
            // 
            this.btEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btEdit.ForeColor = System.Drawing.SystemColors.Info;
            this.btEdit.Location = new System.Drawing.Point(114, 15);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(75, 23);
            this.btEdit.TabIndex = 1;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = false;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btAdd
            // 
            this.btAdd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btAdd.ForeColor = System.Drawing.SystemColors.Info;
            this.btAdd.Location = new System.Drawing.Point(11, 15);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(75, 23);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = false;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // grPanel
            // 
            this.grPanel.Controls.Add(this.panel8);
            this.grPanel.Controls.Add(this.panel7);
            this.grPanel.Controls.Add(this.panel6);
            this.grPanel.Controls.Add(this.panel5);
            this.grPanel.Controls.Add(this.panel4);
            this.grPanel.Controls.Add(this.panel3);
            this.grPanel.Controls.Add(this.panel1);
            this.grPanel.Controls.Add(this.txtShipped_date);
            this.grPanel.Controls.Add(this.label10);
            this.grPanel.Controls.Add(this.txtrequireddate);
            this.grPanel.Controls.Add(this.label8);
            this.grPanel.Controls.Add(this.txtxOrderdate);
            this.grPanel.Controls.Add(this.label7);
            this.grPanel.Controls.Add(this.txtOrderstatus);
            this.grPanel.Controls.Add(this.label6);
            this.grPanel.Controls.Add(this.TxtStaffsID);
            this.grPanel.Controls.Add(this.label5);
            this.grPanel.Controls.Add(this.txtStore_ID);
            this.grPanel.Controls.Add(this.label4);
            this.grPanel.Controls.Add(this.txtCustoID);
            this.grPanel.Controls.Add(this.label3);
            this.grPanel.Location = new System.Drawing.Point(32, 60);
            this.grPanel.Name = "grPanel";
            this.grPanel.Size = new System.Drawing.Size(736, 208);
            this.grPanel.TabIndex = 9;
            this.grPanel.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel8.ForeColor = System.Drawing.SystemColors.Info;
            this.panel8.Location = new System.Drawing.Point(445, 172);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(201, 1);
            this.panel8.TabIndex = 34;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel7.ForeColor = System.Drawing.SystemColors.Info;
            this.panel7.Location = new System.Drawing.Point(445, 130);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(201, 1);
            this.panel7.TabIndex = 34;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel6.ForeColor = System.Drawing.SystemColors.Info;
            this.panel6.Location = new System.Drawing.Point(445, 87);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(201, 1);
            this.panel6.TabIndex = 34;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel5.ForeColor = System.Drawing.SystemColors.Info;
            this.panel5.Location = new System.Drawing.Point(442, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(201, 1);
            this.panel5.TabIndex = 34;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel4.ForeColor = System.Drawing.SystemColors.Info;
            this.panel4.Location = new System.Drawing.Point(114, 149);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(201, 1);
            this.panel4.TabIndex = 34;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel3.ForeColor = System.Drawing.SystemColors.Info;
            this.panel3.Location = new System.Drawing.Point(111, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 1);
            this.panel3.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.ForeColor = System.Drawing.SystemColors.Info;
            this.panel1.Location = new System.Drawing.Point(114, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 1);
            this.panel1.TabIndex = 33;
            // 
            // txtShipped_date
            // 
            this.txtShipped_date.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtShipped_date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtShipped_date.ForeColor = System.Drawing.SystemColors.Info;
            this.txtShipped_date.Location = new System.Drawing.Point(448, 156);
            this.txtShipped_date.Name = "txtShipped_date";
            this.txtShipped_date.Size = new System.Drawing.Size(198, 15);
            this.txtShipped_date.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(6, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Customers ID:";
            // 
            // txtrequireddate
            // 
            this.txtrequireddate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtrequireddate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtrequireddate.ForeColor = System.Drawing.SystemColors.Info;
            this.txtrequireddate.Location = new System.Drawing.Point(445, 116);
            this.txtrequireddate.Name = "txtrequireddate";
            this.txtrequireddate.Size = new System.Drawing.Size(198, 15);
            this.txtrequireddate.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(13, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Staff ID:";
            // 
            // txtxOrderdate
            // 
            this.txtxOrderdate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtxOrderdate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtxOrderdate.ForeColor = System.Drawing.SystemColors.Info;
            this.txtxOrderdate.Location = new System.Drawing.Point(445, 71);
            this.txtxOrderdate.Name = "txtxOrderdate";
            this.txtxOrderdate.Size = new System.Drawing.Size(198, 15);
            this.txtxOrderdate.TabIndex = 5;
            this.txtxOrderdate.TextChanged += new System.EventHandler(this.txtxOrderdate_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(13, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "store_id:";
            // 
            // txtOrderstatus
            // 
            this.txtOrderstatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtOrderstatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOrderstatus.ForeColor = System.Drawing.SystemColors.Info;
            this.txtOrderstatus.Location = new System.Drawing.Point(442, 30);
            this.txtOrderstatus.Name = "txtOrderstatus";
            this.txtOrderstatus.Size = new System.Drawing.Size(198, 15);
            this.txtOrderstatus.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(329, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Shipped_date:";
            // 
            // TxtStaffsID
            // 
            this.TxtStaffsID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TxtStaffsID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtStaffsID.ForeColor = System.Drawing.SystemColors.Info;
            this.TxtStaffsID.Location = new System.Drawing.Point(114, 135);
            this.TxtStaffsID.Name = "TxtStaffsID";
            this.TxtStaffsID.Size = new System.Drawing.Size(198, 15);
            this.TxtStaffsID.TabIndex = 3;
            this.TxtStaffsID.TextChanged += new System.EventHandler(this.TxtStaffsID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(328, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "required_date:";
            // 
            // txtStore_ID
            // 
            this.txtStore_ID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtStore_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStore_ID.ForeColor = System.Drawing.SystemColors.Info;
            this.txtStore_ID.Location = new System.Drawing.Point(114, 91);
            this.txtStore_ID.Name = "txtStore_ID";
            this.txtStore_ID.Size = new System.Drawing.Size(198, 15);
            this.txtStore_ID.TabIndex = 2;
            this.txtStore_ID.TextChanged += new System.EventHandler(this.txtStore_ID_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(344, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Order_date:";
            // 
            // txtCustoID
            // 
            this.txtCustoID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCustoID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCustoID.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCustoID.Location = new System.Drawing.Point(117, 47);
            this.txtCustoID.Name = "txtCustoID";
            this.txtCustoID.Size = new System.Drawing.Size(198, 15);
            this.txtCustoID.TabIndex = 1;
            this.txtCustoID.TextChanged += new System.EventHandler(this.txtCustoID_stt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(344, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Order_status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(391, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 43);
            this.label1.TabIndex = 8;
            this.label1.Text = "UPDATE  ORDERS LIST";
            // 
            // OrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtGridView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grPanel);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrdersForm";
            this.Text = "Nhập dữ liệu đơn hàng";
            this.Load += new System.EventHandler(this.OrdersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grPanel.ResumeLayout(false);
            this.grPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.GroupBox grPanel;
        private System.Windows.Forms.TextBox txtShipped_date;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtrequireddate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtxOrderdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOrderstatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtStaffsID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStore_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustoID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
    }
}