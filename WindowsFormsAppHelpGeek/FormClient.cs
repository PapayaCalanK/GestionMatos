using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHelpGeek
{
    public partial class FormClient : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
            "Database=HelpGeek;Trusted_Connection=True";
        public FormClient()
        {
            InitializeComponent();
        }

        private void FormClient_Load(object sender, EventArgs e)
        {
            LoadClient();
        }

        private void LoadClient()
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select ID_CLIENT, NOM from Client order by nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            listBoxClient.Items.Clear();
            ClassIteme it;
            while (drp.Read() == true)
            {
                int id = Convert.ToInt32(drp["ID_CLIENT"]);
                string nom = drp["nom"].ToString();
                it = new ClassIteme(id, nom);
                listBoxClient.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }

        private void listBoxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassIteme it = (ClassIteme)listBoxClient.SelectedItem;

            int idref = it.getId();

            string lenom = listBoxClient.SelectedItem.ToString();
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select * from Client where ID_CLIENT = " + idref ;
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            drp.Read();

            textBoxNom.Text = drp["Nom"].ToString();
            textBoxMail.Text = drp["Mail"].ToString();
            textBoxTel.Text = drp["Tel"].ToString();
            textBoxAdresse.Text = drp["Adresse"].ToString();

            drp.Close();
            cn.Close();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du client",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir ajouter ce client ?",
                 "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string addclient = "INSERT INTO CLIENT VALUES(@leClient,@lemail, @letel, @adresse)";
            SqlCommand sq = new SqlCommand(addclient, cn);
            sq.Parameters.AddWithValue("leClient", textBoxNom.Text);
            sq.Parameters.AddWithValue("lemail", textBoxMail.Text);
            sq.Parameters.AddWithValue("letel", textBoxTel.Text);
            sq.Parameters.AddWithValue("adresse", textBoxAdresse.Text);

            sq.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Client ajoutée avec succès");

            LoadClient();

            clearFields();

        }

        private void clearFields()
        {
            textBoxNom.Text = textBoxMail.Text = textBoxTel.Text = textBoxAdresse.Text = "";
        }

        private void buttonItemClear_Click(object sender, EventArgs e)
        {
            this.clearFields();
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            int selectClient = listBoxClient.SelectedIndex;
            if (selectClient == -1)
            {
                MessageBox.Show("Choisissez un client");
                listBoxClient.Focus();
                return;
            }

            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du client",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            ClassIteme it = (ClassIteme)listBoxClient.SelectedItem;
            int idref = it.getId();

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string upclient = "UPDATE CLIENT SET Nom = @leClient ,Mail = @lemail, " +
                "Tel = @letel, Adresse = @adresse WHERE ID_CLIENT = @idclient";
            SqlCommand sq = new SqlCommand(upclient, cn);
            sq.Parameters.AddWithValue("leClient", textBoxNom.Text);
            sq.Parameters.AddWithValue("lemail", textBoxMail.Text);
            sq.Parameters.AddWithValue("letel", textBoxTel.Text);
            sq.Parameters.AddWithValue("adresse", textBoxAdresse.Text);
            sq.Parameters.AddWithValue("idclient", idref);

            sq.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Client modifié avec succès");

            LoadClient();

            clearFields();

        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            int selectClient = listBoxClient.SelectedIndex;
            if (selectClient == -1)
            {
                MessageBox.Show("Choisissez un client");
                listBoxClient.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir supprimer ce client ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            ClassIteme it = (ClassIteme)listBoxClient.SelectedItem;
            int idref = it.getId();

            SqlConnection cn = null; 
            SqlCommand sq = null;

            try
            {
                cn = new SqlConnection(this.strcon);
                cn.Open();
                string upclient = "delete from CLIENT where ID_CLIENT = @idclient";
                sq = new SqlCommand(upclient, cn);
                sq.Parameters.AddWithValue("idclient", idref);

                sq.ExecuteNonQuery();
                MessageBox.Show("Client supprimé avec succès");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur de base de données, contactez votre administrateur système", "Error", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contactez votre administrateur système", "Error", MessageBoxButtons.OK,
                     MessageBoxIcon.Error);
            }
            finally
            {
                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }
                if (sq != null)
                {
                    sq.Dispose();
                }
            }

            LoadClient();

            clearFields();

        }
    }
}
