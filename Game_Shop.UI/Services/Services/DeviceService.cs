
namespace Game_Shop.UI.Services.Services
{
    public class DeviceService : IDevicesRepository
    {
        private readonly ApplicationDbContext context;

        public DeviceService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetDevices()
        {
            return await context.Devics.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).OrderBy(d => d.Text).AsNoTracking().ToListAsync();
        }
    }
}
