using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class HomeService :IHome
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Home> _homeTable = null;
		public HomeService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate");
			_homeTable = _database.GetCollection<Home>("Home");
		}

		// creating function to delete one entry
		public string Delete(string homeID)
		{_homeTable.DeleteOne(x => x._id == homeID);
			return "Deleted";}

		// getting one entry 
		public Home GetHome(string homeID)
		{return _homeTable.Find(x => x._id == homeID).FirstOrDefault();}

		//getting all entries
		public List<Home> GetHomes()
		{return _homeTable.Find(FilterDefinition<Home>.Empty).ToList();}

		// function to add or update an entry
		public void SaveOrUpdate(Home home)
		{var homeObj = _homeTable.Find(x => x._id == home._id).FirstOrDefault();
			if (homeObj == null)
			{_homeTable.InsertOne(home);}
			else{_homeTable.ReplaceOne(x => x._id == home._id, home);}
		}
	}	
}
