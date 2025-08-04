using System.ComponentModel.DataAnnotations;

public class AddTodoModel
{
	[Required]
	[StringLength(20)]
	public string priority { get; set; }

	[Required]
	[StringLength(500)]
	public string description { get; set; }

	[Required]
	[StringLength(20)]
	public string profile { get; set; }
}