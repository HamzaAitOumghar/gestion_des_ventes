using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using Gestion_de_vente.Classe;

namespace Gestion_de_vente
{
    public partial class Login : Form
    {
        private Main main;
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (userName.Text.Length == 0)
            {

                errorMessage.Text = " Entrer un utilisateur !";
                errorImage.Visible = true;
                userName.Focus();

            }
            else
            {
                string username = userName.Text;
                string motdepass = passWord.Text;

                if (passWord.Text.Length == 0)
                {
                    errorMessage.Text = " Entrer un mot de pass !";
                    errorImage.Visible = true;
                    passWord.Focus();
                }
                else
                {
                    string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ventes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                    SqlConnection con = new SqlConnection(conString);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT *  FROM Client where  username='" + username + "'  and motdepass='" + motdepass + "'", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        DataContainer.nomUtilisateur = (string)dr[0];
                        this.Hide();
                        if (this.main == null)
                            main = new Main();
                        main.Show();
                    }
                    else
                    {
                        errorMessage.Text = " entrer votre nom d'utilisateur et votre mot de passe !";
                        errorImage.Visible = true;
                    }
                    con.Close();

                }


            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void userName_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
