namespace Client.Sided_Form
{
    partial class AddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxComm = new System.Windows.Forms.RichTextBox();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelRoomC = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelRoomT = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelRoomN = new System.Windows.Forms.Label();
            this.labelRoomQ = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxComm);
            this.groupBox2.Controls.Add(this.dtpCheckOut);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpCheckIn);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(316, 174);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информаци о номере";
            // 
            // textBoxComm
            // 
            this.textBoxComm.Location = new System.Drawing.Point(98, 72);
            this.textBoxComm.Name = "textBoxComm";
            this.textBoxComm.Size = new System.Drawing.Size(212, 95);
            this.textBoxComm.TabIndex = 9;
            this.textBoxComm.Text = "";
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckOut.Location = new System.Drawing.Point(98, 46);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(212, 20);
            this.dtpCheckOut.TabIndex = 8;
            this.dtpCheckOut.Value = new System.DateTime(2016, 4, 14, 0, 0, 0, 0);
            this.dtpCheckOut.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Дата выселения";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCheckIn.Location = new System.Drawing.Point(98, 18);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(212, 20);
            this.dtpCheckIn.TabIndex = 7;
            this.dtpCheckIn.Value = new System.DateTime(2016, 4, 13, 0, 0, 0, 0);
            this.dtpCheckIn.ValueChanged += new System.EventHandler(this.dtpCheckIn_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Комментарий";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Дата вселения";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelRoomC);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.labelRoomT);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.labelRoomN);
            this.groupBox4.Controls.Add(this.labelRoomQ);
            this.groupBox4.Location = new System.Drawing.Point(12, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(316, 74);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Панель вывода";
            // 
            // labelRoomC
            // 
            this.labelRoomC.AutoSize = true;
            this.labelRoomC.Location = new System.Drawing.Point(244, 41);
            this.labelRoomC.Name = "labelRoomC";
            this.labelRoomC.Size = new System.Drawing.Size(13, 13);
            this.labelRoomC.TabIndex = 14;
            this.labelRoomC.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(167, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Кол-во дней в отеле: ";
            // 
            // labelRoomT
            // 
            this.labelRoomT.AutoSize = true;
            this.labelRoomT.Location = new System.Drawing.Point(288, 19);
            this.labelRoomT.Name = "labelRoomT";
            this.labelRoomT.Size = new System.Drawing.Size(13, 13);
            this.labelRoomT.TabIndex = 12;
            this.labelRoomT.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Цена: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Номер комнаты: ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Кол-во мест в комнате: ";
            // 
            // labelRoomN
            // 
            this.labelRoomN.AutoSize = true;
            this.labelRoomN.Location = new System.Drawing.Point(142, 19);
            this.labelRoomN.Name = "labelRoomN";
            this.labelRoomN.Size = new System.Drawing.Size(13, 13);
            this.labelRoomN.TabIndex = 11;
            this.labelRoomN.Text = "0";
            // 
            // labelRoomQ
            // 
            this.labelRoomQ.AutoSize = true;
            this.labelRoomQ.Location = new System.Drawing.Point(142, 41);
            this.labelRoomQ.Name = "labelRoomQ";
            this.labelRoomQ.Size = new System.Drawing.Size(13, 13);
            this.labelRoomQ.TabIndex = 10;
            this.labelRoomQ.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Location = new System.Drawing.Point(12, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(316, 59);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Панель управления";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(98, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 30);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 341);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ADD Request";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddForm_FormClosing);
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox textBoxComm;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelRoomC;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelRoomT;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelRoomN;
        private System.Windows.Forms.Label labelRoomQ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
    }
}