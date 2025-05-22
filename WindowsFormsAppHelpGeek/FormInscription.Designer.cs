namespace WindowsFormsAppHelpGeek
{
    partial class FormInscription
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelPwd = new System.Windows.Forms.Label();
            this.textBoxPwd = new System.Windows.Forms.TextBox();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.textBoxConfirm = new System.Windows.Forms.TextBox();
            this.buttonCreerCompte = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // labelLogin
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(30, 30);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(49, 17);
            this.labelLogin.Text = "Login :";

            // textBoxLogin
            this.textBoxLogin.Location = new System.Drawing.Point(200, 27);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(200, 22);

            // labelPwd
            this.labelPwd.AutoSize = true;
            this.labelPwd.Location = new System.Drawing.Point(30, 70);
            this.labelPwd.Name = "labelPwd";
            this.labelPwd.Size = new System.Drawing.Size(100, 17);
            this.labelPwd.Text = "Mot de passe :";

            // textBoxPwd
            this.textBoxPwd.Location = new System.Drawing.Point(200, 67);
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.Size = new System.Drawing.Size(200, 22);
            this.textBoxPwd.UseSystemPasswordChar = true;
            this.textBoxPwd.ShortcutsEnabled = false; // Empêche les copier/coller dans le champ mot de passe

            // labelConfirm
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Location = new System.Drawing.Point(30, 110);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(158, 17);
            this.labelConfirm.Text = "Confirmer mot de passe :";

            // textBoxConfirm
            this.textBoxConfirm.Location = new System.Drawing.Point(200, 107);
            this.textBoxConfirm.Name = "textBoxConfirm";
            this.textBoxConfirm.Size = new System.Drawing.Size(200, 22);
            this.textBoxConfirm.UseSystemPasswordChar = true;
            this.textBoxConfirm.ShortcutsEnabled = false; // Empêche aussi les copier/coller dans le champ de confirmation

            // buttonCreerCompte
            this.buttonCreerCompte.Location = new System.Drawing.Point(50, 160);
            this.buttonCreerCompte.Name = "buttonCreerCompte";
            this.buttonCreerCompte.Size = new System.Drawing.Size(150, 40);
            this.buttonCreerCompte.Text = "Créer le compte";
            this.buttonCreerCompte.UseVisualStyleBackColor = true;
            this.buttonCreerCompte.Click += new System.EventHandler(this.buttonCreerCompte_Click);

            // buttonAnnuler
            this.buttonAnnuler.Location = new System.Drawing.Point(230, 160);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(150, 40);
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = true;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);

            // FormInscription
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelPwd);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.labelConfirm);
            this.Controls.Add(this.textBoxConfirm);
            this.Controls.Add(this.buttonCreerCompte);
            this.Controls.Add(this.buttonAnnuler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormInscription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Créer un nouveau compte";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Label labelPwd;
        private System.Windows.Forms.TextBox textBoxPwd;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox textBoxConfirm;
        private System.Windows.Forms.Button buttonCreerCompte;
        private System.Windows.Forms.Button buttonAnnuler;
    }
}
