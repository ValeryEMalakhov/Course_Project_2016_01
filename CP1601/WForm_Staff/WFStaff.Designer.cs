namespace CP1601.WForm_Staff
{
    partial class WfStaff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WfStaff));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabUser = new System.Windows.Forms.TabPage();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cInDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabNumb = new System.Windows.Forms.TabPage();
            this.tabHotel = new System.Windows.Forms.TabPage();
            this.btnUpdateNum = new System.Windows.Forms.Button();
            this.dgvNum = new System.Windows.Forms.DataGridView();
            this.CNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gBNum = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTPNum = new System.Windows.Forms.DateTimePicker();
            this.gBUser = new System.Windows.Forms.GroupBox();
            this.dateTPUser = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tabNumb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
            this.gBNum.SuspendLayout();
            this.gBUser.SuspendLayout();
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
            this.tabControl.TabIndex = 0;
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.gBUser);
            this.tabUser.Controls.Add(this.btnUpdateUser);
            this.tabUser.Controls.Add(this.dgvUser);
            this.tabUser.Location = new System.Drawing.Point(4, 22);
            this.tabUser.Name = "tabUser";
            this.tabUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabUser.Size = new System.Drawing.Size(936, 533);
            this.tabUser.TabIndex = 0;
            this.tabUser.Text = "Постояльцы";
            this.tabUser.UseVisualStyleBackColor = true;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(220, 502);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateUser.TabIndex = 1;
            this.btnUpdateUser.Text = "Обновить";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.cOutDate});
            this.dgvUser.Location = new System.Drawing.Point(326, 6);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.Size = new System.Drawing.Size(605, 521);
            this.dgvUser.TabIndex = 0;
            // 
            // cName
            // 
            this.cName.Frozen = true;
            this.cName.HeaderText = "Имя";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cName.Width = 110;
            // 
            // cSName
            // 
            this.cSName.Frozen = true;
            this.cSName.HeaderText = "Фамилия";
            this.cSName.Name = "cSName";
            this.cSName.ReadOnly = true;
            this.cSName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cSName.Width = 130;
            // 
            // cGender
            // 
            this.cGender.Frozen = true;
            this.cGender.HeaderText = "Пол";
            this.cGender.Name = "cGender";
            this.cGender.ReadOnly = true;
            this.cGender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cGender.Width = 40;
            // 
            // cNum
            // 
            this.cNum.Frozen = true;
            this.cNum.HeaderText = "Номер";
            this.cNum.Name = "cNum";
            this.cNum.ReadOnly = true;
            this.cNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cNum.Width = 60;
            // 
            // cInDate
            // 
            this.cInDate.Frozen = true;
            this.cInDate.HeaderText = "Дата вселения";
            this.cInDate.Name = "cInDate";
            this.cInDate.ReadOnly = true;
            this.cInDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cInDate.Width = 110;
            // 
            // cOutDate
            // 
            this.cOutDate.Frozen = true;
            this.cOutDate.HeaderText = "Дата выселения";
            this.cOutDate.Name = "cOutDate";
            this.cOutDate.ReadOnly = true;
            this.cOutDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cOutDate.Width = 110;
            // 
            // tabNumb
            // 
            this.tabNumb.Controls.Add(this.gBNum);
            this.tabNumb.Controls.Add(this.btnUpdateNum);
            this.tabNumb.Controls.Add(this.dgvNum);
            this.tabNumb.Location = new System.Drawing.Point(4, 22);
            this.tabNumb.Name = "tabNumb";
            this.tabNumb.Padding = new System.Windows.Forms.Padding(3);
            this.tabNumb.Size = new System.Drawing.Size(936, 533);
            this.tabNumb.TabIndex = 1;
            this.tabNumb.Text = "Номера";
            this.tabNumb.UseVisualStyleBackColor = true;
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
            // btnUpdateNum
            // 
            this.btnUpdateNum.Location = new System.Drawing.Point(220, 502);
            this.btnUpdateNum.Name = "btnUpdateNum";
            this.btnUpdateNum.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateNum.TabIndex = 3;
            this.btnUpdateNum.Text = "Обновить";
            this.btnUpdateNum.UseVisualStyleBackColor = true;
            this.btnUpdateNum.Click += new System.EventHandler(this.btnUpdateNum_Click);
            // 
            // dgvNum
            // 
            this.dgvNum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNumb,
            this.CPlace,
            this.CClass});
            this.dgvNum.Location = new System.Drawing.Point(326, 6);
            this.dgvNum.Name = "dgvNum";
            this.dgvNum.Size = new System.Drawing.Size(605, 521);
            this.dgvNum.TabIndex = 2;
            // 
            // CNumb
            // 
            this.CNumb.Frozen = true;
            this.CNumb.HeaderText = "№";
            this.CNumb.Name = "CNumb";
            this.CNumb.ReadOnly = true;
            this.CNumb.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CNumb.Width = 40;
            // 
            // CPlace
            // 
            this.CPlace.Frozen = true;
            this.CPlace.HeaderText = "Кол-во мест";
            this.CPlace.Name = "CPlace";
            this.CPlace.ReadOnly = true;
            this.CPlace.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CClass
            // 
            this.CClass.Frozen = true;
            this.CClass.HeaderText = "Класс комнаты";
            this.CClass.Name = "CClass";
            this.CClass.ReadOnly = true;
            this.CClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CClass.Width = 80;
            // 
            // gBNum
            // 
            this.gBNum.Controls.Add(this.dateTPNum);
            this.gBNum.Controls.Add(this.label1);
            this.gBNum.Location = new System.Drawing.Point(5, 3);
            this.gBNum.Name = "gBNum";
            this.gBNum.Size = new System.Drawing.Size(315, 191);
            this.gBNum.TabIndex = 4;
            this.gBNum.TabStop = false;
            this.gBNum.Text = "Фильтры";
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
            // gBUser
            // 
            this.gBUser.Controls.Add(this.dateTPUser);
            this.gBUser.Controls.Add(this.label2);
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
            // WfStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 561);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WfStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STAFF terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WFStaff_FormClosing);
            this.Load += new System.EventHandler(this.WFStaff_Load);
            this.tabControl.ResumeLayout(false);
            this.tabUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tabNumb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
            this.gBNum.ResumeLayout(false);
            this.gBNum.PerformLayout();
            this.gBUser.ResumeLayout(false);
            this.gBUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUser;
        private System.Windows.Forms.TabPage tabNumb;
        private System.Windows.Forms.TabPage tabHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn cInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cOutDate;
        private System.Windows.Forms.Button btnUpdateUser;
        protected internal System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.Button btnUpdateNum;
        protected internal System.Windows.Forms.DataGridView dgvNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn CClass;
        private System.Windows.Forms.GroupBox gBNum;
        private System.Windows.Forms.DateTimePicker dateTPNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBUser;
        private System.Windows.Forms.DateTimePicker dateTPUser;
        private System.Windows.Forms.Label label2;
    }
}