using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entityörnek
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        private void btnlingentity_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var degerler = db.TBLNOTLAR.Where(x => x.SINAV1 < 50);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton2.Checked == true)
            {
                var degerler = db.TBLOGRENCİ.Where(x => x.AD == "ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton3.Checked == true)
            {
                var degerler = db.TBLOGRENCİ.Where(x => x.AD == Textbox1.Text || x.SOYAD == Textbox1.Text);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton4.Checked == true)
            {
                var degerler = db.TBLOGRENCİ.Select(x => new { soyadı = x.SOYAD });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton5.Checked == true)
            {
                var degerler = db.TBLOGRENCİ.Select(x =>
                new
                {
                    Ad = x.AD,
                    Soyad = x.SOYAD
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton6.Checked == true)
            {
                var degerler = db.TBLOGRENCİ.Select(x =>
                new
                {
                    Ad = x.AD.ToUpper(),
                    Soyad = x.SOYAD.ToLower()
                }).Where(x => x.Ad != "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton7.Checked == true)
            {
                var degerler = db.TBLNOTLAR.Select(x => new
                {
                    ÖğrenciAdı = x.OGR,
                    Ortalaması = x.ORTALAMA,
                    Durumu = x.DURUM == true ? "Geçti" : "Kaldı"

                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton8.Checked == true)
            {
                var degerler = db.TBLNOTLAR.SelectMany(x => db.TBLOGRENCİ.Where(y => y.ID == x.OGR),(x,y)=>
                new
                {
                    y.AD,
                    x.ORTALAMA,
                    Durumu = x.DURUM == true ? "Geçti" : "Kaldı"
                });
                dataGridView1.DataSource = degerler.ToList();
            }
        }


    }
}
