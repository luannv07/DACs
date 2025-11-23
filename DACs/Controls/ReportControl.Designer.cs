namespace DACs.Controls
{
    partial class ucReportControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelUsers = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotalCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalOrder = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalCustomer = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.chartReporter = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvBestSell = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgvBestCustomers = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporter)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSell)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.BackColor = System.Drawing.Color.Transparent;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelUsers.Location = new System.Drawing.Point(417, 11);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(136, 37);
            this.labelUsers.TabIndex = 2;
            this.labelUsers.Text = "Thống kê";
            this.labelUsers.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtTotalCost);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(46, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(241, 70);
            this.panel2.TabIndex = 5;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTotalCost.Location = new System.Drawing.Point(3, 30);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(233, 32);
            this.txtTotalCost.TabIndex = 3;
            this.txtTotalCost.Text = "10";
            this.txtTotalCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(41, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "TỔNG DOANH THU";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTotalOrder);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(359, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(241, 70);
            this.panel1.TabIndex = 6;
            // 
            // txtTotalOrder
            // 
            this.txtTotalOrder.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTotalOrder.Location = new System.Drawing.Point(3, 32);
            this.txtTotalOrder.Name = "txtTotalOrder";
            this.txtTotalOrder.Size = new System.Drawing.Size(233, 30);
            this.txtTotalOrder.TabIndex = 3;
            this.txtTotalOrder.Text = "10";
            this.txtTotalOrder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(46, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "TỔNG ĐƠN HÀNG";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txtTotalCustomer);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(672, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(241, 70);
            this.panel3.TabIndex = 5;
            // 
            // txtTotalCustomer
            // 
            this.txtTotalCustomer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtTotalCustomer.Location = new System.Drawing.Point(3, 32);
            this.txtTotalCustomer.Name = "txtTotalCustomer";
            this.txtTotalCustomer.Size = new System.Drawing.Size(233, 30);
            this.txtTotalCustomer.TabIndex = 3;
            this.txtTotalCustomer.Text = "10";
            this.txtTotalCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(61, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "KHÁCH HÀNG";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 1F);
            this.label3.Location = new System.Drawing.Point(116, 457);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(729, 1);
            this.label3.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 1F);
            this.label6.Location = new System.Drawing.Point(116, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(729, 1);
            this.label6.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 1F);
            this.label8.Location = new System.Drawing.Point(118, 672);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(729, 1);
            this.label8.TabIndex = 7;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Location = new System.Drawing.Point(117, 152);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(183, 29);
            this.cbFilterBy.TabIndex = 8;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Lọc theo";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(719, 151);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(126, 29);
            this.btnExportCSV.TabIndex = 10;
            this.btnExportCSV.Text = "Xuất CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // chartReporter
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReporter.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReporter.Legends.Add(legend1);
            this.chartReporter.Location = new System.Drawing.Point(46, 186);
            this.chartReporter.Name = "chartReporter";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReporter.Series.Add(series1);
            this.chartReporter.Size = new System.Drawing.Size(867, 256);
            this.chartReporter.TabIndex = 11;
            this.chartReporter.Text = "chart1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label9.Location = new System.Drawing.Point(327, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(306, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "BIỂU ĐỒ DOANH THU THEO THỜI GIAN";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label10.Location = new System.Drawing.Point(42, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Top sản phẩm bán chạy";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label11.Location = new System.Drawing.Point(484, 458);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 21);
            this.label11.TabIndex = 9;
            this.label11.Text = "Top khách hàng mua nhiều nhất";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvBestSell);
            this.panel4.Location = new System.Drawing.Point(46, 482);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(436, 187);
            this.panel4.TabIndex = 12;
            // 
            // dgvBestSell
            // 
            this.dgvBestSell.AllowUserToAddRows = false;
            this.dgvBestSell.AllowUserToDeleteRows = false;
            this.dgvBestSell.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            this.dgvBestSell.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBestSell.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBestSell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBestSell.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBestSell.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBestSell.ColumnHeadersHeight = 30;
            this.dgvBestSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBestSell.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBestSell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBestSell.EnableHeadersVisualStyles = false;
            this.dgvBestSell.Location = new System.Drawing.Point(0, 0);
            this.dgvBestSell.Name = "dgvBestSell";
            this.dgvBestSell.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBestSell.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBestSell.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvBestSell.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBestSell.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBestSell.RowTemplate.Height = 25;
            this.dgvBestSell.Size = new System.Drawing.Size(436, 187);
            this.dgvBestSell.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dgvBestCustomers);
            this.panel5.Location = new System.Drawing.Point(488, 482);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(425, 187);
            this.panel5.TabIndex = 12;
            // 
            // dgvBestCustomers
            // 
            this.dgvBestCustomers.AllowUserToAddRows = false;
            this.dgvBestCustomers.AllowUserToDeleteRows = false;
            this.dgvBestCustomers.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.IndianRed;
            this.dgvBestCustomers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBestCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBestCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBestCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBestCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBestCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBestCustomers.ColumnHeadersHeight = 30;
            this.dgvBestCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBestCustomers.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBestCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBestCustomers.EnableHeadersVisualStyles = false;
            this.dgvBestCustomers.Location = new System.Drawing.Point(0, 0);
            this.dgvBestCustomers.Name = "dgvBestCustomers";
            this.dgvBestCustomers.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBestCustomers.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBestCustomers.RowHeadersVisible = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvBestCustomers.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBestCustomers.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvBestCustomers.RowTemplate.Height = 25;
            this.dgvBestCustomers.Size = new System.Drawing.Size(425, 187);
            this.dgvBestCustomers.TabIndex = 13;
            // 
            // ucReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.chartReporter);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelUsers);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ucReportControl";
            this.Size = new System.Drawing.Size(960, 681);
            this.Load += new System.EventHandler(this.ucReportControl_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporter)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSell)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label txtTotalCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txtTotalOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtTotalCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReporter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dgvBestSell;
        private System.Windows.Forms.DataGridView dgvBestCustomers;
    }
}
