using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ILocation
	{
		// updating or creating single entry
		void SaveOrUpdate(Location location);

		//getting one entry
		Location GetLocation(string locationID);

		//getting all entries
		List<Location> GetLocations();

		//deleting an antry
		string Delete(string locationID);
	}
}
