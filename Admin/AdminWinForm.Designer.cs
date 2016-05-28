namespace Admin
{
    partial class AdminWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWinForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tabHotel = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteNum = new System.Windows.Forms.Button();
            this.btnEditNum = new System.Windows.Forms.Button();
            this.btnAddNum = new System.Windows.Forms.Button();
            this.dgvNumClass = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxClassCost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPlace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxNumCost = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxNumClass = new System.Windows.Forms.TextBox();
            this.btnClear1 = new System.Windows.Forms.Button();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.gBUserAction.SuspendLayout();
            this.gBUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tabNumb.SuspendLayout();
            this.gBNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumClass)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabUser);
            this.tabControl.Controls.Add(this.tabNumb);
            this.tabControl.Controls.Add(this.tabHotel);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(944, 559);
            this.tabControl.TabIndex = 2;
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
            this.gBUserAction.Location = new System.Drawing.Point(5, 275);
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
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUser.Image")));
            this.btnAddUser.Location = new System.Drawing.Point(13, 19);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(80, 80);
            this.btnAddUser.TabIndex = 3;
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
            this.gBUser.Size = new System.Drawing.Size(197, 266);
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
            this.dateTPUser.TabIndex = 0;
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
            this.btnUpdateUser.Location = new System.Drawing.Point(6, 235);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(185, 25);
            this.btnUpdateUser.TabIndex = 1;
            this.btnUpdateUser.Text = "Сбросить фильтр";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // dgvUser
            // 
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle39;
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
            this.dgvUser.TabIndex = 2;
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
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cGender.DefaultCellStyle = dataGridViewCellStyle40;
            this.cGender.HeaderText = "Пол";
            this.cGender.Name = "cGender";
            this.cGender.ReadOnly = true;
            this.cGender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cGender.Width = 40;
            // 
            // cNum
            // 
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cNum.DefaultCellStyle = dataGridViewCellStyle41;
            this.cNum.HeaderText = "Номер";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            this.cNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNum.Width = 60;
            // 
            // cInDate
            // 
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cInDate.DefaultCellStyle = dataGridViewCellStyle42;
            this.cInDate.HeaderText = "Дата вселения";
            this.cInDate.Name = "cInDate";
            this.cInDate.ReadOnly = true;
            this.cInDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cInDate.Width = 110;
            // 
            // cOutDate
            // 
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cOutDate.DefaultCellStyle = dataGridViewCellStyle43;
            this.cOutDate.HeaderText = "Дата выселения";
            this.cOutDate.Name = "cOutDate";
            this.cOutDate.ReadOnly = true;
            this.cOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cOutDate.Width = 110;
            // 
            // CPasp
            // 
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CPasp.DefaultCellStyle = dataGridViewCellStyle44;
            this.CPasp.HeaderText = "Код паспорта";
            this.CPasp.Name = "CPasp";
            this.CPasp.ReadOnly = true;
            this.CPasp.Width = 120;
            // 
            // tabNumb
            // 
            this.tabNumb.Controls.Add(this.btnClear2);
            this.tabNumb.Controls.Add(this.btnClear1);
            this.tabNumb.Controls.Add(this.label7);
            this.tabNumb.Controls.Add(this.textBoxNumCost);
            this.tabNumb.Controls.Add(this.label8);
            this.tabNumb.Controls.Add(this.textBoxNumClass);
            this.tabNumb.Controls.Add(this.label5);
            this.tabNumb.Controls.Add(this.textBoxPlace);
            this.tabNumb.Controls.Add(this.label6);
            this.tabNumb.Controls.Add(this.textBoxNum);
            this.tabNumb.Controls.Add(this.label4);
            this.tabNumb.Controls.Add(this.textBoxClassCost);
            this.tabNumb.Controls.Add(this.label3);
            this.tabNumb.Controls.Add(this.textBoxClass);
            this.tabNumb.Controls.Add(this.dgvNumClass);
            this.tabNumb.Controls.Add(this.groupBox1);
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
            this.btnUpdateNum.Location = new System.Drawing.Point(6, 160);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(304, 25);
            this.btnUpdateNum.TabIndex = 2;
            this.btnUpdateNum.Text = "Сбросить фильтр";
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
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.dgvNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNumb,
            this.CPlace,
            this.CClass,
            this.CCost});
            this.dgvNum.Location = new System.Drawing.Point(494, 6);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.ReadOnly = true;
            this.dgvNum.Size = new System.Drawing.Size(437, 304);
            this.dgvNum.TabIndex = 5;
            this.dgvNum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNum_CellClick);
            this.dgvNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvNum_KeyUp);
            // 
            // tabHotel
            // 
            this.tabHotel.Location = new System.Drawing.Point(4, 22);
            this.tabHotel.Name = "tabHotel";
            this.tabHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotel.Size = new System.Drawing.Size(936, 533);
            this.tabHotel.TabIndex = 2;
            this.tabHotel.Text = "Отель";
            this.tabHotel.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(936, 533);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Сотрудники";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditClass);
            this.groupBox1.Controls.Add(this.btnAddNum);
            this.groupBox1.Controls.Add(this.btnDeleteNum);
            this.groupBox1.Controls.Add(this.btnEditNum);
            this.groupBox1.Location = new System.Drawing.Point(5, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 327);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // btnDeleteNum
            // 
            this.btnDeleteNum.Location = new System.Drawing.Point(229, 19);
            this.btnDeleteNum.Name = "btnDeleteNum";
            this.btnDeleteNum.Size = new System.Drawing.Size(80, 80);
            this.btnDeleteNum.TabIndex = 9;
            this.btnDeleteNum.Text = "Удалить номер";
            this.btnDeleteNum.UseVisualStyleBackColor = true;
            // 
            // btnEditNum
            // 
            this.btnEditNum.Location = new System.Drawing.Point(92, 19);
            this.btnEditNum.Name = "btnEditNum";
            this.btnEditNum.Size = new System.Drawing.Size(131, 80);
            this.btnEditNum.TabIndex = 8;
            this.btnEditNum.Text = "Редактировать номер";
            this.btnEditNum.UseVisualStyleBackColor = true;
            // 
            // btnAddNum
            // 
            this.btnAddNum.Location = new System.Drawing.Point(6, 19);
            this.btnAddNum.Name = "btnAddNum";
            this.btnAddNum.Size = new System.Drawing.Size(80, 80);
            this.btnAddNum.TabIndex = 7;
            this.btnAddNum.Text = "Добавить номер";
            this.btnAddNum.UseVisualStyleBackColor = true;
            // 
            // dgvNumClass
            // 
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvNumClass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle34;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNumClass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgvNumClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNumClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvNumClass.Location = new System.Drawing.Point(494, 316);
            this.dgvNumClass.Name = "dgvNumClass";
            this.dgvNumClass.ReadOnly = true;
            this.dgvNumClass.Size = new System.Drawing.Size(436, 211);
            this.dgvNumClass.TabIndex = 6;
            this.dgvNumClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNumClass_CellContentClick);
            this.dgvNumClass.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvNumClass_KeyUp);
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridViewTextBoxColumn3.HeaderText = "Класс комнаты";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 195;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridViewTextBoxColumn4.HeaderText = "Цена";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 195;
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
            // btnEditClass
            // 
            this.btnEditClass.Location = new System.Drawing.Point(92, 105);
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.Size = new System.Drawing.Size(131, 80);
            this.btnEditClass.TabIndex = 10;
            this.btnEditClass.Text = "Редактировать стоимость класс";
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // textBoxClass
            // 
            this.textBoxClass.Enabled = false;
            this.textBoxClass.Location = new System.Drawing.Point(326, 332);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(162, 20);
            this.textBoxClass.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(323, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Класс комнаты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Цена класса";
            // 
            // textBoxClassCost
            // 
            this.textBoxClassCost.Location = new System.Drawing.Point(326, 371);
            this.textBoxClassCost.Name = "textBoxClassCost";
            this.textBoxClassCost.Size = new System.Drawing.Size(162, 20);
            this.textBoxClassCost.TabIndex = 13;
            this.textBoxClassCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxClassCost_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Кол-во мест";
            // 
            // textBoxPlace
            // 
            this.textBoxPlace.Location = new System.Drawing.Point(326, 66);
            this.textBoxPlace.Name = "textBoxPlace";
            this.textBoxPlace.Size = new System.Drawing.Size(162, 20);
            this.textBoxPlace.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(323, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "№";
            // 
            // textBoxNum
            // 
            this.textBoxNum.Location = new System.Drawing.Point(326, 27);
            this.textBoxNum.Name = "textBoxNum";
            this.textBoxNum.Size = new System.Drawing.Size(162, 20);
            this.textBoxNum.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Цена класса";
            // 
            // textBoxNumCost
            // 
            this.textBoxNumCost.Location = new System.Drawing.Point(326, 144);
            this.textBoxNumCost.Name = "textBoxNumCost";
            this.textBoxNumCost.Size = new System.Drawing.Size(162, 20);
            this.textBoxNumCost.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Класс комнаты";
            // 
            // textBoxNumClass
            // 
            this.textBoxNumClass.Location = new System.Drawing.Point(326, 105);
            this.textBoxNumClass.Name = "textBoxNumClass";
            this.textBoxNumClass.Size = new System.Drawing.Size(162, 20);
            this.textBoxNumClass.TabIndex = 19;
            // 
            // btnClear1
            // 
            this.btnClear1.Location = new System.Drawing.Point(326, 170);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(162, 24);
            this.btnClear1.TabIndex = 3;
            this.btnClear1.Text = "Очистить";
            this.btnClear1.UseVisualStyleBackColor = true;
            this.btnClear1.Click += new System.EventHandler(this.btnClear1_Click);
            // 
            // btnClear2
            // 
            this.btnClear2.Location = new System.Drawing.Point(326, 397);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(162, 24);
            this.btnClear2.TabIndex = 4;
            this.btnClear2.Text = "Очистить";
            this.btnClear2.UseVisualStyleBackColor = true;
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // AdminWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 569);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AdminWinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADMIN terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminWinForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminWinForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            this.gBUserAction.ResumeLayout(false);
            this.gBUser.ResumeLayout(false);
            this.gBUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tabNumb.ResumeLayout(false);
            this.tabNumb.PerformLayout();
            this.gBNum.ResumeLayout(false);
            this.gBNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNumClass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.GroupBox gBUserAction;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.GroupBox gBUser;
        public System.Windows.Forms.DateTimePicker dateTPUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateUser;
        protected internal System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPasp;
        private System.Windows.Forms.TabPage tabNumb;
        private System.Windows.Forms.GroupBox gBNum;
        private System.Windows.Forms.DateTimePicker dateTPNum;
        private System.Windows.Forms.Button btnUpdateNum;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.DataGridView dgvNum;
        private System.Windows.Forms.TabPage tabHotel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteNum;
        private System.Windows.Forms.Button btnEditNum;
        private System.Windows.Forms.Button btnAddNum;
        protected internal System.Windows.Forms.DataGridView dgvNumClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCost;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxNumCost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxNumClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxClassCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnClear1;
    }
}

