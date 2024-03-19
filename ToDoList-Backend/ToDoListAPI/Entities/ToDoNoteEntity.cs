using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Entities
{
	public class ToDoNoteEntity
	{
		[Key]
		public long Id { get; set; }
		public string TodoText { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime Updated { get; set; } = DateTime.Now;

	}
}
