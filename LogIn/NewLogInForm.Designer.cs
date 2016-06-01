namespace LogIn
{
    partial class NewLogInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLogInForm));
            this.labelName = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.labelHello = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic);
            this.labelName.Location = new System.Drawing.Point(12, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 25);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "ID";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPassword.Location = new System.Drawing.Point(7, 78);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(84, 25);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Password";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(12, 117);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(125, 35);
            this.btnReg.TabIndex = 3;
            this.btnReg.TabStop = false;
            this.btnReg.Text = "Регистрация";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(147, 117);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(125, 35);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Вход";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            this.btnEnter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnEnter_KeyDown);
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(102, 47);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(170, 20);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxID_KeyDown);
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(102, 83);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(170, 20);
            this.textBoxPass.TabIndex = 1;
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxID_KeyDown);
            // 
            // labelHello
            // 
            this.labelHello.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHello.Location = new System.Drawing.Point(12, 9);
            this.labelHello.Name = "labelHello";
            this.labelHello.Size = new System.Drawing.Size(260, 33);
            this.labelHello.TabIndex = 4;
            this.labelHello.Text = "Welcome";
            this.labelHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewLogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.labelHello);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewLogInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NemLogInForm_FormClosing);
            this.Load += new System.EventHandler(this.NemLogInForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Label labelHello;
    }
}