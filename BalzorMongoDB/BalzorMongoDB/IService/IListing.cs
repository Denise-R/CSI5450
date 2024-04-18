using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IListing
	{
		// updating or creating single entry
		void SaveOrUpdate(Listing listing);

		//getting one entry
		Listing GetListing(string listingID);

		//getting all entries
		List<Listing> GetListings();

		//deleting an antry
		string Delete(string listingID);
	}
}
