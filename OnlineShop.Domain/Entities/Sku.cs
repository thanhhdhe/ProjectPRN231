using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Sku
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(32)]
        public string SkuNo { get; set; } = string.Empty;

        [MaxLength(50)]
        public string SkuName { get; set; }

        [MaxLength(256)]
        public string SkuDescription { get; set; }

        public byte SkuType { get; set; }

        public byte Status { get; set; }

        public int Sort { get; set; } = 0;

        public int SkuStock { get; set; } = 0;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal SkuPrice { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; } = DateTime.Now;

        // Foreign key to Product
        public long ProductId { get; set; }

        // Navigation property to Product
        public Product Product { get; set; }
    }
}
