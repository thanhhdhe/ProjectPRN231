﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class AttributeValue
    {
        public AttributeValue()
        {
            ProductAttributes = new HashSet<ProductAttribute>();
        }

        public int AttributeValueId { get; set; }
        public int AttributeId { get; set; }
        public string Value { get; set; } = null!;

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
