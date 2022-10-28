using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitySonKısım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbSınavOgrenciEntities db = new DbSınavOgrenciEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //var degerler = db.TBLOGRENCİ.OrderBy(x => x.SEHİR).GroupBy(y => y.SEHİR)
            //    .Select(z => new { Şehir = z.Key, Toplam = z.Count() });   **group kodu**
            //dataGridView1.DataSource= degerler.ToList();


            //label1.Text=db.TBLNOTLARs.Max(x=>x.ORTALAMA).ToString();  ** en büyük ortalama
            //label1.Text = db.TBLNOTLARs.Min(x => x.ORTALAMA).ToString(); ** en küçük ortalama
            //label1.Text = db.TBLOGRENCİ.Count().ToString();
            //label1.Text = db.TBLURUNs.Count().ToString();
            //label1.Text = db.TBLURUNs.Count(X=>X.AD == "BUZDOLABI").ToString();
            //label1.Text = db.TBLURUNs.Average(X => X.FİYAT).ToString();
            label1.Text = db.TBLURUNs.Average(X => X.FİYAT).ToString();
        }
    }
}
