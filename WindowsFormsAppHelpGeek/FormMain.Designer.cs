namespace WindowsFormsAppHelpGeek
{
    partial class FormMain
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

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemGe = new System.Windows.Forms.ToolStripMenuItem();
            this.matérielToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fermerToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.fermerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemInscription = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerInstall = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCommentaire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxMatos = new System.Windows.Forms.ComboBox();
            this.buttonCreerInter = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMatos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClient = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMarque = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonByeBye = new System.Windows.Forms.ToolStripButton();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemGe,
            this.ToolStripMenuItemInscription});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItemGe
            // 
            this.ToolStripMenuItemGe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matérielToolStripMenuItem,
            this.clientToolStripMenuItem,
            this.marqueToolStripMenuItem,
            this.fermerToolStripMenuItem,
            this.fermerToolStripMenuItem1});
            this.ToolStripMenuItemGe.Name = "ToolStripMenuItemGe";
            this.ToolStripMenuItemGe.Size = new System.Drawing.Size(73, 24);
            this.ToolStripMenuItemGe.Text = "Gestion";
            // 
            // matérielToolStripMenuItem
            // 
            this.matérielToolStripMenuItem.Name = "matérielToolStripMenuItem";
            this.matérielToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.matérielToolStripMenuItem.Text = "Matériel ...";
            this.matérielToolStripMenuItem.Click += new System.EventHandler(this.matérielToolStripMenuItem_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.clientToolStripMenuItem.Text = "Client ...";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // marqueToolStripMenuItem
            // 
            this.marqueToolStripMenuItem.Name = "marqueToolStripMenuItem";
            this.marqueToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.marqueToolStripMenuItem.Text = "Marque ...";
            this.marqueToolStripMenuItem.Click += new System.EventHandler(this.marqueToolStripMenuItem_Click);
            // 
            // fermerToolStripMenuItem
            // 
            this.fermerToolStripMenuItem.Name = "fermerToolStripMenuItem";
            this.fermerToolStripMenuItem.Size = new System.Drawing.Size(158, 6);
            // 
            // fermerToolStripMenuItem1
            // 
            this.fermerToolStripMenuItem1.Name = "fermerToolStripMenuItem1";
            this.fermerToolStripMenuItem1.Size = new System.Drawing.Size(161, 26);
            this.fermerToolStripMenuItem1.Text = "Fermer ...";
            this.fermerToolStripMenuItem1.Click += new System.EventHandler(this.fermerToolStripMenuItem1_Click);
            // 
            // ToolStripMenuItemInscription
            // Ajout  du bouton inscription
            this.ToolStripMenuItemInscription.Name = "ToolStripMenuItemInscription";
            this.ToolStripMenuItemInscription.Size = new System.Drawing.Size(94, 24);
            this.ToolStripMenuItemInscription.Text = "Inscription";
            this.ToolStripMenuItemInscription.Click += new System.EventHandler(this.ToolStripMenuItemInscription_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCreerInter);
            this.groupBox1.Controls.Add(this.comboBoxMatos);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxPrix);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCommentaire);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePickerInstall);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 230);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intervention";
            // 
            // label1
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Text = "Date d'intervention :";
            // 
            this.dateTimePickerInstall.Location = new System.Drawing.Point(160, 27);
            this.dateTimePickerInstall.Size = new System.Drawing.Size(200, 22);
            // 
            // label2
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Text = "Commentaire :";
            // 
            this.textBoxCommentaire.Location = new System.Drawing.Point(160, 67);
            this.textBoxCommentaire.Size = new System.Drawing.Size(400, 22);
            // 
            // label3
            this.label3.Location = new System.Drawing.Point(20, 110);
            this.label3.Text = "Prix :";
            // 
            this.textBoxPrix.Location = new System.Drawing.Point(160, 107);
            this.textBoxPrix.Size = new System.Drawing.Size(100, 22);
            // 
            // label4
            this.label4.Location = new System.Drawing.Point(20, 150);
            this.label4.Text = "Matériel :";
            // 
            this.comboBoxMatos.Location = new System.Drawing.Point(160, 147);
            this.comboBoxMatos.Size = new System.Drawing.Size(200, 24);
            // 
            this.buttonCreerInter.Text = "Créer une intervention";
            this.buttonCreerInter.Location = new System.Drawing.Point(500, 180);
            this.buttonCreerInter.Click += new System.EventHandler(this.buttonCreerInter_Click);
            // 
            // toolStrip1
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMatos,
            this.toolStripButtonClient,
            this.toolStripButtonMarque,
            this.toolStripButtonByeBye});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 2;

            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Help Geek";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGe;
        private System.Windows.Forms.ToolStripMenuItem matérielToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator fermerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fermerToolStripMenuItem1;
        //Ajout du bouton inscription
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemInscription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCreerInter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxMatos;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCommentaire;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerInstall;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMatos;
        private System.Windows.Forms.ToolStripButton toolStripButtonClient;
        private System.Windows.Forms.ToolStripButton toolStripButtonMarque;
        private System.Windows.Forms.ToolStripButton toolStripButtonByeBye;
    }
}