using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IHomeOwner
	{
		// updating or creating single entry

		void SaveOrUpdate(HomeOwner homeOwner);

		//getting one entry
		HomeOwner GetHomeOwner(string homeOwnerID);

		//getting all entries
		List<HomeOwner> GetHomeOwners();

		//deleting an antry
		string Delete(string homeOwnerID);
	}
}
