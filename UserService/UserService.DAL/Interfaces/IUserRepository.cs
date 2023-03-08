using UserService.DAL.Entities;

namespace UserService.DAL.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(long id);
    Task<List<User>> Get();
    Task Add(User entity);
    void Update(User advertToUpdate);
    void Delete(User entity);
    Task<int> SaveChangesAsync();
}