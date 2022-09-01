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
            dataGridView1.DataSource = dt;

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
                        select new
                        {
                            item.NOTID,
                            item.TBLOGRENCİ.AD,
                            item.TBLOGRENCİ.SOYAD,
                            item.TBLDERSLER.DERSAD,
                            item.DERS,
                            item.SINAV1,
                            item.SINAV2,
                            item.SINAV3,
                            item.ORTALAMA,
                            item.DURUM
                        };
            dataGridView1.DataSource = query.ToList();

            // dataGridView1.DataSource = db.TBLNOTLAR.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            TBLOGRENCİ t = new TBLOGRENCİ();
            t.AD = txtad.Text;
            t.SOYAD = txtsoyad.Text;
            db.TBLOGRENCİ.Add(t);
            db.SaveChanges();
            int deger = db.SaveChanges();
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

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtogrenciid.Text);
            var y = db.TBLOGRENCİ.Find(id);
            y.AD = txtad.Text;
            y.SOYAD = txtsoyad.Text;
            y.FOTOGRAF = txtfoto.Text;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Bilgileri Başarıyla Güncellendi");
        }
        private void btnprosedur_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTESI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLOGRENCİ.Where(x => x.AD == txtad.Text | x.SOYAD == txtsoyad.Text).ToList();


            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
        }
        private void txtad_TextChanged(object sender, EventArgs e)
        {
            string aranan = txtad.Text;
            var degerler = from item in db.TBLOGRENCİ          //aradığın kişiyi bulma textsoyad
                           where item.AD.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
        }

        private void btnlingentity_Click(object sender, EventArgs e)
        {
            //asc -ascending sıralama
            if (radioButton1.Checked == true)
            {
                List<TBLOGRENCİ> liste1 = db.TBLOGRENCİ.OrderBy(P => P.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            //desc - descending
            if (radioButton2.Checked == true)
            {
                List<TBLOGRENCİ> liste2 = db.TBLOGRENCİ.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked == true)
            {
                List<TBLOGRENCİ> liste3 = db.TBLOGRENCİ.OrderByDescending(p => p.AD).Take(5).ToList();
                dataGridView1.DataSource = liste3;
            }
            if (radioButton4.Checked == true)
            {
                List<TBLOGRENCİ> liste4 = db.TBLOGRENCİ.Where(p => p.ID == 6).ToList();
                dataGridView1.DataSource = liste4;
            }
            if (radioButton5.Checked == true)
            {
                List<TBLOGRENCİ> liste5 = db.TBLOGRENCİ.Where(p => p.AD.StartsWith("A")).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked == true)
            {
                List<TBLOGRENCİ> liste6 = db.TBLOGRENCİ.Where(p => p.AD.EndsWith("A")).ToList();
                dataGridView1.DataSource = liste6;
            }
            if (radioButton7.Checked == true)
            {
                bool deger = db.TBLKULUPLER.Any();
                MessageBox.Show(deger.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton8.Checked == true)
            {
                int toplam = db.TBLOGRENCİ.Count();
                MessageBox.Show(toplam.ToString(), "Toplam Öğrenci Sayısı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton9.Checked == true)
            {
                var toplam = db.TBLNOTLAR.Sum(p => p.SINAV1);
                MessageBox.Show("Sınav1 Toplam Puanı: " + toplam.ToString());
            }
            if (radioButton10.Checked == true)
            {
                var ortalama = db.TBLNOTLAR.Average(p => p.SINAV1);
                MessageBox.Show("1.Sınavın Ortalaması:  " + ortalama.ToString());
            }
            if (radioButton11.Checked == true)
            {
                var ortalama = db.TBLNOTLAR.Average(p => p.SINAV1);
                List<TBLNOTLAR> liste = db.TBLNOTLAR.Where(p => p.SINAV1 > ortalama).ToList();
                dataGridView1.DataSource = liste;
            }
            if (radioButton12.Checked == true)
            {
                var enyuksek = db.TBLNOTLAR.Max(p => p.SINAV1);
                MessageBox.Show("1.Sınavın En Yüksek Notu" + enyuksek);


            }
            if (radioButton13.Checked == true)
            {
                var endusuk = db.TBLNOTLAR.Min(p => p.SINAV1);
                MessageBox.Show("1.Sınavın En Düşük Notu" + endusuk);
            }
            if (radioButton14.Checked == true)
            {
                var yuksekalan = db.TBLNOTLAR.Max(p => p.SINAV1);
                var a = from item in db.NOTLISTESI()
                        where item.SINAV1 == yuksekalan
                        select new
                        {
                            item.AD_SOYAD,
                            item.DERSAD,
                            item.SINAV1
                        };
                dataGridView1.DataSource = a.ToList();

            }
        }
        private void btnjoin_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBLNOTLAR
                        join d2 in db.TBLOGRENCİ
                        on d1.OGR equals d2.ID
                        join d3 in db.TBLDERSLER
                        on d1.DERS equals d3.DERSID


                        select new
                        {

                            ÖĞRENCİ = d2.AD + " " + d2.SOYAD,
                            DERS=d3.DERSAD,
                            SINAV1 = d1.SINAV1,
                            SINAV2 = d1.SINAV2,
                            SINAV3 = d1.SINAV3,
                            ORTALAMA = d1.ORTALAMA
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }













        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}
