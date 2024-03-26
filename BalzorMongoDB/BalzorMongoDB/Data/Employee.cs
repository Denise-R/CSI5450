using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Employee
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int EmployeeId { get; set; } = 0;
		public string CompanyName { get; set; } = "";
		public int AgentID { get; set; } = 0;
		public double CommisionRate { get; set; } = 0;
	}
}
