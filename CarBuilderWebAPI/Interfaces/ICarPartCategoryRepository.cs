using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Interfaces
{
	public interface ICarPartCategoryRepository : ICRUDRepository<CarPartCategory>
	{
		bool AddRange(ICollection<CarPartCategory> carParts);
	}
}
