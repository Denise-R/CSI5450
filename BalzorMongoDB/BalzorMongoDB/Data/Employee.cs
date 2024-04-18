using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for Employee table 

namespace BalzorMongoDB.Data
{
	public class Employee
	{
		// creating Employee instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int employeeID { get; set; } = 0;
		public string companyName { get; set; } = "";
		public int agentID { get; set; } = 0;
		public double commissionRate { get; set; } = 0;
	}
}
