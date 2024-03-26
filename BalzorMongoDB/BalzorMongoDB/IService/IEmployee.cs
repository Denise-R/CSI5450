using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IEmployee
	{
		void SaveOrUpdate(Employee employee);
		Employee GetEmployee(string employeeID);
		List<Employee> GetEmployees();
		string Delete(string employeeID);
	}
}
