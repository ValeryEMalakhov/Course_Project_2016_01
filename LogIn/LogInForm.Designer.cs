namespace LogIn
{
    partial class WfLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WfLogin));
            this.panel = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.btnLoginLikeUser = new System.Windows.Forms.Button();
            this.btnLoginLikeStaff = new System.Windows.Forms.Button();
            this.btnLoginLikeAdmin = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.textBoxLoginId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label);
            this.panel.Location = new System.Drawing.Point(0, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(343, 23);
            this.panel.TabIndex = 8;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(178, 5);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(342, 13);
            this.label.TabIndex = 3;
            this.label.Text = "Это только заглушка для входа под различными пользователями";
            // 
            // btnLoginLikeUser
            // 
            this.btnLoginLikeUser.Location = new System.Drawing.Point(65, 250);
            this.btnLoginLikeUser.Name = "btnLoginLikeUser";
            this.btnLoginLikeUser.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeUser.TabIndex = 7;
            this.btnLoginLikeUser.Text = "Клиент";
            this.btnLoginLikeUser.UseVisualStyleBackColor = true;
            this.btnLoginLikeUser.Click += new System.EventHandler(this.btnLoginLikeUser_Click);
            // 
            // btnLoginLikeStaff
            // 
            this.btnLoginLikeStaff.Location = new System.Drawing.Point(65, 182);
            this.btnLoginLikeStaff.Name = "btnLoginLikeStaff";
            this.btnLoginLikeStaff.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeStaff.TabIndex = 6;
            this.btnLoginLikeStaff.Text = "Сотрудник";
            this.btnLoginLikeStaff.UseVisualStyleBackColor = true;
            this.btnLoginLikeStaff.Click += new System.EventHandler(this.btnLoginLikeStaff_Click);
            // 
            // btnLoginLikeAdmin
            // 
            this.btnLoginLikeAdmin.Enabled = false;
            this.btnLoginLikeAdmin.Location = new System.Drawing.Point(65, 114);
            this.btnLoginLikeAdmin.Name = "btnLoginLikeAdmin";
            this.btnLoginLikeAdmin.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeAdmin.TabIndex = 5;
            this.btnLoginLikeAdmin.Text = "Администратор";
            this.btnLoginLikeAdmin.UseVisualStyleBackColor = true;
            this.btnLoginLikeAdmin.Click += new System.EventHandler(this.btnLoginLikeAdmin_Click);
            // 
            // timer
            // 
            this.timer.Interval = 46;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // textBoxLoginId
            // 
            this.textBoxLoginId.Location = new System.Drawing.Point(65, 318);
            this.textBoxLoginId.Name = "textBoxLoginId";
            this.textBoxLoginId.Size = new System.Drawing.Size(216, 20);
            this.textBoxLoginId.TabIndex = 9;
            this.textBoxLoginId.Text = "GB 22 333 333";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Client ID";
            // 
            // WfLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 441);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLoginId);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnLoginLikeUser);
            this.Controls.Add(this.btnLoginLikeStaff);
            this.Controls.Add(this.btnLoginLikeAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WfLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WfLogin_FormClosing);
            this.Load += new System.EventHandler(this.WfLogin_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnLoginLikeUser;
        private System.Windows.Forms.Button btnLoginLikeStaff;
        private System.Windows.Forms.Button btnLoginLikeAdmin;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox textBoxLoginId;
        private System.Windows.Forms.Label label1;
    }
}

