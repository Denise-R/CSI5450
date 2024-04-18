using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IEmployee
	{
		// updating or creating single entry

		void SaveOrUpdate(Employee employee);

		//getting one entry
		Employee GetEmployee(string employeeID);

		//getting all entries
		List<Employee> GetEmployees();

		//deleting an antry
		string Delete(string employeeID);
	}
}
