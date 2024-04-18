using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class CompanyService : ICompany
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Company> _companyTable = null;
		public CompanyService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_companyTable = _database.GetCollection<Company>("Company");
		}

		// creating function to delete one entry
		public string Delete(string companyID)
		{
			_companyTable.DeleteOne(x => x._id == companyID);
			return "Deleted";
		}

		// getting one entry
		public Company GetCompany(string companyID)
		{
			return _companyTable.Find(x => x._id == companyID).FirstOrDefault();
		}

		//getting all entries
		public List<Company> GetCompanies()
		{
			return _companyTable.Find(FilterDefinition<Company>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(Company company)
		{
			var companyObj = _companyTable.Find(x => x._id == company._id).FirstOrDefault();
			if (companyObj == null)
			{
				_companyTable.InsertOne(company);
			}
			else
			{
				_companyTable.ReplaceOne(x => x._id == company._id, company);
			}
		}
	}
}
