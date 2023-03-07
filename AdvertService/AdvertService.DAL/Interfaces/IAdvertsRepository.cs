using AdvertService.DAL.Entities;

namespace AdvertService.DAL.Interfaces
{
    public interface IAdvertsRepository
    {
        Task<Advert?> GetById(int id);
        Task<List<Advert>?> Get();
        Task Add(Advert entity);
        void Update(Advert advertToUpdate);
        void Delete(Advert entity);
        Task<int> SaveChangesAsync();
    }
}
