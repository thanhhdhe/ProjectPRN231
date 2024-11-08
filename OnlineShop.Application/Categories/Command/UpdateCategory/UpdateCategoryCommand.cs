using MediatR;
using OnlineShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }

}
