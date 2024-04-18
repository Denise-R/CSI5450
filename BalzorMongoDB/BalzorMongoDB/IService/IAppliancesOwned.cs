using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAppliancesOwned
	{
		// updating or creating single entry

		void SaveOrUpdate(AppliancesOwned appliancesOwned);

		//getting one entry
		AppliancesOwned GetApplianceOwned(string appliancesOwnedID);

		//getting all entries
		List<AppliancesOwned> GetAppliancesOwned();

		//deleting an antry
		string Delete(string appliancesOwnedID);
	}
}
