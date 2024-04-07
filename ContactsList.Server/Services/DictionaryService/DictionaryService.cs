using ContactsList.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsList.Server.Services.DictionaryService
{
    public class DictionaryService : IDictionaryService
    {
        private readonly ApplicationDbContext _context;
        public DictionaryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Subcategory>> GetSubcategories()
        {
            return await _context.Subcategories.ToListAsync();
        }

        public async Task<Subcategory> AddSubcategory(Subcategory subcategory)
        {
            if (await _context.Subcategories.FindAsync(subcategory.Id) != null)
                return null;
            _context.Subcategories.Add(new Subcategory
            {
                Id = 0,
                Name = subcategory.Name,
                CategoryId = subcategory.CategoryId,
            });
            await _context.SaveChangesAsync();

            return await _context.Subcategories.FirstOrDefaultAsync(sub => sub.Name == subcategory.Name);
        }
    }
}
