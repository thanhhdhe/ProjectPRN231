using MediatR;

namespace OnlineShop.Application.Products.Command.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public string Name { get; set; }  // Changed to match Product model
        public string Brand { get; set; } // Changed to match Product model
        public string ModelNumber { get; set; } // Changed to match Product model
        public string Description { get; set; } // Changed to match Product model
        public string Specifications { get; set; } // Changed to match Product model
        public string Warranty { get; set; } // Changed to match Product model
        public string CoverImage { get; set; } // Changed to match Product model
        public int CategoryId { get; set; } // Changed to match Product model
        public bool IsDeleted { get; set; } = false; // Default value
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current time
        public DateTime UpdatedAt { get; set; } = DateTime.Now; // Default to current time
    }
}
