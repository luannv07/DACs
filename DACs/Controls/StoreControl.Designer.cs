namespace DACs.Controls
{
    partial class ucStoreControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucStoreControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.labelUsers = new System.Windows.Forms.Label();
            this.btnStoreDelete = new System.Windows.Forms.Button();
            this.btnStoreAdd = new System.Windows.Forms.Button();
            this.btnStoreDetails = new System.Windows.Forms.Button();
            this.txtMaPNDisabled = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(19, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(923, 537);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhieuNhap);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(923, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách phiếu nhập";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.AllowUserToOrderColumns = true;
            this.dgvPhieuNhap.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            this.dgvPhieuNhap.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvPhieuNhap.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieuNhap.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhieuNhap.ColumnHeadersHeight = 30;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuNhap.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPhieuNhap.EnableHeadersVisualStyles = false;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(3, 25);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuNhap.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhieuNhap.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvPhieuNhap.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPhieuNhap.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPhieuNhap.RowTemplate.Height = 25;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(917, 509);
            this.dgvPhieuNhap.TabIndex = 1;
            this.dgvPhieuNhap.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellClick);
            this.dgvPhieuNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuNhap_CellContentClick);
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.BackColor = System.Drawing.Color.Transparent;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelUsers.Location = new System.Drawing.Point(348, 12);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(264, 37);
            this.labelUsers.TabIndex = 1;
            this.labelUsers.Text = "Quản lý phiếu nhập";
            // 
            // btnStoreDelete
            // 
            this.btnStoreDelete.BackColor = System.Drawing.Color.Red;
            this.btnStoreDelete.Enabled = false;
            this.btnStoreDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreDelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStoreDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreDelete.Location = new System.Drawing.Point(432, 78);
            this.btnStoreDelete.Name = "btnStoreDelete";
            this.btnStoreDelete.Size = new System.Drawing.Size(158, 42);
            this.btnStoreDelete.TabIndex = 6;
            this.btnStoreDelete.Text = "Xoá phiếu nhập";
            this.btnStoreDelete.UseVisualStyleBackColor = false;
            this.btnStoreDelete.Click += new System.EventHandler(this.btnStoreDelete_Click);
            // 
            // btnStoreAdd
            // 
            this.btnStoreAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreAdd.Location = new System.Drawing.Point(18, 78);
            this.btnStoreAdd.Name = "btnStoreAdd";
            this.btnStoreAdd.Size = new System.Drawing.Size(201, 42);
            this.btnStoreAdd.TabIndex = 4;
            this.btnStoreAdd.Text = "Tạo phiếu nhập mới";
            this.btnStoreAdd.UseVisualStyleBackColor = true;
            this.btnStoreAdd.Click += new System.EventHandler(this.btnStoreAdd_Click);
            // 
            // btnStoreDetails
            // 
            this.btnStoreDetails.Enabled = false;
            this.btnStoreDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStoreDetails.Location = new System.Drawing.Point(225, 78);
            this.btnStoreDetails.Name = "btnStoreDetails";
            this.btnStoreDetails.Size = new System.Drawing.Size(201, 42);
            this.btnStoreDetails.TabIndex = 6;
            this.btnStoreDetails.Text = "Xem chi tiết";
            this.btnStoreDetails.UseVisualStyleBackColor = true;
            this.btnStoreDetails.Click += new System.EventHandler(this.btnStoreDetails_Click);
            // 
            // txtMaPNDisabled
            // 
            this.txtMaPNDisabled.Location = new System.Drawing.Point(693, 41);
            this.txtMaPNDisabled.Name = "txtMaPNDisabled";
            this.txtMaPNDisabled.Size = new System.Drawing.Size(0, 20);
            this.txtMaPNDisabled.TabIndex = 7;
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReload.Location = new System.Drawing.Point(596, 78);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(42, 42);
            this.btnReload.TabIndex = 12;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // ucStoreControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtMaPNDisabled);
            this.Controls.Add(this.btnStoreDetails);
            this.Controls.Add(this.btnStoreDelete);
            this.Controls.Add(this.btnStoreAdd);
            this.Controls.Add(this.labelUsers);
            this.Controls.Add(this.panel1);
            this.Name = "ucStoreControl";
            this.Size = new System.Drawing.Size(960, 681);
            this.Load += new System.EventHandler(this.ucStoreControl_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Button btnStoreDelete;
        private System.Windows.Forms.Button btnStoreAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.Button btnStoreDetails;
        private System.Windows.Forms.TextBox txtMaPNDisabled;
        private System.Windows.Forms.Button btnReload;
    }
}
