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
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string OwnerId { get; set; } = ""; //same as SSN
		public int EmployeeID { get; set; } = 0;
		public int HomeId { get; set; } = 0;
		public string OwnerStartDate { get; set; } = "";
		public string OwnerEndDate { get; set; } = "";
		public float SalePrice { get; set; } = 0;
	}
}
