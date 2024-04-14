using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Filter1
	{
		[BsonIgnore]
		public int homeID { get; set; } = 0;
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

