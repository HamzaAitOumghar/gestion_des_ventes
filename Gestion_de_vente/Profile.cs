using Gestion_de_vente.Classe;
using Gestion_de_vente.Resources;
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

namespace Gestion_de_vente
{
    public partial class Profile : BaseForm 
    {
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ventes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Profile()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT *  FROM Client WHERE username= '" + DataContainer.nomUtilisateur +"'", con);
            SqlDataReader oReader = sql.ExecuteReader();
            oReader.Read();
            bunifuCustomLabel2.Text = oReader["nom"].ToString() +" "+ oReader["prenom"].ToString();
            bunifuCustomLabel3.Text = oReader["adresse"].ToString();
            bunifuCustomLabel4.Text = oReader["ville"].ToString();
            bunifuCustomLabel5.Text = "0"+oReader["num_tel"].ToString();

            con.Close();
     

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
