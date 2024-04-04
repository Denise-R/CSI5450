using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class AppliancesOwnedService : IAppliancesOwned
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<AppliancesOwned> _appliancesOwnedTable = null;
		public AppliancesOwnedService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_appliancesOwnedTable = _database.GetCollection<AppliancesOwned>("AppliancesOwned");
		}
		public string Delete(string appliancesOwnedID)
		{
			_appliancesOwnedTable.DeleteOne(x => x._id == appliancesOwnedID);
			return "Deleted";
		}

		public AppliancesOwned GetApplianceOwned(string appliancesOwnedID)
		{
			return _appliancesOwnedTable.Find(x => x._id == appliancesOwnedID).FirstOrDefault();
		}

		public List<AppliancesOwned> GetAppliancesOwned()
		{
			return _appliancesOwnedTable.Find(FilterDefinition<AppliancesOwned>.Empty).ToList();
		}

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
