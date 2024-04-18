using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class AppliancesOwnedService : IAppliancesOwned
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<AppliancesOwned> _appliancesOwnedTable = null;
		public AppliancesOwnedService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate");
			_appliancesOwnedTable = _database.GetCollection<AppliancesOwned>("AppliancesOwned");
		}

		// creating function to delete one entry
		public string Delete(string appliancesOwnedID)
		{
			_appliancesOwnedTable.DeleteOne(x => x._id == appliancesOwnedID);
			return "Deleted";
		}

		// getting one entry
		public AppliancesOwned GetApplianceOwned(string appliancesOwnedID)
		{
			return _appliancesOwnedTable.Find(x => x._id == appliancesOwnedID).FirstOrDefault();
		}

		//getting all entries
		public List<AppliancesOwned> GetAppliancesOwned()
		{
			return _appliancesOwnedTable.Find(FilterDefinition<AppliancesOwned>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(AppliancesOwned appliancesOwned)
		{
			var appliancesOwnedObj = _appliancesOwnedTable.Find(x => x._id == appliancesOwned._id).FirstOrDefault();
			if (appliancesOwnedObj == null)
			{
				_appliancesOwnedTable.InsertOne(appliancesOwned);
			}
			else
			{
				_appliancesOwnedTable.ReplaceOne(x => x._id == appliancesOwned._id, appliancesOwned);
			}
		}
	}
}
