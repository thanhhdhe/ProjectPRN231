﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.PaymentService.DTO
{
    internal class PaymentUpdateDTO
    {
        public int OrderId { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
