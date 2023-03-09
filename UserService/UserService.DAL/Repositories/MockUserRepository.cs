using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.DAL.Repositories;

public class MockUserRepository : IUserRepository
{
    private static readonly List<User> Users = new()
    {
        new User {Id = 1, Name = "Петро", Location = "Київ", Email = "email1@email.com", Password = "hashedPassword1" },
        new User {Id = 2, Name = "Максим", Location = "Львів", Email = "email2@email.com", Password = "hashedPassword2" },
        new User {Id = 3, Name = "Данило", Location = "Полтава", Email = "email3@email.com", Password = "hashedPassword3" },
        new User {Id = 4, Name = "Богдан", Location = "Вінниця", Email = "email4@email.com", Password = "hashedPassword4" },
        new User {Id = 5, Name = "Віталій", Location = "Харків", Email = "email5@email.com", Password = "hashedPassword5" }

    };
    
    public async Task<User?> GetById(long id)
    {
        return Users.FirstOrDefault(user => user.Id == id);
    }

    public async Task<List<User>> Get()
    {
        return Users;
    }

    public async Task Add(User user)
    {
        user.Id = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1;
        Users.Add(user);
    }

    public void Update(User userToUpdate)
    {
        int userIndex =  Users.FindIndex(el => el.Id == userToUpdate.Id);
        Users[userIndex] = userToUpdate;
    }

    public void Delete(User user)
    {
        Users.Remove(user);
    }

    public async Task<int> SaveChangesAsync()
    {
        return 0;
    }
}