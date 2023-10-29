using Microsoft.EntityFrameworkCore;

namespace Game_Shop.UI.Services.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            return await context.Categories.Select(c => new SelectListItem
                { Value = c.Id.ToString(),
                Text = c.Name
                }).OrderBy(c => c.Text)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Category> GetCategoryById(int? id)
        {
            return id is null ? null : await context.Categories.FindAsync(id);
        }


        public IEnumerable<Category> GetAllCategories()
        {
            return  context.Categories.OrderBy(c => c.Name)
               .AsNoTracking()
               .ToList();
        }

        public async Task CreateCategory(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }


    }
}
