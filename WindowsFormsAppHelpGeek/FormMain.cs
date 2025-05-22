using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppHelpGeek
{
    public partial class FormMain : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;Database=HelpGeek;Trusted_Connection=True";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                loadMatos();

                bool res = false;

                do
                {
                    FormLogin dlg = new FormLogin();
                    DialogResult dr = dlg.ShowDialog();

                    if (dr == DialogResult.Cancel)
                    {
                        Application.Exit();
                        Application.DoEvents();
                        res = true;
                    }

                    if (dr == DialogResult.OK)
                    {
                        string login = dlg.getLogin();
                        string pwd = dlg.getPwd();

                        res = this.checkConnexion(login, pwd);

                        if (res == false)
                        {
                            MessageBox.Show("Identifiants incorrects",
                                "Warning", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
                while (res == false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur critique au lancement : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadMatos()
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string strsql = "select nom from Produit order by nom";

            SqlCommand sq = new SqlCommand(strsql, cn);

            SqlDataReader drp = sq.ExecuteReader();
            comboBoxMatos.Items.Clear();

            while (drp.Read() == true)
            {
                string pro = drp["nom"].ToString();
                comboBoxMatos.Items.Add(pro);
            }

            drp.Close();
            cn.Close();
        }

        private bool checkConnexion(string lelogin, string lepwd)
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string strsql = "select count(*) as nb from Login where Nom = @lenom and Password = @lepwd";

            SqlCommand sq = new SqlCommand(strsql, cn);
            sq.Parameters.AddWithValue("lenom", lelogin);
            sq.Parameters.AddWithValue("lepwd", lepwd);

            SqlDataReader dr = sq.ExecuteReader();
            dr.Read();
            int nb = Convert.ToInt32(dr["nb"]);

            dr.Close();
            cn.Close();

            return nb > 0;
        }

        private void buttonCreerInter_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir créer cette intervention ?",
               "Confirmation", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            string prix = textBoxPrix.Text;
            decimal res;
            bool b = Decimal.TryParse(prix, out res);

            if (!b)
            {
                MessageBox.Show("Prix incorrect", "Erreur");
                textBoxPrix.Focus();
                return;
            }

            int posprod = comboBoxMatos.SelectedIndex;
            if (posprod == -1)
            {
                MessageBox.Show("Choisissez un produit", "Erreur");
                comboBoxMatos.Focus();
                return;
            }

            int idmatos = getProduitID(comboBoxMatos.SelectedItem.ToString());
            AddInter(res, idmatos);
            MajDateInstall(idmatos, dateTimePickerInstall.Value);
        }

        private void MajDateInstall(int idMatos, DateTime dateInstall)
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string majsql = "UPDATE PRODUIT SET Date_Installation = @ladate WHERE ID_PROD = @idpr";
            SqlCommand sq = new SqlCommand(majsql, cn);
            sq.Parameters.AddWithValue("ladate", dateInstall);
            sq.Parameters.AddWithValue("idpr", idMatos);
            sq.ExecuteNonQuery();

            cn.Close();
        }

        private void AddInter(decimal res, int idmatos)
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string addinter = "INSERT INTO INTERVENTION VALUES(@ladate, @lecomment, @leprix, @lid)";
            SqlCommand sq = new SqlCommand(addinter, cn);
            sq.Parameters.AddWithValue("ladate", dateTimePickerInstall.Value);
            sq.Parameters.AddWithValue("lecomment", textBoxCommentaire.Text);
            sq.Parameters.AddWithValue("leprix", res);
            sq.Parameters.AddWithValue("lid", idmatos);
            sq.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Intervention réussie", "Résultat");
        }

        private int getProduitID(string produit)
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string strsql = "select ID_PROD from PRODUIT where Nom = @nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            sq.Parameters.AddWithValue("nom", produit);

            SqlDataReader dr = sq.ExecuteReader();
            dr.Read();
            int id = Convert.ToInt32(dr["ID_PROD"]);
            dr.Close();
            cn.Close();

            return id;
        }

        private void marqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMarque frm = new FormMarque();
            frm.ShowDialog();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClient frm = new FormClient();
            frm.ShowDialog();
        }

        private void matérielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProduit frm = new FormProduit();
            frm.ShowDialog();
        }

        private void fermerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir quitter ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void listViewIntervention_recent_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        // ✅ Menu inscription
        private void ToolStripMenuItemInscription_Click(object sender, EventArgs e)
        {
            FormInscription frm = new FormInscription();
            frm.ShowDialog();
        }
    }

    internal class DateInter
    {
        internal static bool TryGetValue(string produitRecherche, out List<string> dates)
        {
            throw new NotImplementedException();
        }
    }
}
