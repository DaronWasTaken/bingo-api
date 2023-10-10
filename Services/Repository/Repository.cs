using bingo_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bingo_api.Services;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _entities; 
    private readonly BingoDevContext _context;

    public Repository(BingoDevContext context)
    {
        _context = context;
        _entities = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();
    public ValueTask<T?> GetByIdAsync(string id) => _entities.FindAsync(id);
    
    public async Task AddAsync(T entity)
    {
        _entities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
    
}