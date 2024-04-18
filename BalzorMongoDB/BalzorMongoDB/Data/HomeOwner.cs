using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for HomeOwner table 

namespace BalzorMongoDB.Data
{
	public class HomeOwner
	{
		// creating HomeOwner instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string SSN { get; set; } = "";
		public int homeID { get; set; } = 0;
		public string firstName { get; set; } = "";
		public string lastName { get; set; } = "";
		public int dependents { get; set; } = 0;
		public int income { get; set; } = 0;
		public int age { get; set; } = 0;
		public string profession { get; set; } = "";
		public bool isCurrentOwner { get; set; } = true;

		[BsonIgnore]
		public string cityName { get; set; } = "";
		[BsonIgnore]
		public string street { get; set; } = "";
		[BsonIgnore]
		public int zipCode { get; set; } = 0;
		[BsonIgnore]
		public int unitNum { get; set; } = 0;
	}
}
