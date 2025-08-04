using System.ComponentModel.DataAnnotations;

namespace DecisionsTodoWebAPI.Models
{
	public class Tododata
	{
		[Key]
		public Guid Id { get; set; }
		public required string priority { get; set; }
		public required string description { get; set; }
		public required string profile { get; set; }
	}
}
