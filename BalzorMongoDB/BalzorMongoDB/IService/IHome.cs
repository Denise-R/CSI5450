using BalzorMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.IService
{
	public interface IHome
	{
		void SaveOrUpdate(Home home);
		Home GetHome(string homeID);
		List<Home> GetHomes();
		string Delete(string homeID);
	}
}
