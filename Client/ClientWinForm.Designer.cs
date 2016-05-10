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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientWinForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabNumb = new System.Windows.Forms.TabPage();
            this.gBNum = new System.Windows.Forms.GroupBox();
            this.dateTPNum = new System.Windows.Forms.DateTimePicker();
            this.btnUpdateNum = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvNum = new System.Windows.Forms.DataGridView();
            this.tabHotel = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.CNumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabNumb.SuspendLayout();
            this.gBNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).BeginInit();
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
            // tabHotel
            // 
            this.tabHotel.Location = new System.Drawing.Point(4, 22);
            this.tabHotel.Name = "tabHotel";
            this.tabHotel.Padding = new System.Windows.Forms.Padding(3);
            this.tabHotel.Size = new System.Drawing.Size(666, 365);
            this.tabHotel.TabIndex = 2;
            this.tabHotel.Text = "Кабинет";
            this.tabHotel.UseVisualStyleBackColor = true;
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
            this.tabControl.ResumeLayout(false);
            this.tabNumb.ResumeLayout(false);
            this.gBNum.ResumeLayout(false);
            this.gBNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNum)).EndInit();
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
    }
}

