using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class NewsGroup
    {
        public NewsGroup()
        {
            News = new HashSet<News>();
        }

        public int NewsgroupId { get; set; }
        public string? NewsgroupName { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
