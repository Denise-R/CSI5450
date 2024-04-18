using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class EmployeeService : IEmployee
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Employee> _employeeTable = null;
		public EmployeeService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_employeeTable = _database.GetCollection<Employee>("Employee");
		}

		// creating function to delete one entry
		public string Delete(string employeeID)
		{
			_employeeTable.DeleteOne(x => x._id == employeeID);
			return "Deleted";
		}

		// getting one entry 
		public Employee GetEmployee(string employeeID)
		{
			return _employeeTable.Find(x => x._id == employeeID).FirstOrDefault();
		}

		//getting all entries
		public List<Employee> GetEmployees()
		{
			return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(Employee employee)
		{
			var employeeObj = _employeeTable.Find(x => x._id == employee._id).FirstOrDefault();
			if (employeeObj == null)
			{
				_employeeTable.InsertOne(employee);
			}
			else
			{
				_employeeTable.ReplaceOne(x => x._id == employee._id, employee);
			}
		}
	}
}
