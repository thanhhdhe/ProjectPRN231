using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.SkuImages.DTO
{
    public class SkuImageDTO
    {
        public int Id { get; set; }
        public int SkuId { get; set; }    
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
