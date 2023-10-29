using Microsoft.AspNetCore.Mvc;

namespace Game_Shop.UI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(categoryRepository.GetAllCategories());
        }

        [HttpGet]
        public async Task<IActionResult> Detalis(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var category = await categoryRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if(ModelState.IsValid)
            {
                await categoryRepository.CreateCategory(model);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
