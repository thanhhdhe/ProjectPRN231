using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }  // Rating from 1 to 5
        public string Comment { get; set; }

        // Relationships
        public Product Product { get; set; }
        public User User { get; set; }
    }

}
