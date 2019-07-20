using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Musteriler")]
    public class Musteri:EntityBase
    {
        [Required, StringLength(25)]
        public string Ad_Soyad { get; set; }

        [Required, StringLength(25)]
        public string Tel_No { get; set; }

        [StringLength(150)]
        public string Adres { get; set; }

        //public virtual List<Urun> Urunler { get; set; }

    }
}
