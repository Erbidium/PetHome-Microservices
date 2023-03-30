using Microsoft.EntityFrameworkCore;
using UserService.DAL.Context;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<User?> GetById(Guid id)
    {
        return await _context.Set<User>().FirstOrDefaultAsync(el => el.Id == id);
    }

    public async Task<List<User>> Get()
    {
        return await _context.Set<User>().ToListAsync();
    }

    public async Task Add(User user)
    {
        await _context.Set<User>().AddAsync(user);
    }

    public void Update(User userToUpdate)
    {
        _context.Set<User>().Attach(userToUpdate);
        _context.Entry(userToUpdate).State = EntityState.Modified;
    }

    public void Delete(User user)
    {
        _context.Set<User>().Remove(user);
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}