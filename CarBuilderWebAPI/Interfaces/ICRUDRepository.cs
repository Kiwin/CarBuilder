namespace CarBuilderWebAPI.Interfaces
{
	public interface ICRUDRepository<EntityType>
	{
		ICollection<EntityType> GetAll();
		EntityType? Get(int id);
		bool Add(EntityType obj);
		bool Update(EntityType obj);
		bool Delete(int id);
		bool Exists(int id);
		bool Save();
	}
}
