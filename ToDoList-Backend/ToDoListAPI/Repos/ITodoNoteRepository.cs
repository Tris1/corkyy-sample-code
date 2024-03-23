using ToDoListAPI.Entities;
using ToDoListAPI.Models;

namespace ToDoListAPI.Repos
{
	public interface ITodoNoteRepository
	{
		Task<IEnumerable<ToDoNoteEntity>>? GetAll();
		Task<ToDoNoteEntity>? GetById(int id);
		Task<int> Delete(int id);
		Task Update(TodoNoteModel todoNoteModel, ToDoNoteEntity toDoNoteEntity);
		Task Add(TodoNoteModel todoNoteModel);
	}
}
