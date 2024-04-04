using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class SalesMade
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string ownerID { get; set; } = ""; //same as SSN
		public int employeeID { get; set; } = 0;
		public int homeID { get; set; } = 0;
		public string ownerStartDate { get; set; } = "";
		public string ownerEndDate { get; set; } = "";
		public int salePrice { get; set; } = 0;
	}
}
