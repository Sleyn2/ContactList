using ContactsList.Server.Model;

namespace ContactsList.Server.Services.DictionaryService
{
    public interface IDictionaryService
    {
        Task<List<Category>> GetCategories();
        Task<List<Subcategory>> GetSubcategories();
        Task<Subcategory> AddSubcategory(Subcategory subcategory);
    }
}
