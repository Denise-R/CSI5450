using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class AppliancesService : IAppliances
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Appliances> _appliancesTable = null;
		public AppliancesService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_appliancesTable = _database.GetCollection<Appliances>("Appliances");
		}
		public string Delete(string appliancesID)
		{
			_appliancesTable.DeleteOne(x => x.id == appliancesID);
			return "Deleted";
		}

		public Appliances GetAppliance(string appliancesID)
		{
			return _appliancesTable.Find(x => x.id == appliancesID).FirstOrDefault();
		}

		public List<Appliances> GetAppliances()
		{
			return _appliancesTable.Find(FilterDefinition<Appliances>.Empty).ToList();
		}

		public void SaveOrUpdate(Appliances appliances)
		{
			var appliancesObj = _appliancesTable.Find(x => x.id == appliances.id).FirstOrDefault();
			if (appliancesObj == null)
			{
				_appliancesTable.InsertOne(appliances);
			}
			else
			{
				_appliancesTable.ReplaceOne(x => x.id == appliances.id, appliances);
			}
		}
	}
}
