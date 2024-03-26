using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAppliances
	{
		void SaveOrUpdate(Appliances appliances);
		Appliances GetAppliance(string appliancesID);
		List<Appliances> GetAppliances();
		string Delete(string appliancesID);
	}
}
