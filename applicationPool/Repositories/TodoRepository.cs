using System;
using applicationPool.Data;
using applicationPool.Models;
using applicationPool.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;

    public TodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TodoItem> GetAll()
    {
        return _context.TodoItems.ToList();
    }

    public TodoItem GetById(int id)
    {
        return _context.TodoItems.Find(id);
    }

    public void Add(TodoItem todoItem)
    {
        _context.TodoItems.Add(todoItem);
        _context.SaveChanges();
    }

    public void Update(TodoItem todoItem)
    {
        _context.TodoItems.Update(todoItem);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem != null)
        {
            _context.TodoItems.Remove(todoItem);
            _context.SaveChanges();
        }
    }
}
