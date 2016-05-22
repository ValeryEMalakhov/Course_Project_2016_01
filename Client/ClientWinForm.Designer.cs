namespace Client
{
    partial class ClientWinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientWinForm));
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNumb = new System.Windows.Forms.TabPage();
            this.gBUserAction = new System.Windows.Forms.GroupBox();
            this.btnAddRequest = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteRequest = new System.Windows.Forms.Button();
            this.btnEditRequest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvNow = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSessionCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabNumb.SuspendLayout();
            this.gBUserAction.SuspendLayout();
            this.gBNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
            this.tabHotel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabNumb);
            this.tabControl.Controls.Add(this.tabHotel);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(4, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(674, 391);
            this.tabControl.TabIndex = 2;
            // 
            // tabNumb
            // 
            this.tabNumb.Controls.Add(this.gBUserAction);
            this.tabNumb.Controls.Add(this.gBNum);
            this.tabNumb.Controls.Add(this.dgvNum);
            this.tabNumb.Location = new System.Drawing.Point(4, 22);
            this.tabNumb.Name = "tabNumb";
            this.tabNumb.Padding = new System.Windows.Forms.Padding(3);
            this.tabNumb.Size = new System.Drawing.Size(666, 365);
            this.tabNumb.TabIndex = 1;
            this.tabNumb.Text = "Номера";
            this.tabNumb.UseVisualStyleBackColor = true;
            // 
            // gBUserAction
            // 
            this.gBUserAction.Controls.Add(this.btnAddRequest);
            this.gBUserAction.Location = new System.Drawing.Point(6, 204);
            this.gBUserAction.Name = "gBUserAction";
            this.gBUserAction.Size = new System.Drawing.Size(285, 154);
            this.gBUserAction.TabIndex = 7;
            this.gBUserAction.TabStop = false;
            this.gBUserAction.Text = "Действия";
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRequest.Image")));
            this.btnAddRequest.Location = new System.Drawing.Point(10, 19);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(80, 80);
            this.btnAddRequest.TabIndex = 0;
            this.btnAddRequest.UseVisualStyleBackColor = true;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // gBNum
            // 
            this.gBNum.Controls.Add(this.dateTPNum);
            this.gBNum.Controls.Add(this.btnUpdateNum);
            this.gBNum.Controls.Add(this.label1);
            this.gBNum.Location = new System.Drawing.Point(6, 7);
            this.gBNum.Name = "gBNum";
            this.gBNum.Size = new System.Drawing.Size(285, 191);
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
            this.dateTPNum.Size = new System.Drawing.Size(214, 20);
            this.dateTPNum.TabIndex = 1;
            this.dateTPNum.ValueChanged += new System.EventHandler(this.dateTPNum_ValueChanged);
            // 
            // btnUpdateNum
            // 
            this.btnUpdateNum.Enabled = false;
            this.btnUpdateNum.Location = new System.Drawing.Point(6, 160);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(271, 25);
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
            this.dgvNum.Location = new System.Drawing.Point(297, 7);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.ReadOnly = true;
            this.dgvNum.Size = new System.Drawing.Size(363, 352);
            this.dgvNum.TabIndex = 2;
            // 
            // CNumb
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CNumb.DefaultCellStyle = dataGridViewCellStyle1;
            this.CNumb.HeaderText = "№";
            this.CNumb.Name = "CNumb";
            this.CNumb.ReadOnly = true;
            this.CNumb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CNumb.Width = 40;
            // 
            // CPlace
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CPlace.DefaultCellStyle = dataGridViewCellStyle2;
            this.CPlace.HeaderText = "Кол-во мест";
            this.CPlace.Name = "CPlace";
            this.CPlace.ReadOnly = true;
            this.CPlace.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CClass
            // 
            this.CClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CClass.DefaultCellStyle = dataGridViewCellStyle3;
            this.CClass.HeaderText = "Класс комнаты";
            this.CClass.Name = "CClass";
            this.CClass.ReadOnly = true;
            this.CClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CClass.Width = 80;
            // 
            // CCost
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CCost.DefaultCellStyle = dataGridViewCellStyle4;
            this.CCost.HeaderText = "Цена";
            this.CCost.Name = "CCost";
            this.CCost.ReadOnly = true;
            // 
            // tabHotel
            // 
            this.tabHotel.Controls.Add(this.groupBox1);
            this.tabHotel.Controls.Add(this.label3);
            this.tabHotel.Controls.Add(this.label2);
            this.tabHotel.Controls.Add(this.dgvNow);
            this.tabHotel.Controls.Add(this.dgvLog);
            this.tabHotel.Location = new System.Drawing.Point(4, 22);
            this.tabHotel.Name = "tabHotel";
            this.tabHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotel.Size = new System.Drawing.Size(666, 365);
            this.tabHotel.TabIndex = 2;
            this.tabHotel.Text = "Кабинет";
            this.tabHotel.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteRequest);
            this.groupBox1.Controls.Add(this.btnEditRequest);
            this.groupBox1.Location = new System.Drawing.Point(6, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 154);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            // 
            // btnDeleteRequest
            // 
            this.btnDeleteRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRequest.Image")));
            this.btnDeleteRequest.Location = new System.Drawing.Point(117, 19);
            this.btnDeleteRequest.Name = "btnDeleteRequest";
            this.btnDeleteRequest.Size = new System.Drawing.Size(80, 80);
            this.btnDeleteRequest.TabIndex = 0;
            this.btnDeleteRequest.UseVisualStyleBackColor = true;
            this.btnDeleteRequest.Click += new System.EventHandler(this.btnDeleteRequest_Click);
            // 
            // btnEditRequest
            // 
            this.btnEditRequest.Enabled = false;
            this.btnEditRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRequest.Image")));
            this.btnEditRequest.Location = new System.Drawing.Point(20, 19);
            this.btnEditRequest.Name = "btnEditRequest";
            this.btnEditRequest.Size = new System.Drawing.Size(80, 80);
            this.btnEditRequest.TabIndex = 0;
            this.btnEditRequest.UseVisualStyleBackColor = true;
            this.btnEditRequest.Click += new System.EventHandler(this.btnEditRequest_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(369, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Журнал бронирования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(369, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Журнал проживания";
            // 
            // dgvNow
            // 
            this.dgvNow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvNow.Location = new System.Drawing.Point(225, 207);
            this.dgvNow.Name = "dgvNow";
            this.dgvNow.Size = new System.Drawing.Size(435, 152);
            this.dgvNow.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата вселения";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 110;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата выселения";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 110;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Стоимость";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dgvLog
            // 
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cNum,
            this.cInDate,
            this.cOutDate,
            this.CSessionCost});
            this.dgvLog.Location = new System.Drawing.Point(225, 24);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.Size = new System.Drawing.Size(435, 159);
            this.dgvLog.TabIndex = 1;
            // 
            // cNum
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cNum.DefaultCellStyle = dataGridViewCellStyle9;
            this.cNum.Frozen = true;
            this.cNum.HeaderText = "Номер";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            this.cNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNum.Width = 60;
            // 
            // cInDate
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cInDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.cInDate.Frozen = true;
            this.cInDate.HeaderText = "Дата вселения";
            this.cInDate.Name = "cInDate";
            this.cInDate.ReadOnly = true;
            this.cInDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cInDate.Width = 110;
            // 
            // cOutDate
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cOutDate.DefaultCellStyle = dataGridViewCellStyle11;
            this.cOutDate.Frozen = true;
            this.cOutDate.HeaderText = "Дата выселения";
            this.cOutDate.Name = "cOutDate";
            this.cOutDate.ReadOnly = true;
            this.cOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cOutDate.Width = 110;
            // 
            // CSessionCost
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CSessionCost.DefaultCellStyle = dataGridViewCellStyle12;
            this.CSessionCost.Frozen = true;
            this.CSessionCost.HeaderText = "Стоимость";
            this.CSessionCost.Name = "CSessionCost";
            this.CSessionCost.ReadOnly = true;
            this.CSessionCost.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CSessionCost.Width = 110;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(666, 365);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "О нас";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ClientWinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(680, 397);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientWinForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CLIENT terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientWinForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientWinForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabNumb.ResumeLayout(false);
            this.gBUserAction.ResumeLayout(false);
            this.gBNum.ResumeLayout(false);
            this.gBNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
            this.tabHotel.ResumeLayout(false);
            this.tabHotel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabNumb;
        private System.Windows.Forms.GroupBox gBNum;
        private System.Windows.Forms.DateTimePicker dateTPNum;
        private System.Windows.Forms.Button btnUpdateNum;
        private System.Windows.Forms.Label label1;
        protected internal System.Windows.Forms.DataGridView dgvNum;
        private System.Windows.Forms.TabPage tabHotel;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        protected internal System.Windows.Forms.DataGridView dgvNow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        protected internal System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSessionCost;
        private System.Windows.Forms.GroupBox gBUserAction;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteRequest;
        private System.Windows.Forms.Button btnEditRequest;
    }
}

