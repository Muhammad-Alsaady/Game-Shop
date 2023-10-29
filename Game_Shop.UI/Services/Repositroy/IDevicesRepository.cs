namespace Game_Shop.UI.Services.Repositroy
{
    public interface IDevicesRepository
    {
        public Task<IEnumerable<SelectListItem>> GetDevices();
    }
}
