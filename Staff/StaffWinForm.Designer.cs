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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffWinForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.gBUserAction = new System.Windows.Forms.GroupBox();
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
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            this.gBUserAction.SuspendLayout();
            this.gBUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tabNumb.SuspendLayout();
            this.gBNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
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
            this.gBUserAction.Controls.Add(this.btnAddUser);
            this.gBUserAction.Location = new System.Drawing.Point(5, 201);
            this.gBUserAction.Name = "gBUserAction";
            this.gBUserAction.Size = new System.Drawing.Size(315, 191);
            this.gBUserAction.TabIndex = 6;
            this.gBUserAction.TabStop = false;
            this.gBUserAction.Text = "Действия";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(120, 19);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 25);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Добавить";
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
            this.gBUser.Size = new System.Drawing.Size(315, 191);
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
            this.dateTPUser.Size = new System.Drawing.Size(247, 20);
            this.dateTPUser.TabIndex = 1;
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
            this.btnUpdateUser.Location = new System.Drawing.Point(210, 160);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateUser.TabIndex = 1;
            this.btnUpdateUser.Text = "Обновить";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cName,
            this.cSName,
            this.cGender,
            this.cNum,
            this.cInDate,
            this.cOutDate,
            this.CPasp});
            this.dgvUser.Location = new System.Drawing.Point(326, 6);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(605, 521);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cGender.DefaultCellStyle = dataGridViewCellStyle1;
            this.cGender.HeaderText = "Пол";
            this.cGender.Name = "cGender";
            this.cGender.ReadOnly = true;
            this.cGender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cGender.Width = 40;
            // 
            // cNum
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.cNum.HeaderText = "Номер";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            this.cNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNum.Width = 60;
            // 
            // cInDate
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cInDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.cInDate.HeaderText = "Дата вселения";
            this.cInDate.Name = "cInDate";
            this.cInDate.ReadOnly = true;
            this.cInDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cInDate.Width = 110;
            // 
            // cOutDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cOutDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.cOutDate.HeaderText = "Дата выселения";
            this.cOutDate.Name = "cOutDate";
            this.cOutDate.ReadOnly = true;
            this.cOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cOutDate.Width = 110;
            // 
            // CPasp
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CPasp.DefaultCellStyle = dataGridViewCellStyle5;
            this.CPasp.HeaderText = "Код паспорта";
            this.CPasp.Name = "CPasp";
            this.CPasp.ReadOnly = true;
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
            // 
            // btnUpdateNum
            // 
            this.btnUpdateNum.Location = new System.Drawing.Point(210, 160);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(100, 25);
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
            this.dgvNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNumb,
            this.CPlace,
            this.CClass,
            this.CCost});
            this.dgvNum.Location = new System.Drawing.Point(326, 6);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.Size = new System.Drawing.Size(605, 521);
            this.dgvNum.TabIndex = 2;
            // 
            // CNumb
            // 
            this.CNumb.HeaderText = "№";
            this.CNumb.Name = "CNumb";
            this.CNumb.ReadOnly = true;
            this.CNumb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CNumb.Width = 40;
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
            this.CClass.Width = 80;
            // 
            // CCost
            // 
            this.CCost.HeaderText = "Цена";
            this.CCost.Name = "CCost";
            this.CCost.ReadOnly = true;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCost;
        private System.Windows.Forms.TabPage tabHotel;
    }
}

