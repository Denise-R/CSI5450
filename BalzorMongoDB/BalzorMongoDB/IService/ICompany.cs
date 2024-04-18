using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface ICompany
	{
		// updating or creating single entry

		void SaveOrUpdate(Company company);

		//getting one entry
		Company GetCompany(string companyID);

		//getting all entries
		List<Company> GetCompanies();

		//deleting an antry
		string Delete(string companyID);
	}
}
