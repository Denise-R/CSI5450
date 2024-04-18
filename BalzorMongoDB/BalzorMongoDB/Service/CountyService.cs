using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class CountyService : ICounty
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<County> _countyTable = null;
		public CountyService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_countyTable = _database.GetCollection<County>("County");
		}

		// creating function to delete one entry
		public string Delete(string countyID)
		{
			_countyTable.DeleteOne(x => x._id == countyID);
			return "Deleted";
		}

		// getting one entry 
		public County GetCounty(string countyID)
		{
			return _countyTable.Find(x => x._id == countyID).FirstOrDefault();
		}

		//getting all entries
		public List<County> GetCounties()
		{
			return _countyTable.Find(FilterDefinition<County>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(County county)
		{
			var countyObj = _countyTable.Find(x => x._id == county._id).FirstOrDefault();
			if (countyObj == null)
			{
				_countyTable.InsertOne(county);
			}
			else
			{
				_countyTable.ReplaceOne(x => x._id == county._id, county);
			}
		}
	}
}
