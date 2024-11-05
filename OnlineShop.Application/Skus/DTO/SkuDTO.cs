using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Skus.DTO
{
    public class SkuDTO
    {
        public int Id { get; set; }
        public string SkuNo { get; set; } = string.Empty;
        public string SkuName { get; set; }
        public string SkuDescription { get; set; }

        public byte SkuType { get; set; }

        public byte Status { get; set; }

        public int Sort { get; set; } = 0;

        public int SkuStock { get; set; } = 0;

        [Column(TypeName = "decimal(8, 2)")]
        public decimal SkuPrice { get; set; }
    }
}
