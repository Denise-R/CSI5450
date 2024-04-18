using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class AppliancesService : IAppliances
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Appliances> _appliancesTable = null;
		public AppliancesService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_appliancesTable = _database.GetCollection<Appliances>("Appliances");
		}

		// creating function to delete one entry
		public string Delete(string appliancesID)
		{
			_appliancesTable.DeleteOne(x => x._id == appliancesID);
			return "Deleted";
		}

		// getting one entry
		public Appliances GetAppliance(string appliancesID)
		{
			return _appliancesTable.Find(x => x._id == appliancesID).FirstOrDefault();
		}

		//getting all entries
		public List<Appliances> GetAppliances()
		{
			return _appliancesTable.Find(FilterDefinition<Appliances>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(Appliances appliances)
		{
			var appliancesObj = _appliancesTable.Find(x => x._id == appliances._id).FirstOrDefault();
			if (appliancesObj == null)
			{
				_appliancesTable.InsertOne(appliances);
			}
			else
			{
				_appliancesTable.ReplaceOne(x => x._id == appliances._id, appliances);
			}
		}
	}
}
