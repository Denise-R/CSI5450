using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for County table 

namespace BalzorMongoDB.Data
{
	public class County
	{
		// creating County instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string countyName { get; set; } = "";
		public string cityName { get; set; } = "";
		public int cityPop { get; set; } = 0;
	}
}
