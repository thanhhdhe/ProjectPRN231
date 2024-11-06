using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class News
    {
        public int NewsId { get; set; }
        public int? NewsgroupId { get; set; }
        public string? Image { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Status { get; set; }

        public virtual staff? CreatedByNavigation { get; set; }
        public virtual NewsGroup? Newsgroup { get; set; }
    }
}
