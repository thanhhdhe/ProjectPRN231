using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributeValues = new HashSet<AttributeValue>();
            CategoryAttributes = new HashSet<CategoryAttribute>();
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int AttributeId { get; set; }
        public int AttributeGroupId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual AttributeGroup AttributeGroup { get; set; } = null!;
        public virtual ICollection<AttributeValue> AttributeValues { get; set; }
        public virtual ICollection<CategoryAttribute> CategoryAttributes { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
