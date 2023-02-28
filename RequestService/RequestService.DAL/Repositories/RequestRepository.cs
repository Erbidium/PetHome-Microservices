using RequestService.DAL.Data;
using RequestService.DAL.Entities;
using RequestService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RequestService.DAL.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly DataContext _context;
        
        public RequestRepository(DataContext context)
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
    }
}
