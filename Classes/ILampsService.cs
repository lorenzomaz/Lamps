
using Lamps.Infrastructure.Entities;

namespace Classes
{
    public interface ILampsService
    {
        // ELENCO
        Task<IEnumerable<Lamp>> GetLamp();
        Task<PagedResponse<Lamp>> GetAllLamps(string search, int index, int size, string sortBy, string sortDir);
        Task<Lamp> AddLamp(Lamp lamp);
        Task<Lamp[]> AddLamps(Lamp[] lamps);
        Task<int> UpdateLamp(Lamp lamp);
        Task<int> DeleteLamp(int id);
        Task<int> Delete(Lamp[] model);
    }
}
