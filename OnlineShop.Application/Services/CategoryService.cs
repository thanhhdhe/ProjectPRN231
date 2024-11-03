using AutoMapper;
using OnlineShop.Application.DTO;
using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Entities;
using OnlineShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryDto.CategoryId);
            if (category == null) throw new Exception("Category not found");

            _mapper.Map(categoryDto, category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null) throw new Exception("Category not found");

            _categoryRepository.Remove(category);
            await _categoryRepository.SaveChangesAsync();
        }

        Task<IEnumerable<CategoryDTO>> ICategoryService.GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<CategoryDTO> ICategoryService.GetCategoryByIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

    }
}
