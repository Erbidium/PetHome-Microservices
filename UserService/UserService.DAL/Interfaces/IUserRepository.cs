using UserService.DAL.Entities;

namespace UserService.DAL.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(long id);
    Task<List<User>> Get();
    Task Add(User user);
    void Update(User userToUpdate);
    void Delete(User user);
    Task<int> SaveChangesAsync();
}