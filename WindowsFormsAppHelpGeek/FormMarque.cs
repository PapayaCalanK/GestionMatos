using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppHelpGeek
{
    public partial class FormMarque : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;" +
            "Database=HelpGeek;Trusted_Connection=True";
        public FormMarque()
        {
            InitializeComponent();
        }

        private void FormMarque_Load(object sender, EventArgs e)
        {
            fillMarqueList();
        }

        private void fillMarqueList()
        {
            listBoxMarque.Items.Clear();
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
                listBoxMarque.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }

        private void listBoxMarque_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassIteme it = (ClassIteme)listBoxMarque.SelectedItem;

            int idref = it.getId();

            string lenom = listBoxMarque.SelectedItem.ToString();
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select * from MARQUE where ID_MARQUE = " + idref;
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            drp.Read();

            textBoxNom.Text = drp["Nom"].ToString();

            drp.Close();
            cn.Close();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom de la marque",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir ajouter cette marque ?",
                 "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No)
            {
                return;
            }

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string addmarque = "INSERT INTO MARQUE VALUES(@leNom)";
            SqlCommand sq = new SqlCommand(addmarque, cn);
            sq.Parameters.AddWithValue("leNom", textBoxNom.Text);

            sq.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Marque ajoutée avec succès");

            LoadMarque();

            clearFields();
        }

        private void LoadMarque()
        {
            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string strsql = "select ID_MARQUE, NOM from MARQUE order by nom";
            SqlCommand sq = new SqlCommand(strsql, cn);
            SqlDataReader drp = sq.ExecuteReader();
            listBoxMarque.Items.Clear();
            ClassIteme it;
            while (drp.Read() == true)
            {
                int id = Convert.ToInt32(drp["ID_MARQUE"]);
                string nom = drp["nom"].ToString();
                it = new ClassIteme(id, nom);
                listBoxMarque.Items.Add(it);
            }

            drp.Close();
            cn.Close();
        }

        private void clearFields()
        {
            textBoxNom.Text = "";
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            int selectmarque = listBoxMarque.SelectedIndex;
            if (selectmarque == -1)
            {
                MessageBox.Show("Choisissez une marque");
                listBoxMarque.Focus();
                return;
            }

            if (textBoxNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer le nom de la marque",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textBoxNom.Focus();
                return;
            }

            ClassIteme it = (ClassIteme)listBoxMarque.SelectedItem;
            int idref = it.getId();

            SqlConnection cn = new SqlConnection(this.strcon);
            cn.Open();
            string upmarque = "UPDATE MARQUE SET Nom = @lenom WHERE ID_MARQUE = @idmarque";
            SqlCommand sq = new SqlCommand(upmarque, cn);
            sq.Parameters.AddWithValue("lenom", textBoxNom.Text);
            sq.Parameters.AddWithValue("idmarque", idref);

            sq.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Marque modifié avec succès");

            LoadMarque();

            clearFields();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            int selectMarque = listBoxMarque.SelectedIndex;
            if (selectMarque == -1)
            {
                MessageBox.Show("Choisissez une marque");
                listBoxMarque.Focus();
                return;
            }
            DialogResult dr = MessageBox.Show("Etes vous sûr de vouloir supprimer cette marque ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }

            ClassIteme it = (ClassIteme)listBoxMarque.SelectedItem;
            int idref = it.getId();

            SqlConnection cn = null;
            SqlCommand sq = null;

            try
            {
                cn = new SqlConnection(this.strcon);
                cn.Open();
                string upmarque = "delete from Marque where ID_MARQUE = @idmarque";
                sq = new SqlCommand(upmarque, cn);
                sq.Parameters.AddWithValue("idmarque", idref);

                sq.ExecuteNonQuery();
                MessageBox.Show("Marque modifiée avec succès");
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

            LoadMarque();

            clearFields();

        }


    }
}
