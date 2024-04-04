using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class CountyService : ICounty
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<County> _countyTable = null;
		public CountyService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_countyTable = _database.GetCollection<County>("County");
		}
		public string Delete(string countyID)
		{
			_countyTable.DeleteOne(x => x._id == countyID);
			return "Deleted";
		}

		public County GetCounty(string countyID)
		{
			return _countyTable.Find(x => x._id == countyID).FirstOrDefault();
		}

		public List<County> GetCounties()
		{
			return _countyTable.Find(FilterDefinition<County>.Empty).ToList();
		}

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
