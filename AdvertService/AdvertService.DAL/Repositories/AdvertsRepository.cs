using AdvertService.DAL.Data;
using AdvertService.DAL.Entities;
using AdvertService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvertService.DAL.Repositories
{
    public class AdvertsRepository : IAdvertsRepository
    {
        private readonly DataContext _context;

        private static List<Advert> adverts = new List<Advert>
        {
            new() {Id = 1, name = "name1", cost = 100, location = "location1", description = "description1", status = Enums.AdvertStatusEnum.search, startTime = DateTime.Now, endTime = DateTime.Now.AddDays(1),ownerId = "userID", performerId = "performerId" },
            new() {Id = 2, name = "name2", cost = 100, location = "location2", description = "description2", status = Enums.AdvertStatusEnum.search, startTime = DateTime.Now, endTime = DateTime.Now.AddDays(2),ownerId = "userID", performerId = "performerId" },
            new() {Id = 3, name = "name3", cost = 100, location = "location3", description = "description3", status = Enums.AdvertStatusEnum.search, startTime = DateTime.Now, endTime = DateTime.Now.AddDays(3),ownerId = "userID", performerId = "performerId" },
            new() {Id = 4, name = "name4", cost = 100, location = "location4", description = "description4", status = Enums.AdvertStatusEnum.search, startTime = DateTime.Now, endTime = DateTime.Now.AddDays(4),ownerId = "userID", performerId = "performerId" },
            new() {Id = 5, name = "name5", cost = 100, location = "location5", description = "description5", status = Enums.AdvertStatusEnum.search, startTime = DateTime.Now, endTime = DateTime.Now.AddDays(5),ownerId = "userID", performerId = "performerId" }

        };
        public AdvertsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Advert entity)
        {
            //await _context.Set<Advert>().AddAsync(entity);
            adverts.Add(entity);
        }

        public void Delete(Advert entity)
        {
             //_context.Set<Advert>().Remove(entity);
             adverts.Remove(entity);
        }

        public async Task<List<Advert>?> Get()
        {
            //return await _context.Set<Advert>().ToListAsync();
            return adverts;
        }

        public async Task<Advert?> GetById(int id)
        {
            //Advert? advert = await _context.Set<Advert>().FirstOrDefaultAsync(el => el.Id == id);
            //return advert;
            return adverts.Where(el => el.Id == id).FirstOrDefault();
        }

        public void Update(Advert advertToUpdate)
        {
            //_context.Set<Advert>().Attach(advertToUpdate);
            //_context.Entry(advertToUpdate).State = EntityState.Modified;
            int ind =  adverts.FindIndex(el => el.Id == advertToUpdate.Id);
            adverts[ind] = advertToUpdate;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
