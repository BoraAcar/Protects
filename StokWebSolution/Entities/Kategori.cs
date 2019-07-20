using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Table("Kategoriler")]
    public class Kategori:EntityBase
    {
        [Required]
        public string Baslik { get; set; }

        public virtual List<Urun> Urunler { get; set; }
    }
}
