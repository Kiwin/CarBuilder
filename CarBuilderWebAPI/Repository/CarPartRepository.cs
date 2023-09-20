using CarBuilderWebAPI.Data;
using CarBuilderWebAPI.Interfaces;
using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Repository
{
	public class CarPartRepository : ICarPartRepository
	{
		private DataContext _context;

		public CarPartRepository(DataContext context)
		{
			_context = context;
		}

		public bool Exists(int id)
		{
			return _context.CarParts.Where(p => p.Id == id).Any();
		}

		public CarPart? Get(int id)
		{
			return _context.CarParts.Where(p => p.Id == id).FirstOrDefault();
		}

		public ICollection<CarPart> GetAll()
		{
			return _context.CarParts.OrderBy(p => p.Id).ToList();
		}

		public bool Update(CarPart carPart)
		{
			_context.CarParts.Update(carPart);
			return Save();
		}

		public bool Add(CarPart carPart)
		{
			_context.Add(carPart);
			return Save();
		}

		public bool Save()
		{
			return 0 < _context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var carPart = Get(id);
			if (carPart == null) return false;
			_context.CarParts.Remove(carPart);
			return Save();
		}

		public bool AddRange(ICollection<CarPart> carParts)
		{
			_context.CarParts.AddRange(carParts);
			return Save();
		}
	}
}
