using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Models;
using ToDoListAPI.Services;

namespace ToDoListAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ToDoNotesController : ControllerBase
	{
		private readonly ITodoNoteService _todoNoteService;

		public ToDoNotesController(ITodoNoteService todoNoteService)
		{
			_todoNoteService = todoNoteService;
		}

		[HttpPost]
		public async Task<IActionResult> CreateToDoNote([FromBody] TodoNoteModel tnm)
		{
			await _todoNoteService.Add(tnm);

			return Ok("Product saved successfully");
		}

		[HttpGet]
		public ActionResult<List<TodoNoteModel>> GetAllToDoNotes() 
		{
			var notes = _todoNoteService.GetAll();
			return Ok(notes);
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult<TodoNoteModel> GetToDoById([FromRoute] long id) 
		{
			var toDoNote = _todoNoteService.GetById((int)id);

			if (toDoNote is null) 
				return NotFound("ToDo Note Not Found");

			return Ok(toDoNote);
		}

		[HttpPut]
		[Route("{id}")]
		public async Task<IActionResult> UpdateToDoNote([FromRoute] long id, [FromBody] TodoNoteModel tnm) 
		{
			var result = await _todoNoteService.Update((int)id, tnm);

			if (result is null)
				return NotFound("Unable to update ToDo!");
			return Ok("ToDo Updated!");
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteToDo([FromRoute] long id) 
		{
			var toDoNote = await _todoNoteService.DeleteById((int)id);

			if (toDoNote == -1)
				return NotFound("ToDo Note Not Found");

			return Ok("ToDo Deleted!");
		}
	}
}
