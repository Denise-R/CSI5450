using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class HomeService :IHome
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Home> _homeTable = null;
		public HomeService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_homeTable = _database.GetCollection<Home>("Home");
		}
		public string Delete(string homeID)
		{
			_homeTable.DeleteOne(x => x.id == homeID);
			return "Deleted";
		}

		public Home GetHome(string homeID)
		{
			return _homeTable.Find(x => x.id == homeID).FirstOrDefault();
		}

		public List<Home> GetHomes()
		{
			return _homeTable.Find(FilterDefinition<Home>.Empty).ToList();
		}

		public void SaveOrUpdate(Home home)
		{
			var homeObj = _homeTable.Find(x => x.id == home.id).FirstOrDefault();
			if (homeObj == null)
			{
				_homeTable.InsertOne(home);
			}
			else
			{
				_homeTable.ReplaceOne(x => x.id == home.id, home);
			}
		}
	}
	
}
