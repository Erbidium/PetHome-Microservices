using RequestService.DAL.Data;
using RequestService.DAL.Entities;
using RequestService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RequestService.DAL.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        private readonly DataContext _context;
        
        public RequestsRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<Request>> GetAll()
        {
            return _context.Requests.ToListAsync();
        }

        public Task<Request?> GetById(int id)
        {
            return _context.Requests.FindAsync(id).AsTask();
        }

        public Task<List<Request>> GetByAdvertId(int advertId)
        {
            return _context.Requests.Where(r => advertId == r.AdvertId).ToListAsync();
        }

        public async Task Add(Request requestToAdd)
        {
            await _context.Requests.AddAsync(requestToAdd);
        }
        
        public void Update(Request requestToUpdate)
        {
            _context.Set<Request>().Attach(requestToUpdate);
            _context.Entry(requestToUpdate).State = EntityState.Modified;
        }

        public void Delete(Request requestToRemove)
        {
            _context.Requests.Remove(requestToRemove);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
