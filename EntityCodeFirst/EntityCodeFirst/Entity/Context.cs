using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityCodeFirst.Entity
{
    public class Context: DbContext
    {
        public DbSet<Urunler> urunlers { get; set; }
        //public string UrunAd { get; set; }
        //public string UrunMarka { get; set; }
        //public string UrunKategori { get; set; }
        //public int UrunStok { get; set; }
    }
}
