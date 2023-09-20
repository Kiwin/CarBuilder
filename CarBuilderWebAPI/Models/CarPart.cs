using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarBuilderWebAPI.Models
{
	public class CarPart
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(255)]
		public string Name { get; set; }
		[Required]
		[NotNull]
		public CarPartCategory Category { get; set; }
		[Required]
		public int Price { get; set; }
		[Required]
		public int Weight { get; set; }
		[Required]
		public int AccelerationModifier { get; set; }
		[Required]
		public int TopSpeedModifier { get; set; }
	}
}
