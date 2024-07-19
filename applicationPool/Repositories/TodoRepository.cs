using applicationPool.Data;
using applicationPool.Models;
using applicationPool.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TodoItem>> GetAllAsync()
    {
        return await _context.ToDoItems.ToListAsync();
    }

    public async Task<TodoItem> GetByIdAsync(int id)
    {
        return await _context.ToDoItems.FindAsync(id);
    }

    public async Task AddAsync(TodoItem item)
    {
        await _context.ToDoItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoItem item)
    {
        _context.ToDoItems.Update(item);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.ToDoItems.FindAsync(id);
        if (item != null)
        {
            _context.ToDoItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
