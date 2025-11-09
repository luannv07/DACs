namespace DACs.Controls
{
    partial class ucAccountControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucAccountControl));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageAccountSubOptions = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxWrapperUsers = new System.Windows.Forms.GroupBox();
            this.dgvUserList = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAccountResetFields = new System.Windows.Forms.Button();
            this.dtpAccountBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbAccountStatus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbAccountGender = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbAccountRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccountPassword = new System.Windows.Forms.TextBox();
            this.txtAccountLastName = new System.Windows.Forms.TextBox();
            this.txtAccountUsername = new System.Windows.Forms.TextBox();
            this.txtAccountEmail = new System.Windows.Forms.TextBox();
            this.txtAccountAddress = new System.Windows.Forms.TextBox();
            this.txtAccountFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountCode = new System.Windows.Forms.TextBox();
            this.labelUsers = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAccountResetData = new System.Windows.Forms.Button();
            this.btnAccountVipFeatures = new System.Windows.Forms.Button();
            this.btnAccountDeleteUser = new System.Windows.Forms.Button();
            this.btnAccountEditUser = new System.Windows.Forms.Button();
            this.btnAccountAddUser = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtSearching = new System.Windows.Forms.TextBox();
            this.btnTriggerSearching = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBoxWrapperUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageAccountSubOptions
            // 
            this.imageAccountSubOptions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageAccountSubOptions.ImageStream")));
            this.imageAccountSubOptions.TransparentColor = System.Drawing.Color.Transparent;
            this.imageAccountSubOptions.Images.SetKeyName(0, "Contacts_1.png");
            this.imageAccountSubOptions.Images.SetKeyName(1, "MySpace.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxWrapperUsers);
            this.panel1.Location = new System.Drawing.Point(16, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 283);
            this.panel1.TabIndex = 2;
            // 
            // groupBoxWrapperUsers
            // 
            this.groupBoxWrapperUsers.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxWrapperUsers.Controls.Add(this.dgvUserList);
            this.groupBoxWrapperUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxWrapperUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxWrapperUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxWrapperUsers.Location = new System.Drawing.Point(0, 0);
            this.groupBoxWrapperUsers.Name = "groupBoxWrapperUsers";
            this.groupBoxWrapperUsers.Size = new System.Drawing.Size(926, 283);
            this.groupBoxWrapperUsers.TabIndex = 0;
            this.groupBoxWrapperUsers.TabStop = false;
            this.groupBoxWrapperUsers.Text = "Danh sách nhân viên";
            // 
            // dgvUserList
            // 
            this.dgvUserList.AllowUserToOrderColumns = true;
            this.dgvUserList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            this.dgvUserList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUserList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUserList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUserList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUserList.ColumnHeadersHeight = 30;
            this.dgvUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUserList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserList.EnableHeadersVisualStyles = false;
            this.dgvUserList.Location = new System.Drawing.Point(3, 25);
            this.dgvUserList.Name = "dgvUserList";
            this.dgvUserList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUserList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUserList.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvUserList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUserList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUserList.RowTemplate.Height = 25;
            this.dgvUserList.Size = new System.Drawing.Size(920, 255);
            this.dgvUserList.TabIndex = 0;
            this.dgvUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserList_CellClick);
            this.dgvUserList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserList_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Location = new System.Drawing.Point(16, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(649, 284);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnAccountResetFields);
            this.groupBox1.Controls.Add(this.dtpAccountBirthDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbAccountStatus);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cbAccountGender);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cbAccountRole);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAccountPassword);
            this.groupBox1.Controls.Add(this.txtAccountLastName);
            this.groupBox1.Controls.Add(this.txtAccountUsername);
            this.groupBox1.Controls.Add(this.txtAccountEmail);
            this.groupBox1.Controls.Add(this.txtAccountAddress);
            this.groupBox1.Controls.Add(this.txtAccountFirstName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAccountCode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(231, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(8, 8);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // btnAccountResetFields
            // 
            this.btnAccountResetFields.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountResetFields.Image")));
            this.btnAccountResetFields.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountResetFields.Location = new System.Drawing.Point(608, 15);
            this.btnAccountResetFields.Name = "btnAccountResetFields";
            this.btnAccountResetFields.Size = new System.Drawing.Size(38, 38);
            this.btnAccountResetFields.TabIndex = 11;
            this.btnAccountResetFields.UseVisualStyleBackColor = true;
            this.btnAccountResetFields.Click += new System.EventHandler(this.btnAccountResetFields_Click);
            // 
            // dtpAccountBirthDate
            // 
            this.dtpAccountBirthDate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpAccountBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccountBirthDate.Location = new System.Drawing.Point(485, 159);
            this.dtpAccountBirthDate.Name = "dtpAccountBirthDate";
            this.dtpAccountBirthDate.Size = new System.Drawing.Size(148, 29);
            this.dtpAccountBirthDate.TabIndex = 7;
            this.dtpAccountBirthDate.ValueChanged += new System.EventHandler(this.dtpAccountBirthDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(409, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Ngày sinh";
            // 
            // cbAccountStatus
            // 
            this.cbAccountStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbAccountStatus.FormattingEnabled = true;
            this.cbAccountStatus.Items.AddRange(new object[] {
            "Hoạt động",
            "Đã nghỉ"});
            this.cbAccountStatus.Location = new System.Drawing.Point(520, 213);
            this.cbAccountStatus.Name = "cbAccountStatus";
            this.cbAccountStatus.Size = new System.Drawing.Size(113, 29);
            this.cbAccountStatus.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(444, 219);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Trạng thái";
            // 
            // cbAccountGender
            // 
            this.cbAccountGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountGender.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbAccountGender.FormattingEnabled = true;
            this.cbAccountGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ",
            "Khác"});
            this.cbAccountGender.Location = new System.Drawing.Point(333, 213);
            this.cbAccountGender.Name = "cbAccountGender";
            this.cbAccountGender.Size = new System.Drawing.Size(88, 29);
            this.cbAccountGender.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(266, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Giới tính";
            // 
            // cbAccountRole
            // 
            this.cbAccountRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccountRole.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbAccountRole.FormattingEnabled = true;
            this.cbAccountRole.Items.AddRange(new object[] {
            "Nhân viên",
            "Kiểm kho",
            "Quản trị"});
            this.cbAccountRole.Location = new System.Drawing.Point(507, 109);
            this.cbAccountRole.Name = "cbAccountRole";
            this.cbAccountRole.Size = new System.Drawing.Size(126, 29);
            this.cbAccountRole.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(452, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vai trò";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(411, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(228, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(151, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tài khoản";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(10, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(10, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(10, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Họ";
            // 
            // txtAccountPassword
            // 
            this.txtAccountPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountPassword.Location = new System.Drawing.Point(485, 59);
            this.txtAccountPassword.Name = "txtAccountPassword";
            this.txtAccountPassword.Size = new System.Drawing.Size(148, 29);
            this.txtAccountPassword.TabIndex = 2;
            // 
            // txtAccountLastName
            // 
            this.txtAccountLastName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountLastName.Location = new System.Drawing.Point(264, 109);
            this.txtAccountLastName.Name = "txtAccountLastName";
            this.txtAccountLastName.Size = new System.Drawing.Size(157, 29);
            this.txtAccountLastName.TabIndex = 4;
            // 
            // txtAccountUsername
            // 
            this.txtAccountUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountUsername.Location = new System.Drawing.Point(223, 59);
            this.txtAccountUsername.Name = "txtAccountUsername";
            this.txtAccountUsername.ReadOnly = true;
            this.txtAccountUsername.Size = new System.Drawing.Size(162, 29);
            this.txtAccountUsername.TabIndex = 1;
            // 
            // txtAccountEmail
            // 
            this.txtAccountEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountEmail.Location = new System.Drawing.Point(68, 213);
            this.txtAccountEmail.Name = "txtAccountEmail";
            this.txtAccountEmail.Size = new System.Drawing.Size(190, 29);
            this.txtAccountEmail.TabIndex = 8;
            // 
            // txtAccountAddress
            // 
            this.txtAccountAddress.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountAddress.Location = new System.Drawing.Point(68, 159);
            this.txtAccountAddress.Name = "txtAccountAddress";
            this.txtAccountAddress.Size = new System.Drawing.Size(328, 29);
            this.txtAccountAddress.TabIndex = 6;
            // 
            // txtAccountFirstName
            // 
            this.txtAccountFirstName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountFirstName.Location = new System.Drawing.Point(68, 109);
            this.txtAccountFirstName.Name = "txtAccountFirstName";
            this.txtAccountFirstName.Size = new System.Drawing.Size(148, 29);
            this.txtAccountFirstName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã NV";
            // 
            // txtAccountCode
            // 
            this.txtAccountCode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAccountCode.Location = new System.Drawing.Point(68, 59);
            this.txtAccountCode.Name = "txtAccountCode";
            this.txtAccountCode.ReadOnly = true;
            this.txtAccountCode.Size = new System.Drawing.Size(57, 29);
            this.txtAccountCode.TabIndex = 0;
            this.txtAccountCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelUsers
            // 
            this.labelUsers.AutoSize = true;
            this.labelUsers.BackColor = System.Drawing.Color.Transparent;
            this.labelUsers.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelUsers.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelUsers.Location = new System.Drawing.Point(296, 9);
            this.labelUsers.Name = "labelUsers";
            this.labelUsers.Size = new System.Drawing.Size(369, 37);
            this.labelUsers.TabIndex = 0;
            this.labelUsers.Text = "Hệ thống quản lý nhân viên";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Location = new System.Drawing.Point(684, 381);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 284);
            this.panel3.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAccountResetData);
            this.groupBox2.Controls.Add(this.btnAccountVipFeatures);
            this.groupBox2.Controls.Add(this.btnAccountDeleteUser);
            this.groupBox2.Controls.Add(this.btnAccountEditUser);
            this.groupBox2.Controls.Add(this.btnAccountAddUser);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 284);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Các chức năng";
            // 
            // btnAccountResetData
            // 
            this.btnAccountResetData.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountResetData.Image")));
            this.btnAccountResetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountResetData.Location = new System.Drawing.Point(30, 35);
            this.btnAccountResetData.Name = "btnAccountResetData";
            this.btnAccountResetData.Size = new System.Drawing.Size(201, 42);
            this.btnAccountResetData.TabIndex = 0;
            this.btnAccountResetData.Text = "Làm mới";
            this.btnAccountResetData.UseVisualStyleBackColor = true;
            this.btnAccountResetData.Click += new System.EventHandler(this.btnAccountResetData_Click);
            // 
            // btnAccountVipFeatures
            // 
            this.btnAccountVipFeatures.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountVipFeatures.Image")));
            this.btnAccountVipFeatures.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountVipFeatures.Location = new System.Drawing.Point(30, 227);
            this.btnAccountVipFeatures.Name = "btnAccountVipFeatures";
            this.btnAccountVipFeatures.Size = new System.Drawing.Size(201, 42);
            this.btnAccountVipFeatures.TabIndex = 4;
            this.btnAccountVipFeatures.Text = "Nâng cao";
            this.btnAccountVipFeatures.UseVisualStyleBackColor = true;
            // 
            // btnAccountDeleteUser
            // 
            this.btnAccountDeleteUser.Enabled = false;
            this.btnAccountDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountDeleteUser.Image")));
            this.btnAccountDeleteUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountDeleteUser.Location = new System.Drawing.Point(30, 179);
            this.btnAccountDeleteUser.Name = "btnAccountDeleteUser";
            this.btnAccountDeleteUser.Size = new System.Drawing.Size(201, 42);
            this.btnAccountDeleteUser.TabIndex = 3;
            this.btnAccountDeleteUser.Text = "Xoá nhân viên";
            this.btnAccountDeleteUser.UseVisualStyleBackColor = true;
            this.btnAccountDeleteUser.Click += new System.EventHandler(this.btnAccountDeleteUser_Click);
            // 
            // btnAccountEditUser
            // 
            this.btnAccountEditUser.Enabled = false;
            this.btnAccountEditUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountEditUser.Image")));
            this.btnAccountEditUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountEditUser.Location = new System.Drawing.Point(30, 131);
            this.btnAccountEditUser.Name = "btnAccountEditUser";
            this.btnAccountEditUser.Size = new System.Drawing.Size(201, 42);
            this.btnAccountEditUser.TabIndex = 2;
            this.btnAccountEditUser.Text = "Sửa nhân viên";
            this.btnAccountEditUser.UseVisualStyleBackColor = true;
            this.btnAccountEditUser.Click += new System.EventHandler(this.btnAccountEditUser_Click);
            // 
            // btnAccountAddUser
            // 
            this.btnAccountAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountAddUser.Image")));
            this.btnAccountAddUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountAddUser.Location = new System.Drawing.Point(30, 83);
            this.btnAccountAddUser.Name = "btnAccountAddUser";
            this.btnAccountAddUser.Size = new System.Drawing.Size(201, 42);
            this.btnAccountAddUser.TabIndex = 1;
            this.btnAccountAddUser.Text = "Thêm nhân viên";
            this.btnAccountAddUser.UseVisualStyleBackColor = true;
            this.btnAccountAddUser.Click += new System.EventHandler(this.btnAccountAddUser_Click);
            // 
            // txtSearching
            // 
            this.txtSearching.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearching.Location = new System.Drawing.Point(19, 57);
            this.txtSearching.Name = "txtSearching";
            this.txtSearching.Size = new System.Drawing.Size(418, 29);
            this.txtSearching.TabIndex = 3;
            // 
            // btnTriggerSearching
            // 
            this.btnTriggerSearching.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTriggerSearching.Location = new System.Drawing.Point(438, 57);
            this.btnTriggerSearching.Name = "btnTriggerSearching";
            this.btnTriggerSearching.Size = new System.Drawing.Size(88, 30);
            this.btnTriggerSearching.TabIndex = 4;
            this.btnTriggerSearching.Text = "Tìm kiếm";
            this.btnTriggerSearching.UseVisualStyleBackColor = true;
            this.btnTriggerSearching.Click += new System.EventHandler(this.btnTriggerSearching_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(532, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(290, 21);
            this.label12.TabIndex = 5;
            this.label12.Text = "(Tìm kiếm bằng Mã nhân viên hoặc Tên)";
            // 
            // ucAccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnTriggerSearching);
            this.Controls.Add(this.txtSearching);
            this.Controls.Add(this.labelUsers);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucAccountControl";
            this.Size = new System.Drawing.Size(960, 681);
            this.Load += new System.EventHandler(this.ucAccountControl_Load);
            this.panel1.ResumeLayout(false);
            this.groupBoxWrapperUsers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageAccountSubOptions;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUsers;
        private System.Windows.Forms.GroupBox groupBoxWrapperUsers;
        private System.Windows.Forms.DataGridView dgvUserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAccountCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccountPassword;
        private System.Windows.Forms.TextBox txtAccountLastName;
        private System.Windows.Forms.TextBox txtAccountUsername;
        private System.Windows.Forms.TextBox txtAccountFirstName;
        private System.Windows.Forms.ComboBox cbAccountRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountAddress;
        private System.Windows.Forms.DateTimePicker dtpAccountBirthDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbAccountStatus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbAccountGender;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAccountEmail;
        private System.Windows.Forms.Button btnAccountAddUser;
        private System.Windows.Forms.Button btnAccountVipFeatures;
        private System.Windows.Forms.Button btnAccountDeleteUser;
        private System.Windows.Forms.Button btnAccountEditUser;
        private System.Windows.Forms.Button btnAccountResetFields;
        private System.Windows.Forms.Button btnAccountResetData;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtSearching;
        private System.Windows.Forms.Button btnTriggerSearching;
        private System.Windows.Forms.Label label12;
    }
}
