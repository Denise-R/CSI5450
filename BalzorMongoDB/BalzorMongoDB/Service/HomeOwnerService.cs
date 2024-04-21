using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class HomeOwnerService : IHomeOwner
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<HomeOwner> _homeOwnerTable = null;
		public HomeOwnerService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_homeOwnerTable = _database.GetCollection<HomeOwner>("HomeOwner");
		}

		// creating function to delete one entry
		public string Delete(string homeOwnerID)
		{
			_homeOwnerTable.DeleteOne(x => x._id == homeOwnerID);
			return "Deleted";
		}

		// getting one entry 
		public HomeOwner GetHomeOwner(string homeOwnerID)
		{
			return _homeOwnerTable.Find(x => x._id == homeOwnerID).FirstOrDefault();
		}

		//getting all entries
		public List<HomeOwner> GetHomeOwners()
		{
			return _homeOwnerTable.Find(FilterDefinition<HomeOwner>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(HomeOwner homeOwner)
		{
			var homeOwnerObj = _homeOwnerTable.Find(x => x._id == homeOwner._id).FirstOrDefault();
			if (homeOwnerObj == null)
			{
				_homeOwnerTable.InsertOne(homeOwner);
			}
			else
			{
				_homeOwnerTable.ReplaceOne(x => x._id == homeOwner._id, homeOwner);
			}
		}


		public void UpdatePrevOwner(int homeIDVar)
		{
			var filter = Builders<HomeOwner>.Filter.And(
				Builders<HomeOwner>.Filter.Eq(x => x.homeID, homeIDVar),
				Builders<HomeOwner>.Filter.Eq(x => x.isCurrentOwner, true)
			);

			var update = Builders<HomeOwner>.Update.Set(x => x.isCurrentOwner, false);

			_homeOwnerTable.UpdateMany(filter, update);
		}

	}
}
