﻿using AdvertService.DAL.Data;
using AdvertService.DAL.Entities;
using AdvertService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdvertService.DAL.Repositories
{
    public class AdvertsRepository : IAdvertsRepository
    {
        private readonly DataContext _context;
        public AdvertsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Advert entity)
        {
            await _context.Set<Advert>().AddAsync(entity);
        }

        public void Delete(Advert entity)
        {
            _context.Set<Advert>().Remove(entity);
        }

        public async Task<List<Advert>?> Get()
        {
            return await _context.Set<Advert>().ToListAsync();
        }

        public async Task<Advert?> GetById(int id)
        {
            Advert? advert = await _context.Set<Advert>().FirstOrDefaultAsync(el => el.Id == id);
            return advert;
        }

        public void Update(Advert advertToUpdate)
        {
            _context.Set<Advert>().Attach(advertToUpdate);
            _context.Entry(advertToUpdate).State = EntityState.Modified;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<Advert>> GetByOwnerId(string ownerId)
        {
            return _context.Set<Advert>().Where(advert => advert.ownerId == ownerId).ToListAsync();
        }
    }
}
