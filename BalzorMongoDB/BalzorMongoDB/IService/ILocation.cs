using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ILocation
	{
		void SaveOrUpdate(Location location);
		Location GetLocation(string locationID);
		List<Location> GetLocations();
		string Delete(string locationID);
	}
}
