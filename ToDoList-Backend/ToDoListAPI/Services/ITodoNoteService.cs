using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
	public interface ITodoNoteService
	{
		IEnumerable<TodoNoteModel>? GetAll();
		TodoNoteModel? GetById(int id);
		Task<int> DeleteById(int id);
		Task<TodoNoteModel>? Update(int id, TodoNoteModel model);
		Task Add(TodoNoteModel todoNoteModel);
	}
}
