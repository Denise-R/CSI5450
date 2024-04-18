using BalzorMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.IService
{
	public interface IHome
	{
		// updating or creating single entry

		void SaveOrUpdate(Home home);

		//getting one entry
		Home GetHome(string homeID);

		//getting all entries
		List<Home> GetHomes();

		//deleting an antry
		string Delete(string homeID);
	}
}
