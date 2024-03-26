using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class County
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string CountyName { get; set; } = "";
		public string CityName { get; set; } = "";
		public int CityPop { get; set; } = 0;
	}
}
