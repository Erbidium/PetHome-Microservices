using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.DAL.Repositories;

public class MockUserRepository : IUserRepository
{
    private List<User> _users = new()
    {
        new User {Id = 1, Name = "name1", Location = "location1", Email = "email1@email.com", Password = "hashedPassword1" },
        new User {Id = 2, Name = "name2", Location = "location2", Email = "email2@email.com", Password = "hashedPassword2" },
        new User {Id = 3, Name = "name3", Location = "location3", Email = "email3@email.com", Password = "hashedPassword3" },
        new User {Id = 4, Name = "name4", Location = "location4", Email = "email4@email.com", Password = "hashedPassword4" },
        new User {Id = 5, Name = "name5", Location = "location5", Email = "email5@email.com", Password = "hashedPassword5" }

    };
    
    public async Task<User?> GetById(long id)
    {
        return _users.FirstOrDefault(user => user.Id == id);
    }

    public async Task<List<User>> Get()
    {
        return _users;
    }

    public async Task Add(User user)
    {
        _users.Add(user);
    }

    public void Update(User userToUpdate)
    {
        throw new NotImplementedException();
    }

    public void Delete(User user)
    {
        _users.Remove(user);
    }

    public async Task<int> SaveChangesAsync()
    {
        return 0;
    }
}