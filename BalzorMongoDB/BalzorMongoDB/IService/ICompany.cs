using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ICompany
	{
		void SaveOrUpdate(Company company);
		Company GetCompany(string companyID);
		List<Company> GetCompanies();
		string Delete(string companyID);
	}
}
