namespace DACs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMenuCustomer = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.btnMenuAccount = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnMenuReport = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnMenuSupplier = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnMenuProduct = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnMenuSale = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMenuHome = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtHelloUser = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.DarkCyan;
            this.panelSidebar.Controls.Add(this.panelMenu);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.txtHelloUser);
            this.panelSidebar.Controls.Add(this.picLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(224, 681);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.DarkCyan;
            this.panelMenu.Controls.Add(this.btnMenuCustomer);
            this.panelMenu.Controls.Add(this.textBox7);
            this.panelMenu.Controls.Add(this.btnMenuAccount);
            this.panelMenu.Controls.Add(this.textBox6);
            this.panelMenu.Controls.Add(this.btnMenuReport);
            this.panelMenu.Controls.Add(this.textBox5);
            this.panelMenu.Controls.Add(this.btnMenuSupplier);
            this.panelMenu.Controls.Add(this.textBox3);
            this.panelMenu.Controls.Add(this.btnMenuProduct);
            this.panelMenu.Controls.Add(this.textBox2);
            this.panelMenu.Controls.Add(this.btnMenuSale);
            this.panelMenu.Controls.Add(this.textBox1);
            this.panelMenu.Controls.Add(this.btnMenuHome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 119);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(15);
            this.panelMenu.Size = new System.Drawing.Size(224, 508);
            this.panelMenu.TabIndex = 4;
            // 
            // btnMenuCustomer
            // 
            this.btnMenuCustomer.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCustomer.Enabled = false;
            this.btnMenuCustomer.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuCustomer.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuCustomer.Image")));
            this.btnMenuCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuCustomer.Location = new System.Drawing.Point(15, 435);
            this.btnMenuCustomer.Name = "btnMenuCustomer";
            this.btnMenuCustomer.Size = new System.Drawing.Size(194, 55);
            this.btnMenuCustomer.TabIndex = 14;
            this.btnMenuCustomer.Text = "Khách hàng";
            this.btnMenuCustomer.UseVisualStyleBackColor = false;
            this.btnMenuCustomer.Click += new System.EventHandler(this.btnMenuCustomer_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.Teal;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(15, 420);
            this.textBox7.Margin = new System.Windows.Forms.Padding(0);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.ShortcutsEnabled = false;
            this.textBox7.Size = new System.Drawing.Size(194, 15);
            this.textBox7.TabIndex = 13;
            this.textBox7.TabStop = false;
            // 
            // btnMenuAccount
            // 
            this.btnMenuAccount.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAccount.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuAccount.Image")));
            this.btnMenuAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuAccount.Location = new System.Drawing.Point(15, 365);
            this.btnMenuAccount.Name = "btnMenuAccount";
            this.btnMenuAccount.Size = new System.Drawing.Size(194, 55);
            this.btnMenuAccount.TabIndex = 12;
            this.btnMenuAccount.Text = "Nhân viên";
            this.btnMenuAccount.UseVisualStyleBackColor = false;
            this.btnMenuAccount.Click += new System.EventHandler(this.btnMenuAccount_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Teal;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(15, 350);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.ShortcutsEnabled = false;
            this.textBox6.Size = new System.Drawing.Size(194, 15);
            this.textBox6.TabIndex = 11;
            this.textBox6.TabStop = false;
            // 
            // btnMenuReport
            // 
            this.btnMenuReport.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuReport.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuReport.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuReport.Image")));
            this.btnMenuReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuReport.Location = new System.Drawing.Point(15, 295);
            this.btnMenuReport.Name = "btnMenuReport";
            this.btnMenuReport.Size = new System.Drawing.Size(194, 55);
            this.btnMenuReport.TabIndex = 10;
            this.btnMenuReport.Text = "Thống kê";
            this.btnMenuReport.UseVisualStyleBackColor = false;
            this.btnMenuReport.Click += new System.EventHandler(this.btnMenuReport_Click);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Teal;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(15, 280);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.ShortcutsEnabled = false;
            this.textBox5.Size = new System.Drawing.Size(194, 15);
            this.textBox5.TabIndex = 9;
            this.textBox5.TabStop = false;
            // 
            // btnMenuSupplier
            // 
            this.btnMenuSupplier.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSupplier.Enabled = false;
            this.btnMenuSupplier.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuSupplier.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuSupplier.Image")));
            this.btnMenuSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSupplier.Location = new System.Drawing.Point(15, 225);
            this.btnMenuSupplier.Name = "btnMenuSupplier";
            this.btnMenuSupplier.Size = new System.Drawing.Size(194, 55);
            this.btnMenuSupplier.TabIndex = 8;
            this.btnMenuSupplier.Text = "Mua hàng";
            this.btnMenuSupplier.UseVisualStyleBackColor = false;
            this.btnMenuSupplier.Click += new System.EventHandler(this.btnMenuSupplier_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Teal;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(15, 210);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.ShortcutsEnabled = false;
            this.textBox3.Size = new System.Drawing.Size(194, 15);
            this.textBox3.TabIndex = 5;
            this.textBox3.TabStop = false;
            // 
            // btnMenuProduct
            // 
            this.btnMenuProduct.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuProduct.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuProduct.Image")));
            this.btnMenuProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuProduct.Location = new System.Drawing.Point(15, 155);
            this.btnMenuProduct.Name = "btnMenuProduct";
            this.btnMenuProduct.Size = new System.Drawing.Size(194, 55);
            this.btnMenuProduct.TabIndex = 4;
            this.btnMenuProduct.Text = "Sản phẩm";
            this.btnMenuProduct.UseVisualStyleBackColor = false;
            this.btnMenuProduct.Click += new System.EventHandler(this.btnMenuProduct_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Teal;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(15, 140);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(194, 15);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            // 
            // btnMenuSale
            // 
            this.btnMenuSale.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuSale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuSale.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuSale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuSale.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuSale.Image")));
            this.btnMenuSale.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuSale.Location = new System.Drawing.Point(15, 85);
            this.btnMenuSale.Name = "btnMenuSale";
            this.btnMenuSale.Size = new System.Drawing.Size(194, 55);
            this.btnMenuSale.TabIndex = 2;
            this.btnMenuSale.Text = "Bán hàng";
            this.btnMenuSale.UseVisualStyleBackColor = false;
            this.btnMenuSale.Click += new System.EventHandler(this.btnMenuSale_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Teal;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(15, 70);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(194, 15);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            // 
            // btnMenuHome
            // 
            this.btnMenuHome.BackColor = System.Drawing.Color.LightYellow;
            this.btnMenuHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuHome.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnMenuHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenuHome.Image = ((System.Drawing.Image)(resources.GetObject("btnMenuHome.Image")));
            this.btnMenuHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuHome.Location = new System.Drawing.Point(15, 15);
            this.btnMenuHome.Name = "btnMenuHome";
            this.btnMenuHome.Size = new System.Drawing.Size(194, 55);
            this.btnMenuHome.TabIndex = 0;
            this.btnMenuHome.Text = "Trang chủ";
            this.btnMenuHome.UseVisualStyleBackColor = false;
            this.btnMenuHome.Click += new System.EventHandler(this.btnMenuHome_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(100, 629);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(109, 35);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtHelloUser
            // 
            this.txtHelloUser.AutoSize = true;
            this.txtHelloUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHelloUser.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHelloUser.ForeColor = System.Drawing.Color.White;
            this.txtHelloUser.Location = new System.Drawing.Point(0, 79);
            this.txtHelloUser.Name = "txtHelloUser";
            this.txtHelloUser.Padding = new System.Windows.Forms.Padding(15, 15, 15, 0);
            this.txtHelloUser.Size = new System.Drawing.Size(217, 40);
            this.txtHelloUser.TabIndex = 2;
            this.txtHelloUser.Text = "Xin chào, Username";
            this.txtHelloUser.Click += new System.EventHandler(this.txtHelloUser_Click);
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.ImageLocation = "";
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(224, 79);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.panelContent.Location = new System.Drawing.Point(224, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(960, 681);
            this.panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán hàng Yody";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label txtHelloUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMenuHome;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button btnMenuAccount;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnMenuReport;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnMenuSupplier;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnMenuProduct;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnMenuSale;
        private System.Windows.Forms.Button btnMenuCustomer;
    }
}

