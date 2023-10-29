using Game_Shop.Database.Models;
using Game_Shop.UI.Services.Repositroy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Game_Shop.UI.Services.Services
{
    public class GameService : IGameRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment env;
        private readonly string fullImagePath ;

        public GameService(ApplicationDbContext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
            fullImagePath = Path.Combine(env.WebRootPath, Settings.imagePath);
        }
        public async Task Create(CreateGameViewModel gameModel)
        {
            var imageName = await SaveImage(gameModel.CoverImage);

            var game = new Game
            {
                Name = gameModel.Name,
                CategoryId = gameModel.CategoryId,
                Description = gameModel.Description,
                CoverImage = imageName,
                GameDevices = gameModel.SelectedDevices.Select(d => new GameDevice { DeviceId = (byte)d}).ToList(),
            };
            await context.AddAsync(game);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteGame(Game gameModel)
        {
            var isDeleted = false;
            var gameToDelete = await context.Games.FindAsync(gameModel.GameId);
            if (gameToDelete == null)
                return isDeleted;

            context.Remove(gameToDelete);
            var effectedRows = await context.SaveChangesAsync();
            if(effectedRows == 1)
            {
                isDeleted = true;
                var coverToDelete = Path.Combine(fullImagePath, gameToDelete.CoverImage);
                File.Delete(coverToDelete);
            }
            return isDeleted;
        }

        public  Game? GetGameById(int? id)
        {
            if(id is not null)
            {
                return context.Games
                 .Include(g => g.Category)
                 .Include(g => g.GameDevices)
                 .ThenInclude(d => d.Device)
                 .AsNoTracking()
                 .SingleOrDefault(g => g.GameId == id);
                }
            return null;
        }

        public IEnumerable<Game> GetGames()
        {
           return  context.Games.Include(c => c.Category)
                .Include(d => d.GameDevices)
                .ThenInclude(d => d.Device)
                .OrderBy(g => g.Name)
                .AsNoTracking()
                .ToList();
        }

        public async Task<Game?> Update(EditGameViewModel gameModel)
        {
            var gameToEdit = await context.Games.Include(g => g.GameDevices)
                .SingleOrDefaultAsync(id => id.GameId == gameModel.GameId);

            if(gameToEdit == null)
            {
                return null;
            }

            var hasNewCover = gameModel.CoverImage is not null;
            var oldCover = gameToEdit.CoverImage;

            gameToEdit.Name = gameModel.Name;
            gameToEdit.Description = gameModel.Description;
            gameToEdit.CategoryId = gameModel.CategoryId;
            gameToEdit.GameDevices = gameModel.SelectedDevices.Select(d => new GameDevice { DeviceId = (byte)d }).ToList();
            if (hasNewCover)
            {
                gameToEdit.CoverImage = await SaveImage(gameModel.CoverImage!);
            }
            context.Games.Update(gameToEdit);
            var effectedRows = await context.SaveChangesAsync(); /// Number of rows Updated
            if(effectedRows == 1)
            {
                if (hasNewCover)
                {
                    var coverToDelete = Path.Combine(fullImagePath, oldCover);
                    File.Delete(coverToDelete);
                }
                return gameToEdit;
            }
            else
            {
                var coverToDelete = Path.Combine(fullImagePath, gameToEdit.CoverImage);
                File.Delete(coverToDelete);
                return null;
            }
        }

        private async Task<string> SaveImage(IFormFile cover)
        {
            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var imageURL = Path.Combine(fullImagePath, imageName);

            using var dataStream = File.Create(imageURL);
            await cover.CopyToAsync(dataStream);
            return imageName;
        }
    }
}
