using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IListing
	{
		void SaveOrUpdate(Listing listing);
		Listing GetListing(string listingID);
		List<Listing> GetListings();
		string Delete(string listingID);
	}
}
