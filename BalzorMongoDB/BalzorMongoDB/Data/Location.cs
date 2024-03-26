using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Location
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int HomeID { get; set; } = 0;
		public string CityName { get; set; } = "";
		public string Street { get; set; } = "";
		public int ZipCode { get; set; } = 0;
		public int UnitNum { get; set; } = 0;
	}
}
