namespace ToDoListAPI.Models
{
	public class TodoNoteModel
	{
		public int Id { get; set; }
		public string TodoText { get; set; }
		public DateTime Created { get; set; }
		public DateTime Updated { get; set; }
	}
}
