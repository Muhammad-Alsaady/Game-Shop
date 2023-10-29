using Microsoft.AspNetCore.Mvc;

namespace Game_Shop.UI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IGameRepository gameRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IDevicesRepository devicesRepository;

        public GamesController(ApplicationDbContext context, IGameRepository gameRepository,
            ICategoryRepository categoryRepository, IDevicesRepository devicesRepository)
        {
            this.context = context;
            this.gameRepository = gameRepository;
            this.categoryRepository = categoryRepository;
            this.devicesRepository = devicesRepository;
        }
       
        
        public IActionResult Index()
        {
            return View(gameRepository.GetGames());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return BadRequest();
            var game = gameRepository.GetGameById(id);
            if(game == null)
                return NotFound();
            return View(game);
        }
        

        [HttpGet]
        public async Task<IActionResult> CreateGame()
        {
            var model = new CreateGameViewModel
            {
                CategoryList = await categoryRepository.GetCategories(),
                DeviceList = await devicesRepository.GetDevices(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGame(CreateGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.CategoryList = await categoryRepository.GetCategories();
                model.DeviceList = await devicesRepository.GetDevices();
                return View(model);
            }
            await gameRepository.Create(model);
            return RedirectToAction(nameof(Index));    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGame(int? id)
        {
            if (id == null)
                return BadRequest();
            var gameToDelete = gameRepository.GetGameById(id);
            if(gameToDelete == null)
                return NotFound();
            var isDeleted = await gameRepository.DeleteGame(gameToDelete);

            return isDeleted? Ok(): BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();
            var gameToEdit = gameRepository.GetGameById(id);
            if (gameToEdit == null)
                return NotFound();

            var model = new EditGameViewModel
            {
                GameId = gameToEdit.GameId,
                Name = gameToEdit.Name,
                Description = gameToEdit.Description,
                CurrentCoverImage = gameToEdit.CoverImage,
                CategoryId = gameToEdit.CategoryId,
                CategoryList = await categoryRepository.GetCategories(),
                DeviceList = await devicesRepository.GetDevices(),
                SelectedDevices =  gameToEdit.GameDevices.Select(device =>(int) device.DeviceId).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, EditGameViewModel model)
        {
            if (id == null)
                return BadRequest();

            var gameToEdit = gameRepository.GetGameById(model.GameId);
            if (gameToEdit == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                await gameRepository.Update(model);
                return RedirectToAction(nameof(Index));   
            }
            return View(model);
        }

    }
}
