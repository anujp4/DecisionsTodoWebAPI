namespace DecisionsTodoWebAPI.Models
{
	public class AddTodoModel
	{
		public required string priority { get; set; }
		public required string description { get; set; }
		public required string profile { get; set; }
	}
}
