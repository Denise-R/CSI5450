using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class EmployeeService : IEmployee
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Employee> _employeeTable = null;
		public EmployeeService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_employeeTable = _database.GetCollection<Employee>("Employee");
		}
		public string Delete(string employeeID)
		{
			_employeeTable.DeleteOne(x => x.id == employeeID);
			return "Deleted";
		}

		public Employee GetEmployee(string employeeID)
		{
			return _employeeTable.Find(x => x.id == employeeID).FirstOrDefault();
		}

		public List<Employee> GetEmployees()
		{
			return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList();
		}

		public void SaveOrUpdate(Employee employee)
		{
			var employeeObj = _employeeTable.Find(x => x.id == employee.id).FirstOrDefault();
			if (employeeObj == null)
			{
				_employeeTable.InsertOne(employee);
			}
			else
			{
				_employeeTable.ReplaceOne(x => x.id == employee.id, employee);
			}
		}
	}
}
