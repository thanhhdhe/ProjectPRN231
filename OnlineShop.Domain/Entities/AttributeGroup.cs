using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class AttributeGroup
    {
        public AttributeGroup()
        {
            Attributes = new HashSet<Attribute>();
        }

        public int AttributeGroupId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Attribute> Attributes { get; set; }
    }
}
