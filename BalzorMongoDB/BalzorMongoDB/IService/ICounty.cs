using BalzorMongoDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.IService
{
	public interface ICounty
	{
		void SaveOrUpdate(County county);
		County GetCounty(string countyID);
		List<County> GetCounties();
		string Delete(string countyID);
	}
}
