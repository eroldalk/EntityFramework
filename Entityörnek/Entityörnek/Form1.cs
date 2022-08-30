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

           DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();


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
            
            dataGridView1.DataSource = db.TBLOGRENCİ.ToList();
            dataGridView1.Columns[3].Visible = false;  // sütünları göstermemek için
            dataGridView1.Columns[4].Visible = false;
        }
         private void btnNotListele_Click(object sender, EventArgs e)
         {
            var query = from item in db.TBLNOTLAR
                        select new {item.NOTID,item.OGR,item.DERS,item.SINAV1, 
                            item.SINAV2, item.SINAV3, item.ORTALAMA,item.DURUM };
            dataGridView1.DataSource=query.ToList();

           // dataGridView1.DataSource = db.TBLNOTLAR.ToList();
         }

         private void BtnKaydet_Click(object sender, EventArgs e)
         {
            TBLOGRENCİ t = new TBLOGRENCİ();
            t.AD=txtad.Text;
            t.SOYAD=txtsoyad.Text;
            db.TBLOGRENCİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Listeye Eklenmiştir.");

            
            //TBLDERSLER a = new TBLDERSLER();
            //a.DERSAD=txtdersad.Text;               ders kayıtı için sorun
            //db.TBLDERSLER.Add(a);
            //db.SaveChanges();
            //MessageBox.Show("Ders Listeye Eklenmiştir.");
        }


        private void BtnSil_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(txtogrenciid.Text);
            var x = db.TBLOGRENCİ.Find(id);
            db.TBLOGRENCİ.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Sistemden Silindi");
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
