using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Urunler")]
    public class Urun:EntityBase
    {
        [Required]
        public string Urun_Adi { get; set; }

        [Required]
        public int Miktar { get; set; }

        [Required]
        public int Fiyat { get; set; }

        public virtual Musteri Musteri { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
