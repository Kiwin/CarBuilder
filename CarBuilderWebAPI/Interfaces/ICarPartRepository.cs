using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Interfaces
{
	public interface ICarPartRepository : ICRUDRepository<CarPart>
	{
		bool AddRange(ICollection<CarPart> carParts);
	}
}
