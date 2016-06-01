namespace Staff
{
    partial class StaffWinForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffWinForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.gBUserAction = new System.Windows.Forms.GroupBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.gBUser = new System.Windows.Forms.GroupBox();
            this.dateTPUser = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPasp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNumb = new System.Windows.Forms.TabPage();
            this.gBNum = new System.Windows.Forms.GroupBox();
            this.dateTPNum = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateNum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNum = new System.Windows.Forms.DataGridView();
            this.CNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabHotel = new System.Windows.Forms.TabPage();
            this.dgvHotel = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelOrgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotelWeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxHotelClass = new System.Windows.Forms.TextBox();
            this.groupBoxStat = new System.Windows.Forms.GroupBox();
            this.labelNewUser = new System.Windows.Forms.Label();
            this.labelAllUser = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxHotelNum = new System.Windows.Forms.TextBox();
            this.btnClear3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxHotelS = new System.Windows.Forms.TextBox();
            this.textBoxHotelC = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxHotelPhone = new System.Windows.Forms.TextBox();
            this.textBoxHotelName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxHotelWeb = new System.Windows.Forms.TextBox();
            this.textBoxHotelOrg = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.gBUserAction.SuspendLayout();
            this.gBUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tabNumb.SuspendLayout();
            this.gBNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
            this.tabHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxStat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabNumb);
            this.tabControl.Controls.Add(this.tabHotel);
            this.tabControl.Location = new System.Drawing.Point(1, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(944, 559);
            this.tabControl.TabIndex = 1;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.gBUserAction);
            this.tabUser.Controls.Add(this.gBUser);
            this.tabUser.Controls.Add(this.dgvUser);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(936, 533);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Постояльцы";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // gBUserAction
            // 
            this.gBUserAction.Controls.Add(this.btnDeleteUser);
            this.gBUserAction.Controls.Add(this.btnAddUser);
            this.gBUserAction.Location = new System.Drawing.Point(5, 201);
            this.gBUserAction.Name = "gBUserAction";
            this.gBUserAction.Size = new System.Drawing.Size(197, 191);
            this.gBUserAction.TabIndex = 6;
            this.gBUserAction.TabStop = false;
            this.gBUserAction.Text = "Действия";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Image")));
            this.btnDeleteUser.Location = new System.Drawing.Point(104, 19);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(80, 80);
            this.btnDeleteUser.TabIndex = 0;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(13, 19);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(80, 80);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // gBUser
            // 
            this.gBUser.Controls.Add(this.dateTPUser);
            this.gBUser.Controls.Add(this.label2);
            this.gBUser.Controls.Add(this.btnUpdateUser);
            this.gBUser.Location = new System.Drawing.Point(5, 3);
            this.gBUser.Name = "gBUser";
            this.gBUser.Size = new System.Drawing.Size(197, 191);
            this.gBUser.TabIndex = 5;
            this.gBUser.TabStop = false;
            this.gBUser.Text = "Фильтры";
            // 
            // dateTPUser
            // 
            this.dateTPUser.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPUser.Location = new System.Drawing.Point(63, 20);
            this.dateTPUser.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dateTPUser.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTPUser.Name = "dateTPUser";
            this.dateTPUser.Size = new System.Drawing.Size(128, 20);
            this.dateTPUser.TabIndex = 1;
            this.dateTPUser.ValueChanged += new System.EventHandler(this.dateTPUser_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "По дате:";
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Enabled = false;
            this.btnUpdateUser.Location = new System.Drawing.Point(6, 160);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(185, 25);
            this.btnUpdateUser.TabIndex = 1;
            this.btnUpdateUser.Text = "Обновить";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // dgvUser
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cSName,
            this.cGender,
            this.cNum,
            this.cInDate,
            this.cOutDate,
            this.CPasp});
            this.dgvUser.Location = new System.Drawing.Point(208, 6);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(723, 521);
            this.dgvUser.TabIndex = 0;
            // 
            // cName
            // 
            this.cName.HeaderText = "Имя";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cName.Width = 110;
            // 
            // cSName
            // 
            this.cSName.HeaderText = "Фамилия";
            this.cSName.Name = "cSName";
            this.cSName.ReadOnly = true;
            this.cSName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cSName.Width = 130;
            // 
            // cGender
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cGender.DefaultCellStyle = dataGridViewCellStyle2;
            this.cGender.HeaderText = "Пол";
            this.cGender.Name = "cGender";
            this.cGender.ReadOnly = true;
            this.cGender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cGender.Width = 40;
            // 
            // cNum
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cNum.DefaultCellStyle = dataGridViewCellStyle3;
            this.cNum.HeaderText = "Номер";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            this.cNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNum.Width = 60;
            // 
            // cInDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cInDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.cInDate.HeaderText = "Дата вселения";
            this.cInDate.Name = "cInDate";
            this.cInDate.ReadOnly = true;
            this.cInDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cInDate.Width = 110;
            // 
            // cOutDate
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cOutDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.cOutDate.HeaderText = "Дата выселения";
            this.cOutDate.Name = "cOutDate";
            this.cOutDate.ReadOnly = true;
            this.cOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cOutDate.Width = 110;
            // 
            // CPasp
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CPasp.DefaultCellStyle = dataGridViewCellStyle6;
            this.CPasp.HeaderText = "Код паспорта";
            this.CPasp.Name = "CPasp";
            this.CPasp.ReadOnly = true;
            this.CPasp.Width = 120;
            // 
            // tabNumb
            // 
            this.tabNumb.Controls.Add(this.gBNum);
            this.tabNumb.Controls.Add(this.dgvNum);
            this.tabNumb.Location = new System.Drawing.Point(4, 22);
            this.tabNumb.Name = "tabNumb";
            this.tabNumb.Padding = new System.Windows.Forms.Padding(3);
            this.tabNumb.Size = new System.Drawing.Size(936, 533);
            this.tabNumb.TabIndex = 1;
            this.tabNumb.Text = "Номера";
            this.tabNumb.UseVisualStyleBackColor = true;
            // 
            // gBNum
            // 
            this.gBNum.Controls.Add(this.dateTPNum);
            this.gBNum.Controls.Add(this.btnUpdateNum);
            this.gBNum.Controls.Add(this.label1);
            this.gBNum.Location = new System.Drawing.Point(5, 3);
            this.gBNum.Name = "gBNum";
            this.gBNum.Size = new System.Drawing.Size(315, 191);
            this.gBNum.TabIndex = 4;
            this.gBNum.TabStop = false;
            this.gBNum.Text = "Фильтры";
            // 
            // dateTPNum
            // 
            this.dateTPNum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTPNum.Location = new System.Drawing.Point(63, 20);
            this.dateTPNum.MaxDate = new System.DateTime(2999, 12, 31, 0, 0, 0, 0);
            this.dateTPNum.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTPNum.Name = "dateTPNum";
            this.dateTPNum.Size = new System.Drawing.Size(247, 20);
            this.dateTPNum.TabIndex = 1;
            this.dateTPNum.ValueChanged += new System.EventHandler(this.dateTPNum_ValueChanged);
            // 
            // btnUpdateNum
            // 
            this.btnUpdateNum.Enabled = false;
            this.btnUpdateNum.Location = new System.Drawing.Point(6, 160);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(304, 25);
            this.btnUpdateNum.TabIndex = 3;
            this.btnUpdateNum.Text = "Обновить";
            this.btnUpdateNum.UseVisualStyleBackColor = true;
            this.btnUpdateNum.Click += new System.EventHandler(this.btnUpdateNum_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "По дате:";
            // 
            // dgvNum
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNumb,
            this.CPlace,
            this.CClass,
            this.CCost});
            this.dgvNum.Enabled = false;
            this.dgvNum.Location = new System.Drawing.Point(326, 6);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.ReadOnly = true;
            this.dgvNum.Size = new System.Drawing.Size(605, 521);
            this.dgvNum.TabIndex = 2;
            // 
            // CNumb
            // 
            this.CNumb.HeaderText = "№";
            this.CNumb.Name = "CNumb";
            this.CNumb.ReadOnly = true;
            this.CNumb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CNumb.Width = 90;
            // 
            // CPlace
            // 
            this.CPlace.HeaderText = "Кол-во мест";
            this.CPlace.Name = "CPlace";
            this.CPlace.ReadOnly = true;
            this.CPlace.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CClass
            // 
            this.CClass.HeaderText = "Класс комнаты";
            this.CClass.Name = "CClass";
            this.CClass.ReadOnly = true;
            this.CClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CCost
            // 
            this.CCost.HeaderText = "Цена";
            this.CCost.Name = "CCost";
            this.CCost.ReadOnly = true;
            // 
            // tabHotel
            // 
            this.tabHotel.Controls.Add(this.groupBox2);
            this.tabHotel.Controls.Add(this.dgvHotel);
            this.tabHotel.Location = new System.Drawing.Point(4, 22);
            this.tabHotel.Name = "tabHotel";
            this.tabHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotel.Size = new System.Drawing.Size(936, 533);
            this.tabHotel.TabIndex = 2;
            this.tabHotel.Text = "Отель";
            this.tabHotel.UseVisualStyleBackColor = true;
            // 
            // dgvHotel
            // 
            this.dgvHotel.AllowUserToResizeRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHotel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHotel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHotel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.HotelOrgName,
            this.dataGridViewTextBoxColumn2,
            this.HotelCName,
            this.HotelStreet,
            this.HotelPhone,
            this.HotelClass,
            this.HotelWeb});
            this.dgvHotel.Location = new System.Drawing.Point(6, 6);
            this.dgvHotel.Name = "dgvHotel";
            this.dgvHotel.ReadOnly = true;
            this.dgvHotel.Size = new System.Drawing.Size(924, 332);
            this.dgvHotel.TabIndex = 110;
            this.dgvHotel.TabStop = false;
            this.dgvHotel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHotel_CellClick);
            this.dgvHotel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvHotel_KeyUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // HotelOrgName
            // 
            this.HotelOrgName.Frozen = true;
            this.HotelOrgName.HeaderText = "Организация";
            this.HotelOrgName.Name = "HotelOrgName";
            this.HotelOrgName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Отель";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // HotelCName
            // 
            this.HotelCName.Frozen = true;
            this.HotelCName.HeaderText = "Город";
            this.HotelCName.Name = "HotelCName";
            this.HotelCName.ReadOnly = true;
            this.HotelCName.Width = 130;
            // 
            // HotelStreet
            // 
            this.HotelStreet.Frozen = true;
            this.HotelStreet.HeaderText = "Улица";
            this.HotelStreet.Name = "HotelStreet";
            this.HotelStreet.ReadOnly = true;
            this.HotelStreet.Width = 130;
            // 
            // HotelPhone
            // 
            this.HotelPhone.Frozen = true;
            this.HotelPhone.HeaderText = "Телефон";
            this.HotelPhone.Name = "HotelPhone";
            this.HotelPhone.ReadOnly = true;
            this.HotelPhone.Width = 130;
            // 
            // HotelClass
            // 
            this.HotelClass.Frozen = true;
            this.HotelClass.HeaderText = "Класс";
            this.HotelClass.Name = "HotelClass";
            this.HotelClass.ReadOnly = true;
            this.HotelClass.Width = 40;
            // 
            // HotelWeb
            // 
            this.HotelWeb.HeaderText = "Web-сайт";
            this.HotelWeb.Name = "HotelWeb";
            this.HotelWeb.ReadOnly = true;
            this.HotelWeb.Width = 175;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.textBoxHotelClass);
            this.groupBox2.Controls.Add(this.groupBoxStat);
            this.groupBox2.Controls.Add(this.textBoxHotelNum);
            this.groupBox2.Controls.Add(this.btnClear3);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBoxHotelS);
            this.groupBox2.Controls.Add(this.textBoxHotelC);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxHotelPhone);
            this.groupBox2.Controls.Add(this.textBoxHotelName);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBoxHotelWeb);
            this.groupBox2.Controls.Add(this.textBoxHotelOrg);
            this.groupBox2.Location = new System.Drawing.Point(6, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(924, 183);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Об отеле";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(430, 55);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 111;
            this.label18.Text = "Класс отеля";
            // 
            // textBoxHotelClass
            // 
            this.textBoxHotelClass.Location = new System.Drawing.Point(433, 71);
            this.textBoxHotelClass.Name = "textBoxHotelClass";
            this.textBoxHotelClass.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelClass.TabIndex = 110;
            this.textBoxHotelClass.Tag = "";
            // 
            // groupBoxStat
            // 
            this.groupBoxStat.Controls.Add(this.labelNewUser);
            this.groupBoxStat.Controls.Add(this.labelAllUser);
            this.groupBoxStat.Controls.Add(this.label17);
            this.groupBoxStat.Controls.Add(this.label16);
            this.groupBoxStat.Location = new System.Drawing.Point(694, 16);
            this.groupBoxStat.Name = "groupBoxStat";
            this.groupBoxStat.Size = new System.Drawing.Size(224, 153);
            this.groupBoxStat.TabIndex = 109;
            this.groupBoxStat.TabStop = false;
            this.groupBoxStat.Text = "Статистика {HotelName}";
            // 
            // labelNewUser
            // 
            this.labelNewUser.Location = new System.Drawing.Point(120, 69);
            this.labelNewUser.Name = "labelNewUser";
            this.labelNewUser.Size = new System.Drawing.Size(98, 13);
            this.labelNewUser.TabIndex = 3;
            this.labelNewUser.Text = "{StatNewUser}";
            this.labelNewUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAllUser
            // 
            this.labelAllUser.Location = new System.Drawing.Point(120, 30);
            this.labelAllUser.Name = "labelAllUser";
            this.labelAllUser.Size = new System.Drawing.Size(98, 13);
            this.labelAllUser.TabIndex = 2;
            this.labelAllUser.Text = "{StatAllUser}";
            this.labelAllUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Сейчас проживает:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(108, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Всего постояльцев:";
            // 
            // textBoxHotelNum
            // 
            this.textBoxHotelNum.Location = new System.Drawing.Point(13, 32);
            this.textBoxHotelNum.Name = "textBoxHotelNum";
            this.textBoxHotelNum.Size = new System.Drawing.Size(153, 20);
            this.textBoxHotelNum.TabIndex = 100;
            this.textBoxHotelNum.Tag = "";
            // 
            // btnClear3
            // 
            this.btnClear3.Location = new System.Drawing.Point(433, 133);
            this.btnClear3.Name = "btnClear3";
            this.btnClear3.Size = new System.Drawing.Size(255, 36);
            this.btnClear3.TabIndex = 104;
            this.btnClear3.Text = "Очистить";
            this.btnClear3.UseVisualStyleBackColor = true;
            this.btnClear3.Click += new System.EventHandler(this.btnClear3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 105;
            this.label12.Text = "№";
            // 
            // textBoxHotelS
            // 
            this.textBoxHotelS.Location = new System.Drawing.Point(172, 149);
            this.textBoxHotelS.Name = "textBoxHotelS";
            this.textBoxHotelS.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelS.TabIndex = 103;
            this.textBoxHotelS.Tag = "";
            // 
            // textBoxHotelC
            // 
            this.textBoxHotelC.Location = new System.Drawing.Point(172, 110);
            this.textBoxHotelC.Name = "textBoxHotelC";
            this.textBoxHotelC.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelC.TabIndex = 103;
            this.textBoxHotelC.Tag = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(169, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 107;
            this.label13.Text = "Улица";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 107;
            this.label10.Text = "Город";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(430, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(84, 13);
            this.label15.TabIndex = 108;
            this.label15.Text = "Телефон отеля";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 108;
            this.label9.Text = "Имя отеля";
            // 
            // textBoxHotelPhone
            // 
            this.textBoxHotelPhone.Location = new System.Drawing.Point(433, 32);
            this.textBoxHotelPhone.Name = "textBoxHotelPhone";
            this.textBoxHotelPhone.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelPhone.TabIndex = 101;
            this.textBoxHotelPhone.Tag = "";
            // 
            // textBoxHotelName
            // 
            this.textBoxHotelName.Location = new System.Drawing.Point(172, 32);
            this.textBoxHotelName.Name = "textBoxHotelName";
            this.textBoxHotelName.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelName.TabIndex = 101;
            this.textBoxHotelName.Tag = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(430, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 106;
            this.label14.Text = "Сайт отеля";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 13);
            this.label11.TabIndex = 106;
            this.label11.Text = "Имя организации";
            // 
            // textBoxHotelWeb
            // 
            this.textBoxHotelWeb.Location = new System.Drawing.Point(433, 110);
            this.textBoxHotelWeb.Name = "textBoxHotelWeb";
            this.textBoxHotelWeb.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelWeb.TabIndex = 102;
            this.textBoxHotelWeb.Tag = "";
            // 
            // textBoxHotelOrg
            // 
            this.textBoxHotelOrg.Location = new System.Drawing.Point(172, 71);
            this.textBoxHotelOrg.Name = "textBoxHotelOrg";
            this.textBoxHotelOrg.Size = new System.Drawing.Size(255, 20);
            this.textBoxHotelOrg.TabIndex = 102;
            this.textBoxHotelOrg.Tag = "";
            // 
            // StaffWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 565);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "StaffWinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STAFF terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffWinForm_FormClosing);
            this.Load += new System.EventHandler(this.StaffWinForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.gBUserAction.ResumeLayout(false);
            this.gBUser.ResumeLayout(false);
            this.gBUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tabNumb.ResumeLayout(false);
            this.gBNum.ResumeLayout(false);
            this.gBNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
            this.tabHotel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxStat.ResumeLayout(false);
            this.groupBoxStat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.GroupBox gBUserAction;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox gBUser;
        public System.Windows.Forms.DateTimePicker dateTPUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateUser;
        protected internal System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.TabPage tabNumb;
        private System.Windows.Forms.GroupBox gBNum;
        private System.Windows.Forms.DateTimePicker dateTPNum;
        private System.Windows.Forms.Button btnUpdateNum;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.DataGridView dgvNum;
        private System.Windows.Forms.TabPage tabHotel;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPasp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCost;
        protected internal System.Windows.Forms.DataGridView dgvHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelOrgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn HotelWeb;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxHotelClass;
        private System.Windows.Forms.GroupBox groupBoxStat;
        private System.Windows.Forms.Label labelNewUser;
        private System.Windows.Forms.Label labelAllUser;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxHotelNum;
        private System.Windows.Forms.Button btnClear3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxHotelS;
        private System.Windows.Forms.TextBox textBoxHotelC;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxHotelPhone;
        private System.Windows.Forms.TextBox textBoxHotelName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxHotelWeb;
        private System.Windows.Forms.TextBox textBoxHotelOrg;
    }
}

