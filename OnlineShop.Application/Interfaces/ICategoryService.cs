using OnlineShop.Application.DTO;

namespace OnlineShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(CategoryDTO categoryDto);
        Task UpdateCategoryAsync(CategoryDTO categoryDto);
        Task DeleteCategoryAsync(int categoryId);
    }
}