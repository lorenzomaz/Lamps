using Classes;
using Lamps.Infrastructure;
using Lamps.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lamps.Services
{
    public class LampsService : ILampsService
    {
        private readonly LampsDbContext _dbContext;

        public LampsService(LampsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lamp> AddLamp(Lamp lamp)
        {
            await _dbContext.Lamps.AddAsync(lamp);
            await _dbContext.SaveChangesAsync();
            return lamp;
        }

        public async Task<Lamp[]> AddLamps(Lamp[] lamps)
        {
            await _dbContext.Lamps.AddRangeAsync(lamps);
            await _dbContext.SaveChangesAsync();
            return lamps;
        }

        public async Task<int> DeleteLamp(int id)
        {
            var lamp = await _dbContext.Lamps.FindAsync(id);

            if (lamp == null)
            {
                return 0;
            }

            _dbContext.Lamps.Remove(lamp!);
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> Delete(Lamp[] model)
        {
            //var lamp = await _dbContext.Lamps.FindAsync(model);
            var lampsDelete = await _dbContext.Lamps.Where(l => model.Select(m => m.Id).Contains(l.Id)).ToListAsync();
            _dbContext.Lamps.RemoveRange(lampsDelete);
            return await _dbContext.SaveChangesAsync();

        }



        public async Task<IEnumerable<Lamp>> GetLamp()
        {
            return await _dbContext.Lamps.ToListAsync();

        }

        public async Task<PagedResponse<Lamp>> GetAllLamps(string search, int index, int size, string sortBy, string sortDir)
        {
            Expression<Func<Lamp, bool>> predicate = l => true;

            if (!string.IsNullOrEmpty(search))
            {
                predicate = l => l.Name.Contains(search);
            }
            var query = _dbContext.Lamps.Filter(predicate);
            var count = await query.CountAsync();
            var lamps = await query
                .OrderBy(sortBy, sortDir)
                .Skip(index * size)
                .Take(size)
                .ToListAsync();

            return new() { Results = lamps, Total = count };
        }

        public async Task<int> UpdateLamp(Lamp lamp)
        {
            _dbContext.Entry(lamp).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }


    }
}