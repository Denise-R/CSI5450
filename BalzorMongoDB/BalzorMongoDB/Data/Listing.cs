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
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string OwnerId { get; set; } = ""; // same as SSN
		public int EmployeeID { get; set; } = 0;
		public int HomeId { get; set; } = 0;
		public string AvalibleStartDate { get; set; } = "";
		public string AvalibleEndDate { get; set; } = "";
		public float ListingPrice { get; set; } = 0;
		public bool IsSold { get; set; } = true;
		public string SoldTo { get; set; } = "";
	}
}
