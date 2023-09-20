using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Providers
{
	public class CarPartProvider
	{
		public readonly ICollection<CarPart> CarParts;
		public CarPartProvider(IEnumerable<CarPartCategory> carPartCategories)
		{
			CarParts = new List<CarPart>();

			int[] prices = { 1, 2, 3, 4, 5 };
			int[] weights = { 6, 4, 3, 2, 1 };
			int[] topspeeds = { 1, 2, 3, 5, 6 };
			int[] accelerations = { 1, 2, 3, 5, 4 };

			string[] partTiers = { "Budget", "Common", "Work", "Sport", "Formula" };

			foreach (var category in carPartCategories)
			{
				for (int j = 0; j < 5; j++)
				{
					CarParts.Add(new CarPart()
					{
						Id = j,
						Name = $"{partTiers[j]} {category.Name}",
						AccelerationModifier = accelerations[j],
						Price = prices[j],
						Weight = weights[j],
						TopSpeedModifier = topspeeds[j],
						Category = category
					});
				}
			}

		}
	}
}
