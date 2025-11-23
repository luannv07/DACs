namespace DACs.Controls
{
    partial class ucHomeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUsers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTodayOrder = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTodayCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnAddGRN = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rtbRecentActivities = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.BackColor = System.Drawing.Color.Transparent;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelUsers.Location = new System.Drawing.Point(320, 10);
            this.labelUsers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(321, 37);
            this.labelUsers.TabIndex = 1;
            this.labelUsers.Text = "TRANG CHỦ HỆ THỐNG";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(342, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chào mừng: Nguyễn Luận (Nhân viên)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Italic);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(535, 633);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "23/11/2025 9:42";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 1F);
            this.label3.Location = new System.Drawing.Point(116, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(729, 1);
            this.label3.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTodayOrder);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(203, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 100);
            this.panel1.TabIndex = 4;
            // 
            // txtTodayOrder
            // 
            this.txtTodayOrder.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTodayOrder.Location = new System.Drawing.Point(3, 50);
            this.txtTodayOrder.Name = "txtTodayOrder";
            this.txtTodayOrder.Size = new System.Drawing.Size(233, 30);
            this.txtTodayOrder.TabIndex = 3;
            this.txtTodayOrder.Text = "10";
            this.txtTodayOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(56, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "ĐƠN HÔM NAY";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTodayCost);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(516, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 100);
            this.panel2.TabIndex = 4;
            // 
            // txtTodayCost
            // 
            this.txtTodayCost.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTodayCost.Location = new System.Drawing.Point(3, 50);
            this.txtTodayCost.Name = "txtTodayCost";
            this.txtTodayCost.Size = new System.Drawing.Size(233, 30);
            this.txtTodayCost.TabIndex = 3;
            this.txtTodayCost.Text = "10";
            this.txtTodayCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(66, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "DOANH THU";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Location = new System.Drawing.Point(198, 297);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(175, 38);
            this.btnCreateOrder.TabIndex = 0;
            this.btnCreateOrder.Text = "[Tạo hoá đơn]";
            this.btnCreateOrder.UseVisualStyleBackColor = true;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(394, 297);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(175, 38);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "[Thêm sản phẩm]";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAddGRN
            // 
            this.btnAddGRN.Location = new System.Drawing.Point(590, 297);
            this.btnAddGRN.Name = "btnAddGRN";
            this.btnAddGRN.Size = new System.Drawing.Size(175, 38);
            this.btnAddGRN.TabIndex = 2;
            this.btnAddGRN.Text = "[Tạo phiếu nhập]";
            this.btnAddGRN.UseVisualStyleBackColor = true;
            this.btnAddGRN.Click += new System.EventHandler(this.btnAddGRN_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 1F);
            this.label7.Location = new System.Drawing.Point(116, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(729, 1);
            this.label7.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(131, 380);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "HOẠT ĐỘNG GẦN ĐÂY";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(131, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "THAO TÁC NHANH";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rtbRecentActivities
            // 
            this.rtbRecentActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbRecentActivities.Cursor = System.Windows.Forms.Cursors.Default;
            this.rtbRecentActivities.Location = new System.Drawing.Point(135, 414);
            this.rtbRecentActivities.Name = "rtbRecentActivities";
            this.rtbRecentActivities.ReadOnly = true;
            this.rtbRecentActivities.Size = new System.Drawing.Size(681, 96);
            this.rtbRecentActivities.TabIndex = 6;
            this.rtbRecentActivities.Text = "";
            // 
            // ucHomeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.rtbRecentActivities);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddGRN);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.btnCreateOrder);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUsers);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucHomeControl";
            this.Size = new System.Drawing.Size(960, 681);
            this.Load += new System.EventHandler(this.ucHomeControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnAddGRN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtTodayCost;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txtTodayOrder;
        private System.Windows.Forms.RichTextBox rtbRecentActivities;
    }
}
