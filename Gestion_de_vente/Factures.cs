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
    public partial class Factures : BaseForm
    {
        string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ventes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public Factures()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand sql = new SqlCommand("SELECT num_facture as 'Num de Facture' ,date_facture as 'Date de Facture', date_paiement as 'Date de Paiement'  FROM Facture WHERE username = '" + DataContainer.nomUtilisateur +"'", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sql;

            DataTable dataset = new DataTable();

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.FlatStyle = FlatStyle.Flat;
            col.DefaultCellStyle.BackColor =Color.FromArgb(91, 192, 222);
            col.DefaultCellStyle.Font= new Font(new FontFamily("Yu Gothic UI"),
            12.0F, FontStyle.Bold);
  
            col.UseColumnTextForButtonValue = true;
            col.Text = "Détails";
            col.Name = "Action";

            

            sda.Fill(dataset);
            bunifuCustomDataGrid1.DataSource = dataset;
            bunifuCustomDataGrid1.Columns.Add(col);
            for (int i = 0; i < bunifuCustomDataGrid1.Columns.Count; i++)
                bunifuCustomDataGrid1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            bunifuCustomDataGrid1.Columns[0].Width = 124;
            bunifuCustomDataGrid1.Columns[1].Width = 150;
            bunifuCustomDataGrid1.Columns[2].Width = 150;
            bunifuCustomDataGrid1.Columns[3].Width = 150;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex!=-1)
            {
                
                int num_fac = (int)bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["Num de Facture"].Value;
                Details det = new Details();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand sql = new SqlCommand("SELECT c.num_prod as 'Num du Produit', p.nom_prod as 'Nom de Produit', c.quantite as 'Quantite'  ,p.prix_prod*c.quantite as 'Total' FROM Contient as c ,Produit as p WHERE num_facture="+ num_fac + " AND c.num_prod=p.num_prod ;"  , con);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sql;

                DataTable dataset = new DataTable();
                sda.Fill(dataset);

                det.DataGrid.DataSource = dataset;


                for (int i = 0; i < det.DataGrid.Columns.Count; i++)
                    det.DataGrid.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

                det.DataGrid.Columns[0].Width = 124;
                det.DataGrid.Columns[1].Width = 150;
                det.DataGrid.Columns[2].Width = 150;
                det.DataGrid.Columns[3].Width = 135;

                det.LabelText = "Détails Du Facture N°" + num_fac;
                det.Show();
            }
        }
    }
}
