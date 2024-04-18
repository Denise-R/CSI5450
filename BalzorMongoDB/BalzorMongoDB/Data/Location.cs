using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for Location table 

namespace BalzorMongoDB.Data
{
	public class Location
	{
		// creating Location instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int homeID { get; set; } = 0;
		public string cityName { get; set; } = "";
		public string street { get; set; } = "";
		public int zipCode { get; set; } = 0;
		public int unitNum { get; set; } = 0;
	}
}
