namespace CP1601.WForm_Start
{
    partial class WFLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WFLogin));
            this.btnLoginLikeAdmin = new System.Windows.Forms.Button();
            this.btnLoginLikeStaff = new System.Windows.Forms.Button();
            this.btnLoginLikeUser = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoginLikeAdmin
            // 
            this.btnLoginLikeAdmin.Enabled = false;
            this.btnLoginLikeAdmin.Location = new System.Drawing.Point(64, 112);
            this.btnLoginLikeAdmin.Name = "btnLoginLikeAdmin";
            this.btnLoginLikeAdmin.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeAdmin.TabIndex = 0;
            this.btnLoginLikeAdmin.Text = "Администратор";
            this.btnLoginLikeAdmin.UseVisualStyleBackColor = true;
            this.btnLoginLikeAdmin.Click += new System.EventHandler(this.btnLoginLikeAdmin_Click);
            // 
            // btnLoginLikeStaff
            // 
            this.btnLoginLikeStaff.Location = new System.Drawing.Point(64, 180);
            this.btnLoginLikeStaff.Name = "btnLoginLikeStaff";
            this.btnLoginLikeStaff.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeStaff.TabIndex = 1;
            this.btnLoginLikeStaff.Text = "Сотрудник";
            this.btnLoginLikeStaff.UseVisualStyleBackColor = true;
            this.btnLoginLikeStaff.Click += new System.EventHandler(this.btnLoginLikeStaff_Click);
            // 
            // btnLoginLikeUser
            // 
            this.btnLoginLikeUser.Enabled = false;
            this.btnLoginLikeUser.Location = new System.Drawing.Point(64, 248);
            this.btnLoginLikeUser.Name = "btnLoginLikeUser";
            this.btnLoginLikeUser.Size = new System.Drawing.Size(216, 62);
            this.btnLoginLikeUser.TabIndex = 2;
            this.btnLoginLikeUser.Text = "Клиент";
            this.btnLoginLikeUser.UseVisualStyleBackColor = true;
            this.btnLoginLikeUser.Click += new System.EventHandler(this.btnLoginLikeUser_Click);
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
            // timer
            // 
            this.timer.Interval = 46;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.label);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(343, 23);
            this.panel.TabIndex = 4;
            // 
            // WFLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 441);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnLoginLikeUser);
            this.Controls.Add(this.btnLoginLikeStaff);
            this.Controls.Add(this.btnLoginLikeAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.WFLogin_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoginLikeAdmin;
        private System.Windows.Forms.Button btnLoginLikeStaff;
        private System.Windows.Forms.Button btnLoginLikeUser;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panel;
    }
}