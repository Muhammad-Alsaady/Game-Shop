namespace Game_Shop.UI.Services.Repositroy
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<SelectListItem>> GetCategories();
        public Task<Category> GetCategoryById(int? id);

        public IEnumerable<Category> GetAllCategories();

        public Task CreateCategory(Category category);
    }
}
