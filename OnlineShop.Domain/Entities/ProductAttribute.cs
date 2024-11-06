﻿using System;
using System.Collections.Generic;

namespace OnlineShop.Domain.Entities
{
    public partial class ProductAttribute
    {
        public int ProductAttributeId { get; set; }
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public int AttributeValueId { get; set; }

        public virtual Attribute Attribute { get; set; } = null!;
        public virtual AttributeValue AttributeValue { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
