namespace DACs.Forms.StoreForms
{
    partial class ViewGRN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewGRN));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTotalCost = new System.Windows.Forms.Label();
            this.labelUsers = new System.Windows.Forms.Label();
            this.txtCurrentPN = new System.Windows.Forms.TextBox();
            this.txtSupplierCode = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvGRNDetails = new System.Windows.Forms.DataGridView();
            this.txtCurrentUser = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateAdd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSuppliers = new System.Windows.Forms.ComboBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGRNDetails)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.txtTotalCost);
            this.panel3.Controls.Add(this.labelUsers);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 55);
            this.panel3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 0.01F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(1008, 1);
            this.textBox2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(908, 9);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 37);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.AutoSize = true;
            this.txtTotalCost.BackColor = System.Drawing.Color.Transparent;
            this.txtTotalCost.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.txtTotalCost.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtTotalCost.Location = new System.Drawing.Point(116, 9);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Padding = new System.Windows.Forms.Padding(5);
            this.txtTotalCost.Size = new System.Drawing.Size(45, 35);
            this.txtTotalCost.TabIndex = 2;
            this.txtTotalCost.Text = "0đ";
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.BackColor = System.Drawing.SystemColors.HotTrack;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.labelUsers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelUsers.Location = new System.Drawing.Point(3, 9);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Padding = new System.Windows.Forms.Padding(5);
            this.labelUsers.Size = new System.Drawing.Size(116, 35);
            this.labelUsers.TabIndex = 2;
            this.labelUsers.Text = "Thành tiền:";
            // 
            // txtCurrentPN
            // 
            this.txtCurrentPN.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtCurrentPN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCurrentPN.Enabled = false;
            this.txtCurrentPN.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCurrentPN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCurrentPN.Location = new System.Drawing.Point(518, 59);
            this.txtCurrentPN.Name = "txtCurrentPN";
            this.txtCurrentPN.ReadOnly = true;
            this.txtCurrentPN.Size = new System.Drawing.Size(43, 22);
            this.txtCurrentPN.TabIndex = 12;
            this.txtCurrentPN.Text = "1";
            this.txtCurrentPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCurrentPN.Visible = false;
            // 
            // txtSupplierCode
            // 
            this.txtSupplierCode.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtSupplierCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierCode.Enabled = false;
            this.txtSupplierCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSupplierCode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSupplierCode.Location = new System.Drawing.Point(634, 62);
            this.txtSupplierCode.Name = "txtSupplierCode";
            this.txtSupplierCode.ReadOnly = true;
            this.txtSupplierCode.Size = new System.Drawing.Size(43, 22);
            this.txtSupplierCode.TabIndex = 8;
            this.txtSupplierCode.Text = "-1";
            this.txtSupplierCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtNote
            // 
            this.txtNote.Enabled = false;
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNote.Location = new System.Drawing.Point(97, 132);
            this.txtNote.MaxLength = 255;
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(660, 73);
            this.txtNote.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(29, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "(Ghi chú)";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.dgvGRNDetails);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 225);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(1008, 434);
            this.panel2.TabIndex = 6;
            // 
            // dgvGRNDetails
            // 
            this.dgvGRNDetails.AllowUserToAddRows = false;
            this.dgvGRNDetails.AllowUserToDeleteRows = false;
            this.dgvGRNDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.IndianRed;
            this.dgvGRNDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvGRNDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGRNDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGRNDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvGRNDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvGRNDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGRNDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvGRNDetails.ColumnHeadersHeight = 30;
            this.dgvGRNDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGRNDetails.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvGRNDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGRNDetails.EnableHeadersVisualStyles = false;
            this.dgvGRNDetails.Location = new System.Drawing.Point(20, 20);
            this.dgvGRNDetails.Name = "dgvGRNDetails";
            this.dgvGRNDetails.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGRNDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvGRNDetails.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvGRNDetails.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvGRNDetails.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGRNDetails.RowTemplate.Height = 25;
            this.dgvGRNDetails.Size = new System.Drawing.Size(968, 394);
            this.dgvGRNDetails.TabIndex = 1;
            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.AutoSize = true;
            this.txtCurrentUser.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtCurrentUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCurrentUser.Location = new System.Drawing.Point(630, 100);
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.Size = new System.Drawing.Size(52, 19);
            this.txtCurrentUser.TabIndex = 10;
            this.txtCurrentUser.Text = "Admin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(567, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã NCC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(520, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Người thực hiện: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(17, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ngày nhập";
            // 
            // dtpDateAdd
            // 
            this.dtpDateAdd.Cursor = System.Windows.Forms.Cursors.No;
            this.dtpDateAdd.Enabled = false;
            this.dtpDateAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateAdd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateAdd.Location = new System.Drawing.Point(97, 97);
            this.dtpDateAdd.Name = "dtpDateAdd";
            this.dtpDateAdd.Size = new System.Drawing.Size(140, 29);
            this.dtpDateAdd.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(394, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Xem chi tiết phiếu nhập";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCurrentPN);
            this.panel1.Controls.Add(this.txtSupplierCode);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCurrentUser);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpDateAdd);
            this.panel1.Controls.Add(this.cbSuppliers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 225);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(29, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tên NCC";
            // 
            // cbSuppliers
            // 
            this.cbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSuppliers.Enabled = false;
            this.cbSuppliers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbSuppliers.FormattingEnabled = true;
            this.cbSuppliers.Location = new System.Drawing.Point(97, 62);
            this.cbSuppliers.Name = "cbSuppliers";
            this.cbSuppliers.Size = new System.Drawing.Size(250, 29);
            this.cbSuppliers.TabIndex = 6;
            // 
            // ViewGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "ViewGRN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phiếu kho";
            this.Load += new System.EventHandler(this.ViewGRN_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGRNDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label txtTotalCost;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.TextBox txtCurrentPN;
        private System.Windows.Forms.TextBox txtSupplierCode;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtCurrentUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSuppliers;
        private System.Windows.Forms.DataGridView dgvGRNDetails;
    }
}