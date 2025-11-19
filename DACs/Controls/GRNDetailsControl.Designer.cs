namespace DACs.Controls
{
    partial class GRNDetailsControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSP = new System.Windows.Forms.ComboBox();
            this.cbMauSac = new System.Windows.Forms.ComboBox();
            this.cbKichCo = new System.Windows.Forms.ComboBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.Controls.Add(this.cbSP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbMauSac, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbKichCo, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDonGia, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtThanhTien, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudSoLuong, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(534, 40);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbSP
            // 
            this.cbSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSP.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSP.FormattingEnabled = true;
            this.cbSP.Location = new System.Drawing.Point(24, 4);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(188, 29);
            this.cbSP.TabIndex = 0;
            this.cbSP.SelectedIndexChanged += new System.EventHandler(this.cbSP_SelectedIndexChanged);
            // 
            // cbMauSac
            // 
            this.cbMauSac.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMauSac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMauSac.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbMauSac.FormattingEnabled = true;
            this.cbMauSac.Location = new System.Drawing.Point(219, 4);
            this.cbMauSac.Name = "cbMauSac";
            this.cbMauSac.Size = new System.Drawing.Size(42, 29);
            this.cbMauSac.TabIndex = 1;
            this.cbMauSac.SelectedIndexChanged += new System.EventHandler(this.cbMauSac_SelectedIndexChanged);
            // 
            // cbKichCo
            // 
            this.cbKichCo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKichCo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKichCo.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbKichCo.FormattingEnabled = true;
            this.cbKichCo.Location = new System.Drawing.Point(268, 4);
            this.cbKichCo.Name = "cbKichCo";
            this.cbKichCo.Size = new System.Drawing.Size(42, 29);
            this.cbKichCo.TabIndex = 2;
            this.cbKichCo.SelectedIndexChanged += new System.EventHandler(this.cbKichCo_SelectedIndexChanged);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDonGia.Enabled = false;
            this.txtDonGia.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDonGia.Location = new System.Drawing.Point(366, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(42, 29);
            this.txtDonGia.TabIndex = 4;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThanhTien.Enabled = false;
            this.txtThanhTien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtThanhTien.Location = new System.Drawing.Point(415, 4);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(52, 29);
            this.txtThanhTien.TabIndex = 5;
            this.txtThanhTien.TextChanged += new System.EventHandler(this.txtThanhTien_TextChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Tomato;
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(474, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(36, 32);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Xoá";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudSoLuong.Location = new System.Drawing.Point(317, 4);
            this.nudSoLuong.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(42, 29);
            this.nudSoLuong.TabIndex = 7;
            this.nudSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSoLuong.ValueChanged += new System.EventHandler(this.nudSoLuong_ValueChanged);
            // 
            // GRNDetailsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Name = "GRNDetailsControl";
            this.Size = new System.Drawing.Size(534, 40);
            this.Load += new System.EventHandler(this.GRNDetailsControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbSP;
        private System.Windows.Forms.ComboBox cbMauSac;
        private System.Windows.Forms.ComboBox cbKichCo;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
    }
}
