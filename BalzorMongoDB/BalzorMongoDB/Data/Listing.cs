using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Listing
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string ownerID { get; set; } = ""; // same as SSN
		public int employeeID { get; set; } = 0;
		public int homeID { get; set; } = 0;
		public string availableStartDate { get; set; } = "";
		public string availableEndDate { get; set; } = "";
		public int listingPrice { get; set; } = 0;
		public bool isSold { get; set; } = true;
		public string soldTo { get; set; } = "";
	}
}
