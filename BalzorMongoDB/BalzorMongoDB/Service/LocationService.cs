using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class LocationService : ILocation
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Location> _locationTable = null;
		public LocationService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_locationTable = _database.GetCollection<Location>("Location");
		}
		public string Delete(string locationID)
		{
			_locationTable.DeleteOne(x => x._id == locationID);
			return "Deleted";
		}

		public Location GetLocation(string locationID)
		{
			return _locationTable.Find(x => x._id == locationID).FirstOrDefault();
		}

		public List<Location> GetLocations()
		{
			return _locationTable.Find(FilterDefinition<Location>.Empty).ToList();
		}

		public void SaveOrUpdate(Location location)
		{
			var locationObj = _locationTable.Find(x => x._id == location._id).FirstOrDefault();
			if (locationObj == null)
			{
				_locationTable.InsertOne(location);
			}
			else
			{
				_locationTable.ReplaceOne(x => x._id == location._id, location);
			}
		}
	}
}
