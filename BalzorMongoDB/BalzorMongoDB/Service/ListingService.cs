using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class ListingService : IListing
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Listing> _listingTable = null;
		public ListingService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_listingTable = _database.GetCollection<Listing>("Listing");
		}

		// creating function to delete one entry
		public string Delete(string listingID)
		{
			_listingTable.DeleteOne(x => x._id == listingID);
			return "Deleted";
		}

		// getting one entry 
		public Listing GetListing(string listingID)
		{
			return _listingTable.Find(x => x._id == listingID).FirstOrDefault();
		}

		//getting all entries
		public List<Listing> GetListings()
		{
			return _listingTable.Find(FilterDefinition<Listing>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(Listing listing)
		{
			var listingObj = _listingTable.Find(x => x._id == listing._id).FirstOrDefault();
			if (listingObj == null)
			{
				_listingTable.InsertOne(listing);
			}
			else
			{
				_listingTable.ReplaceOne(x => x._id == listing._id, listing);
			}
		}
	}
}
