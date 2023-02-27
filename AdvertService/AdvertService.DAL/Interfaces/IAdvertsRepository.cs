using AdvertService.DAL.Entities;

namespace AdvertService.DAL.Interfaces
{
    public interface IAdvertsRepository
    {
        Task<Advert?> GetById(int id);
        Task<List<Advert>?> Get();
        Task Add(Advert entity);
        Task Update(Advert advertToUpdate);
        Task Delete(Advert entity);
        Task<int> SaveChangesAsync();
    }
}
