using RequestService.DAL.Entities;

namespace RequestService.DAL.Interfaces
{
    public interface IRequestsRepository
    {
        Task<Request?> GetById(int id);
        Task<List<Request>> GetAll();
        Task<List<Request>> GetByAdvertId(int advertId);
        Task Add(Request requestToAdd);
        void Update(Request requestToUpdate);
        void Delete(Request requestToRemove);
        Task<int> SaveChangesAsync();
    }
}