﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Skiil_CodeFirstEntity.Models.Siniflar
{
    public class Yetenekler
    {
        [Key]
        public int ID { get; set; }
        public string ACIKLAMA { get; set; }
        public byte DEGER { get; set; }
    }
}