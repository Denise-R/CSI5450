using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class LocationService : ILocation
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Location> _locationTable = null;
		public LocationService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_locationTable = _database.GetCollection<Location>("Location");
		}

		// creating function to delete one entry
		public string Delete(string locationID)
		{
			_locationTable.DeleteOne(x => x._id == locationID);
			return "Deleted";
		}

		// getting one entry 
		public Location GetLocation(string locationID)
		{
			return _locationTable.Find(x => x._id == locationID).FirstOrDefault();
		}

		//getting all entries
		public List<Location> GetLocations()
		{
			return _locationTable.Find(FilterDefinition<Location>.Empty).ToList();
		}

		// function to add or update an entry
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
