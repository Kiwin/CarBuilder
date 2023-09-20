using CarBuilderWebAPI.Data;
using CarBuilderWebAPI.Interfaces;
using CarBuilderWebAPI.Models;

namespace CarBuilderWebAPI.Repository
{
	public class CarPartCategoryRepository : ICarPartCategoryRepository
	{

		private DataContext _context;

		public CarPartCategoryRepository(DataContext context)
		{
			_context = context;
		}

		public bool Exists(int id)
		{
			return _context.CarParts.Where(p => p.Id == id).Any();
		}

		public CarPartCategory? Get(int id)
		{
			return _context.CarPartCategories.Where(p => p.Id == id).FirstOrDefault();
		}

		public ICollection<CarPartCategory> GetAll()
		{
			return _context.CarPartCategories.OrderBy(p => p.Id).ToList();
		}

		public bool Update(CarPartCategory category)
		{
			_context.CarPartCategories.Update(category);
			return false;
		}

		public bool Add(CarPartCategory category)
		{
			_context.Add(category);
			return Save();
		}

		public bool Save()
		{
			return 0 < _context.SaveChanges();
		}

		public bool Delete(int id)
		{
			var category = Get(id);
			if (category == null) return false;
			_context.CarPartCategories.Remove(category);
			return Save();
		}

		public bool AddRange(ICollection<CarPartCategory> categories)
		{
			_context.CarPartCategories.AddRange(categories);
			return Save();
		}
	}
}
