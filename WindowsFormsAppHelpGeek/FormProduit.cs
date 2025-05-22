using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHelpGeek
{
    public partial class FormProduit : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
            "Database=HelpGeek;Trusted_Connection=True";

        public int Description { get; private set; }

        public FormProduit()
        {
            InitializeComponent();
        }

        private void FormProduit_Load(object sender, EventArgs e)
        {
            fillProdList();
            fillMarqueCombo();
            fillClientCombo();
        }

        private void fillProdList()
        {
            listBoxProduit.Items.Clear();
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select ID_PROD, nom from Produit order by nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            ClassIteme it;
            while (drp.Read() == true)
            {
                int id = Convert.ToInt32(drp["ID_PROD"]);
                string nom = drp["nom"].ToString();
                it = new ClassIteme(id, nom);
                listBoxProduit.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }

        private void fillMarqueCombo()
        {
            comboBoxMarque.Items.Clear();
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select ID_MARQUE, nom from Marque order by nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            ClassIteme it;
            while (drp.Read() == true)
            {
                int id = Convert.ToInt32(drp["ID_MARQUE"]);
                string nom = drp["nom"].ToString();
                it = new ClassIteme(id, nom);
                comboBoxMarque.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }

        private void fillClientCombo()
        {
            comboBoxClient.Items.Clear();
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select ID_CLIENT, nom from CLIENT order by nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            ClassIteme it;
            while (drp.Read() == true)
            {
                int id = Convert.ToInt32(drp["ID_CLIENT"]);
                string nom = drp["nom"].ToString();
                it = new ClassIteme(id, nom);
                comboBoxClient.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }


        private void listBoxProduits_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassIteme it = (ClassIteme)listBoxProduit.SelectedItem;

            int idref = it.getId();

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select * from PRODUIT where ID_PROD = " + idref;
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            drp.Read();

            textBoxNom.Text = drp["Nom"].ToString();
            textBoxDescription.Text = drp["Description"].ToString();
            textBoxCode.Text = drp["Code"].ToString();
            dateTimePickerInstall.Value = Convert.ToDateTime(drp["Date_installation"]);

            // MTBF

            numericUpDownMTBF.Value = Convert.ToDecimal(drp["MTBF"]);

            // selection de la marque
            int curIdMarque = Convert.ToInt32(drp["ID_MARQUE"]);
            ClassIteme[] tabclItem = new ClassIteme[comboBoxMarque.Items.Count];
            comboBoxMarque.Items.CopyTo(tabclItem, 0);
           
            ClassIteme curcil = tabclItem.FirstOrDefault(x => x.getId() == curIdMarque);
            comboBoxMarque.SelectedItem = curcil;

            // selection de client

            int curIdClient = Convert.ToInt32(drp["ID_CLIENT"]);
            ClassIteme[] tabclItemclient = new ClassIteme[comboBoxClient.Items.Count];
            comboBoxClient.Items.CopyTo(tabclItemclient, 0);

            ClassIteme curclient = tabclItemclient.FirstOrDefault(x => x.getId() == curIdClient);
            comboBoxClient.SelectedItem = curclient;

            drp.Close();
            cn.Close();

        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du matériel",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            int selectMarque = comboBoxMarque.SelectedIndex;
            if (selectMarque == -1)
            {
                MessageBox.Show("Choisissez une marque");
                comboBoxMarque.Focus();
                return;
            }

            int selecClient = comboBoxClient.SelectedIndex;
            if (selecClient == -1)
            {
                MessageBox.Show("Choisissez un client");
                comboBoxClient.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir ajouter ce matériel ?",
                 "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }
  
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();

            string strsql = "INSERT INTO PRODUIT VALUES(@nom, @desc, @di," +
                " @co, @mtbf, @idm, @idc)";

            ClassIteme it1 = (ClassIteme)comboBoxMarque.SelectedItem;
            int idm = it1.getId();

            ClassIteme it2 = (ClassIteme)comboBoxClient.SelectedItem;
            int idc = it2.getId();

            SqlCommand sq = new SqlCommand(strsql, cn);
            sq.Parameters.AddWithValue("nom", textBoxNom.Text);
            sq.Parameters.AddWithValue("desc", textBoxDescription.Text);
            sq.Parameters.AddWithValue("di", dateTimePickerInstall.Value);
            sq.Parameters.AddWithValue("co", textBoxCode.Text);
            sq.Parameters.AddWithValue("mtbf", Convert.ToInt32(numericUpDownMTBF.Value));
            sq.Parameters.AddWithValue("idm", idm);
            sq.Parameters.AddWithValue("idc", idc);

            sq.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Matériel ajouté avec succès");
            fillProdList();
            clearFields();
        }

        private void clearFields()
        {
            textBoxNom.Text = textBoxDescription.Text = textBoxCode.Text = "";
            numericUpDownMTBF.Value = 0;
            comboBoxMarque.SelectedIndex = -1;
            comboBoxClient.SelectedIndex = -1;  
                
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            int selectMatos = listBoxProduit.SelectedIndex;
            if (selectMatos == -1)
            {
                MessageBox.Show("Choisissez un matériel");
                listBoxProduit.Focus();
                return;
            }

            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom du matériel",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            ClassIteme it = (ClassIteme)listBoxProduit.SelectedItem;
            int idref = it.getId();

            ClassIteme it1 = (ClassIteme)comboBoxMarque.SelectedItem;
            int idm = it1.getId();

            ClassIteme it2 = (ClassIteme)comboBoxClient.SelectedItem;
            int idc = it2.getId();

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string upprod = "UPDATE PRODUIT SET Nom = @nom ,Description = @desc, " +
                "Date_Installation = @di, Code = @Code, MTBF = @MTBF, " +
                "ID_MARQUE = @idm, ID_CLIENT = @idc WHERE ID_PROD = @idprod";

            SqlCommand sq = new SqlCommand(upprod, cn);
            sq.Parameters.AddWithValue("nom", textBoxNom.Text);
            sq.Parameters.AddWithValue("desc", textBoxDescription.Text);
            sq.Parameters.AddWithValue("di", dateTimePickerInstall.Value);
            sq.Parameters.AddWithValue("Code", textBoxCode.Text);
            sq.Parameters.AddWithValue("MTBF", Convert.ToInt32(numericUpDownMTBF.Value));
            sq.Parameters.AddWithValue("idm", idm);
            sq.Parameters.AddWithValue("idc", idc);
            sq.Parameters.AddWithValue("idprod", idref);


            sq.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Matériel modifié avec succès");

            fillProdList();
            clearFields();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            int selectProd = listBoxProduit.SelectedIndex;
            if (selectProd == -1)
            {
                MessageBox.Show("Choisissez un produit");
                listBoxProduit.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir supprimer ce produit ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            ClassIteme it = (ClassIteme)listBoxProduit.SelectedItem;
            int idref = it.getId();

            SqlConnection cn = null;
            SqlCommand sq = null;

            try
            {
                cn = new SqlConnection(this.strcon);
                cn.Open();
                string upprod = "delete from PRODUIT where ID_PROD = @idprod";
                sq = new SqlCommand(upprod, cn);
                sq.Parameters.AddWithValue("idprod", idref);

                sq.ExecuteNonQuery();
                MessageBox.Show("Produit supprimé avec succès");
            }
            catch (SqlException )
            {
                MessageBox.Show("Erreur de base de données, contactez votre administrateur système", "Error", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
            }
            catch (Exception )
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

            fillProdList();
            clearFields();

        }
    }
}
