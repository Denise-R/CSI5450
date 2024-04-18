using BalzorMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.IService
{
	public interface ICounty
	{
		// updating or creating single entry

		void SaveOrUpdate(County county);

		//getting one entry
		County GetCounty(string countyID);

		//getting all entries
		List<County> GetCounties();

		//deleting an antry
		string Delete(string countyID);
	}
}
