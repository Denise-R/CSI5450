using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class HomeOwnerService : IHomeOwner
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<HomeOwner> _homeOwnerTable = null;
		public HomeOwnerService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_homeOwnerTable = _database.GetCollection<HomeOwner>("HomeOwner");
		}
		public string Delete(string homeOwnerID)
		{
			_homeOwnerTable.DeleteOne(x => x.id == homeOwnerID);
			return "Deleted";
		}

		public HomeOwner GetHomeOwner(string homeOwnerID)
		{
			return _homeOwnerTable.Find(x => x.id == homeOwnerID).FirstOrDefault();
		}

		public List<HomeOwner> GetHomeOwners()
		{
			return _homeOwnerTable.Find(FilterDefinition<HomeOwner>.Empty).ToList();
		}

		public void SaveOrUpdate(HomeOwner homeOwner)
		{
			var homeOwnerObj = _homeOwnerTable.Find(x => x.id == homeOwner.id).FirstOrDefault();
			if (homeOwnerObj == null)
			{
				_homeOwnerTable.InsertOne(homeOwner);
			}
			else
			{
				_homeOwnerTable.ReplaceOne(x => x.id == homeOwner.id, homeOwner);
			}
		}
	}
}
