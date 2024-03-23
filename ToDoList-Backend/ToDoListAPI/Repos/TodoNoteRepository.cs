using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Context;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repos
{
	public class TodoNoteRepository : ITodoNoteRepository
	{
		public readonly ApplicationDbContext _context;

		public TodoNoteRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task Add(TodoNoteModel todoNoteModel)
		{
			var toDoNote = new ToDoNoteEntity()
			{
				TodoText = todoNoteModel.TodoText
			};

			_context.ToDoNotes.Add(toDoNote);
			await _context.SaveChangesAsync();
		}

		public async Task<int> Delete(int id)
		{
			var toDoNote = GetById(id)?.Result;

			if (toDoNote is null)
				return -1;

			_context.ToDoNotes.Remove(toDoNote);
			await _context.SaveChangesAsync();
			return 200;
		}

		public async Task<IEnumerable<ToDoNoteEntity>>? GetAll()
		{
			var toDoNotes = await _context.ToDoNotes.OrderByDescending(todo => todo.Updated).ToListAsync();

			if (toDoNotes is null)
				return Enumerable.Empty<ToDoNoteEntity>();

			return toDoNotes;
		}

		public async Task<ToDoNoteEntity>? GetById(int id)
		{
			var toDoNote = await _context.ToDoNotes.SingleOrDefaultAsync(x=> x.Id.Equals(id));

			return toDoNote;
		}

		public async Task Update(TodoNoteModel todoNoteModel, ToDoNoteEntity toDoNoteEntity)
		{
			toDoNoteEntity.TodoText = todoNoteModel.TodoText;
			toDoNoteEntity.Updated = DateTime.Now;

			await _context.SaveChangesAsync();
		}
	}
}
