using OnlineShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(int productId);
        Task AddProductAsync(ProductDTO productDto);
        Task UpdateProductAsync(ProductDTO productDto);
        Task DeleteProductAsync(int productId);
    }
}
