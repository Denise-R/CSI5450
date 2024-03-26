using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class ListingService : IListing
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Listing> _listingTable = null;
		public ListingService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_listingTable = _database.GetCollection<Listing>("Listing");
		}
		public string Delete(string listingID)
		{
			_listingTable.DeleteOne(x => x.id == listingID);
			return "Deleted";
		}

		public Listing GetListing(string listingID)
		{
			return _listingTable.Find(x => x.id == listingID).FirstOrDefault();
		}

		public List<Listing> GetListings()
		{
			return _listingTable.Find(FilterDefinition<Listing>.Empty).ToList();
		}

		public void SaveOrUpdate(Listing listing)
		{
			var listingObj = _listingTable.Find(x => x.id == listing.id).FirstOrDefault();
			if (listingObj == null)
			{
				_listingTable.InsertOne(listing);
			}
			else
			{
				_listingTable.ReplaceOne(x => x.id == listing.id, listing);
			}
		}
	}
}
