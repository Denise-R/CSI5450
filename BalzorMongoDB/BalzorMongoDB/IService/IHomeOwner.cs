using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IHomeOwner
	{
		void SaveOrUpdate(HomeOwner homeOwner);
		HomeOwner GetHomeOwner(string homeOwnerID);
		List<HomeOwner> GetHomeOwners();
		string Delete(string homeOwnerID);
	}
}
