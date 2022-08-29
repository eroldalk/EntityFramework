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

namespace Entityörnek
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnDersListesi_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DbSınavOgrenci;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * From tbldersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource=dt;

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
        }

























     
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }


         private void button1_Click(object sender, EventArgs e)
         {

         }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
