using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ISalesMade
	{
		void SaveOrUpdate(SalesMade salesMade);
		SalesMade GetSaleMade(string salesMadeID);
		List<SalesMade> GetSalesMade();
		string Delete(string salesMadeID);
	}
}
