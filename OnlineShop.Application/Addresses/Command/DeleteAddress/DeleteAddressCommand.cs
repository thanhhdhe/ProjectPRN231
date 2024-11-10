﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Addresses.Command.DeleteAddress
{
    public class DeleteAddressCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
