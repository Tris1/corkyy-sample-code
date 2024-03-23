using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Repos;

namespace ToDoListAPI.Services
{
	public class TodoNoteService : ITodoNoteService
	{
		private readonly ITodoNoteRepository _todoNoteRepository;

		public TodoNoteService(ITodoNoteRepository todoNoteRepository)
		{
			_todoNoteRepository = todoNoteRepository;
		}

		public async Task Add(TodoNoteModel todoNoteModel)
		{
			await _todoNoteRepository.Add(todoNoteModel);
		}

		public async Task<int> DeleteById(int id)
		{
			return await _todoNoteRepository.Delete(id);
		}

		public IEnumerable<TodoNoteModel>? GetAll()
		{
			var notes = _todoNoteRepository.GetAll()?.Result;

			if (notes is null || !notes.Any())
				return Enumerable.Empty<TodoNoteModel>();

			var todoNotes = notes.Select(note => new TodoNoteModel()
			{
				TodoText = note.TodoText,
				Created = note.Created,
				Updated = note.Updated,
				Id = (int)note.Id
			}).ToList();

			return todoNotes;
		}

		public TodoNoteModel? GetById(int id)
		{
			var note = _todoNoteRepository.GetById(id)?.Result;

			if (note is null)
				return null;

			return new TodoNoteModel()
			{
				TodoText = note.TodoText,
				Created = note.Created,
				Updated = note.Updated,
				Id = id
			};
		}

		public async Task<TodoNoteModel>? Update(int id, TodoNoteModel model)
		{
			var q = _todoNoteRepository.GetById(id)?.Result;
			if (q is null)
				return null;

			await _todoNoteRepository.Update(model, q);
			return model;
		}
	}
}
