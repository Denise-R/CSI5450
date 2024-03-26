using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAppliancesOwned
	{
		void SaveOrUpdate(AppliancesOwned appliancesOwned);
		AppliancesOwned GetApplianceOwned(string appliancesOwnedID);
		List<AppliancesOwned> GetAppliancesOwned();
		string Delete(string appliancesOwnedID);
	}
}
