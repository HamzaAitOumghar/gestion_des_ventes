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
    public partial class Produits : BaseForm
    {
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ventes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Produits()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT num_prod as 'Num Du Produit' , nom_prod as 'Nom du Produit' ,desc_prod ,prix_prod  FROM Produit ", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sql;

            DataTable dataset = new DataTable();
         //   bunifuCustomDataGrid1.Rows[0].Height = 100;

            sda.Fill(dataset);

            bunifuCustomDataGrid1.DataSource = dataset;

            //bunifuCustomDataGrid1.Columns[0].Width = 400;
            //bunifuCustomDataGrid1.Columns[1].Width = 400;
            //bunifuCustomDataGrid1.Columns[2].Width = 400;

            ////bunifuCustomDataGrid1.Update();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
