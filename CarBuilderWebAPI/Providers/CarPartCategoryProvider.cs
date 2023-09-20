using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Providers
{
	public class CarPartCategoryProvider
	{
		public readonly ICollection<CarPartCategory> CarPartCategories;
		public CarPartCategoryProvider()
		{
			CarPartCategories = new List<CarPartCategory>();
			string[] partCategories = { "Intake", "Exchaust", "Wheels", "Motor", "Brakes" };

			for (int i = 0; i < partCategories.Length; i++)
			{
				CarPartCategory carPartCategory = new CarPartCategory()
				{
					Id = i,
					Name = partCategories[i]
				};
				CarPartCategories.Add(carPartCategory);
			}
		}
	}
}
