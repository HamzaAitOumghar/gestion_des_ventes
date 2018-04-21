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
            SqlCommand sql = new SqlCommand("SELECT *  FROM Facture ", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = sql;

            DataTable dataset = new DataTable();

            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.FlatStyle = FlatStyle.Flat;
            col.DefaultCellStyle.BackColor =Color.FromArgb(91, 192, 222);
            col.DefaultCellStyle.Font= new Font(new FontFamily("Yu Gothic UI"),
            12.0F, FontStyle.Bold);
  
            col.UseColumnTextForButtonValue = true;
            col.Text = "Details";
            col.Name = "Details";

            

            sda.Fill(dataset);
            bunifuCustomDataGrid1.DataSource = dataset;
            bunifuCustomDataGrid1.Columns.Add(col);


             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuCustomDataGrid1.Columns[e.ColumnIndex].Name == "Details" && e.RowIndex!=-1)
            {
                
                int num_fac = (int)bunifuCustomDataGrid1.Rows[e.RowIndex].Cells["num_facture"].Value;
                Details det = new Details();
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand sql = new SqlCommand("SELECT c.num_prod , p.nom_prod , c.quantite  ,p.prix_prod*c.quantite as 'Total' FROM Contient as c ,Produit as p WHERE num_facture="+ num_fac + " AND c.num_prod=p.num_prod ;"  , con);
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = sql;

                DataTable dataset = new DataTable();
                sda.Fill(dataset);

                det.DataGrid.DataSource = dataset;


                //// det.LabelText= bunifuCustomDataGrid1.Rows[]
                 det.Show();
            }
        }
    }
}
