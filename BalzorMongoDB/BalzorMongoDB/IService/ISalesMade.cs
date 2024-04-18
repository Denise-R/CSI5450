using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ISalesMade
	{
		// updating or creating single entry
		void SaveOrUpdate(SalesMade salesMade);

		//getting one entry
		SalesMade GetSaleMade(string salesMadeID);

		//getting all entries
		List<SalesMade> GetSalesMade();

		//deleting an antry
		string Delete(string salesMadeID);
	}
}
