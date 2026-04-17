using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetJwtPractice.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetJwtPractice.Repository
{
    public class CategoryRepository
    {
        private readonly ContentDBContext _dbo;

        public CategoryRepository(ContentDBContext dbContext)
        {
            _dbo = dbContext;
        }

        public async Task AddCategory(Category data)
        {
            _dbo.Categories.Add(data);
            await _dbo.SaveChangesAsync();
        }

        public async Task<bool> CategoryExistsByGUID(Guid GUID)
        {
            return await _dbo.Categories.Where(c => c.GUID == GUID).AnyAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbo.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryByGUID(Guid GUID)
        {
            return await _dbo.Categories.Where(c => c.GUID == GUID).FirstOrDefaultAsync();
        }

        public async Task<Category?> GetCategoryByCategoryName(string categoryName)
        {
            return await _dbo
                .Categories.Where(c => c.CategoryName == categoryName)
                .FirstOrDefaultAsync();
        }

        public async Task EditCategory(Category data)
        {
            _dbo.Categories.Update(data);
            await _dbo.SaveChangesAsync();
        }
    }
}
