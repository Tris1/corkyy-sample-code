using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Context;
using ToDoListAPI.Entities;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoNotesController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ToDoNotesController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpPost]
		public async Task<IActionResult> CreateToDoNote([FromBody] ToDoDTO dto)
		{
			var toDoNote = new ToDoNoteEntity()
			{
				TodoText = dto.TodoText
			};
			await _context.ToDoNotes.AddAsync(toDoNote);
			await _context.SaveChangesAsync();

			return Ok("Product saved successfully");
		}

		[HttpGet]
		public async Task<ActionResult<List<ToDoNoteEntity>>> GetAllToDoNotes() 
		{
			var toDoNotes = await _context.ToDoNotes.OrderByDescending(todo => todo.Updated).ToListAsync();
			return Ok(toDoNotes);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<ToDoNoteEntity>> GetToDoById([FromRoute] long id) 
		{
			var toDoNote = await _context.ToDoNotes.FirstOrDefaultAsync(x => x.Id == id);

			if (toDoNote is null) 
			{
				return NotFound("ToDo Note Not Found");
			}

			return Ok(toDoNote);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateToDoNote([FromRoute] long id, [FromBody] ToDoDTO dto) 
		{
			var toDoNote = await _context.ToDoNotes.FirstOrDefaultAsync(x => x.Id == id);

			if (toDoNote is null)
			{
				return NotFound("ToDo Note Not Found");
			}

			toDoNote.TodoText = dto.TodoText;
			toDoNote.Updated = DateTime.Now;

			await _context.SaveChangesAsync();
			return Ok("ToDo Updated!");
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteToDo([FromRoute] long id) 
		{
			var toDoNote = await _context.ToDoNotes.FirstOrDefaultAsync(x => x.Id == id);

			if (toDoNote is null)
			{
				return NotFound("ToDo Note Not Found");
			}

			_context.ToDoNotes.Remove(toDoNote);
			await _context.SaveChangesAsync();

			return Ok("ToDo Deleted!");
		}
	}
}
