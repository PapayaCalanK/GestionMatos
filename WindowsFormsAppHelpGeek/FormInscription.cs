using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsAppHelpGeek
{
    public partial class FormInscription : Form
    {
        private string strcon = "Server=.\\SQLEXPRESS;Database=HelpGeek;Trusted_Connection=True";

        public FormInscription()
        {
            InitializeComponent();
        }

        private void buttonCreerCompte_Click(object sender, EventArgs e)
        {
            //  Étape 2 : Récupère les données saisies dans les champs
            string login = textBoxLogin.Text.Trim();
            string mdp = textBoxPwd.Text;
            string mdpConfirm = textBoxConfirm.Text;

            //  Vérifie que tous les champs sont remplis
            if (login == "" || mdp == "" || mdpConfirm == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifie que les deux mots de passe sont identiques
            if (mdp != mdpConfirm)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifie que le mot de passe respecte les règles (3 majuscules + 3 caractères spéciaux)
            if (!ValiderMotDePasse(mdp))
            {
                MessageBox.Show("Le mot de passe doit contenir exactement 6 caractères :\n- 3 majuscules\n- 3 parmi $, ; ou @", "Mot de passe invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                //  Vérifie si le login est déjà pris
                if (LoginExiste(login))
                {
                    MessageBox.Show("Ce login est déjà utilisé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ajoute l'utilisateur à la base de données
                AjouterUtilisateur(login, mdp);
                MessageBox.Show("Utilisateur créé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création du compte : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            this.Close(); // Ferme la fenêtre si on clique sur "Annuler"
        }

        private bool LoginExiste(string login)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    cn.Open();
                    string sql = "SELECT COUNT(*) FROM Login WHERE Nom = @login";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("login", login);
                    int nb = (int)cmd.ExecuteScalar();
                    return nb > 0; //  Retourne true si le login est déjà utilisé
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la vérification du login : " + ex.Message);
                return true;
            }
        }

        private void AjouterUtilisateur(string login, string mdp)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    cn.Open();
                    string sql = "INSERT INTO Login (Nom, Password) VALUES (@login, @mdp)";
                    SqlCommand cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("login", login);
                    cmd.Parameters.AddWithValue("mdp", mdp);
                    cmd.ExecuteNonQuery(); //  Insère le nouvel utilisateur dans la table Login
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'utilisateur : " + ex.Message);
            }
        }

        private bool ValiderMotDePasse(string mdp)
        {
            // Vérifie que le mot de passe fait exactement 6 caractères
            if (mdp.Length != 6) return false;

            int nbMaj = 0;
            int nbSpeciaux = 0;

            foreach (char c in mdp)
            {
                if (char.IsUpper(c)) nbMaj++;
                else if (c == '$' || c == ';' || c == '@') nbSpeciaux++;
            }

            //  Retourne true seulement s'il y a exactement 3 majuscules et 3 spéciaux
            return nbMaj == 3 && nbSpeciaux == 3;
        }
    }
}
