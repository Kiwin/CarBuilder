using System.ComponentModel.DataAnnotations;

namespace CarBuilderWebAPI.Models
{
	public class CarPartCategory
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(255)]
		public string Name { get; set; }
	}
}