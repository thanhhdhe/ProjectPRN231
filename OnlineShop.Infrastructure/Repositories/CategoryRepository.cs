using OnlineShop.Domain.Entities;
using OnlineShop.Domain.Repositories;
using OnlineShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : ICategoryRepository
{
    private readonly OnlineShopDBContext _context;

    public CategoryRepository(OnlineShopDBContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _context.Categories.Where(c => c.IsDeleted != true).ToListAsync();
    }
}
