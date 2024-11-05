using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;
using OnlineShop.Application.Skus.DTO;

namespace OnlineShop.Application.Products.DTO
{
    public class ProductDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductId { get; set; }
        [MaxLength(64)]
        public string ProductName { get; set; }
        [MaxLength(256)]
        public string ProductDesc { get; set; }
        public byte ProductStatus { get; set; } = 0;  // 0: out of stock, 1: in stock
        public string ProductAttrs { get; set; }  // JSON attributes
        public bool IsDeleted { get; set; } = false;
        public int Sort { get; set; } = 0;
        public ICollection<SkuDTO> Skus { get; set; }
    }
}
