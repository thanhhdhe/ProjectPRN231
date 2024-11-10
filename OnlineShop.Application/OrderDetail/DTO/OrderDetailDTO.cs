﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.OrderDetail.DTO
{
    public class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public List<OrderItemDTO> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
