using RequestService.DAL.Data;
using RequestService.DAL.Entities;
using RequestService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RequestService.DAL.Repositories
{
    public class RequestsRepository : IRequestsRepository
    {
        private readonly DataContext _context;

        private static List<Request> requests = new() //TEMP : HARDCODE
        {
            new() { Id = 1, UserId = "userID", AdvertId = 1, Status = Enums.RequestStatusEnum.applied },
            new() { Id = 2, UserId = "userID", AdvertId = 2, Status = Enums.RequestStatusEnum.applied },
            new() { Id = 3, UserId = "userID", AdvertId = 1, Status = Enums.RequestStatusEnum.applied },
            new() { Id = 4, UserId = "userID", AdvertId = 5, Status = Enums.RequestStatusEnum.applied },
            new() { Id = 5, UserId = "userID", AdvertId = 4, Status = Enums.RequestStatusEnum.applied },
            new() { Id = 6, UserId = "userID", AdvertId = 5, Status = Enums.RequestStatusEnum.applied },
        };

        public RequestsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Request>> GetAll() //TEMP: ASYNC FOR HARDCODE
        {
            return requests; //TEMP: HARDCODE
            //return _context.Requests.ToListAsync();
        }

        public async Task<Request?> GetById(int id) //TEMP: ASYNC FOR HARDCODE
        {
            return requests.Where(r => r.Id == id).FirstOrDefault(); //TEMP: HARDCODE
            //return _context.Requests.FindAsync(id).AsTask();
        }

        public async Task<List<Request>> GetByAdvertId(int advertId) //TEMP: ASYNC FOR HARDCODE
        {
            return requests.Where(r => r.AdvertId == advertId).ToList(); //TEMP: HARDCODE
            //return _context.Requests.Where(r => advertId == r.AdvertId).ToListAsync();
        }

        public async Task Add(Request requestToAdd) //TEMP: ASYNC FOR HARDCODE
        {
            requestToAdd.Id = requests.Count > 0 ? requests.MaxBy(r => r.Id).Id + 1 : 0; //TEMP: FOR HARDCODE
            requests.Add(requestToAdd);
            //await _context.Requests.AddAsync(requestToAdd);
        }
        
        public void Update(Request requestToUpdate)
        {
            requests.Where(r => r.Id == requestToUpdate.Id).ToList().ForEach(s => s.Status = requestToUpdate.Status); //TEMP: HARDCODE
            //_context.Set<Request>().Attach(requestToUpdate);
            //_context.Entry(requestToUpdate).State = EntityState.Modified;
        }

        public void Delete(Request requestToRemove)
        {
            requests.Remove(requestToRemove);
            //_context.Requests.Remove(requestToRemove);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
