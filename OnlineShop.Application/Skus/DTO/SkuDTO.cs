using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Domain.Entities;
using OnlineShop.Application.SkuImages.DTO;
using OnlineShop.Application.Variants.DTO;

namespace OnlineShop.Application.Skus.DTO
{
    public class SkuDTO
    {
        public int SkuId { get; set; }
        public string SkuNo { get; set; } = null!;
        public string? SkuName { get; set; }
        public string? SkuDescription { get; set; }
        public byte? SkuType { get; set; }
        public byte? Status { get; set; }
        public int? Sort { get; set; }
        public int? SkuStock { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal? PromotionalPrice { get; set; }
        public ICollection<SkuImageDTO> Images { get; set; }
        public ICollection<VariantDTO> Variants { get; set; }
    }
}
