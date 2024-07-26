using applicationPool.Models;
using applicationPool.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

 [Route("api/[controller]")]
 [ApiController]
public class ToDoController : Controller
{
   
    private readonly ITodoRepository _todoRepository;

    public ToDoController(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _todoRepository.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _todoRepository.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TodoItem item)
    {
        if (item == null)
        {
            return BadRequest();
        }

        await _todoRepository.AddAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TodoItem item)
    {
        if (item == null || id != item.Id)
        {
            return BadRequest();
        }

        var existingItem = await _todoRepository.GetByIdAsync(id);
        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Title = item.Title;
        existingItem.IsCompleted = item.IsCompleted;

        await _todoRepository.UpdateAsync(existingItem);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingItem = await _todoRepository.GetByIdAsync(id);
        if (existingItem == null)
        {
            return NotFound();
        }

        await _todoRepository.DeleteAsync(id);
        return NoContent();
    }
}
