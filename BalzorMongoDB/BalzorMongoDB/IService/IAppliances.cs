using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAppliances
	{
		// updating or creating single entry

		void SaveOrUpdate(Appliances appliances);

		//getting one entry
		Appliances GetAppliance(string appliancesID);

		//getting all entries
		List<Appliances> GetAppliances();

		//deleting an antry
		string Delete(string appliancesID);
	}
}
