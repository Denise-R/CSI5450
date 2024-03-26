using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Appliances
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int ModelNameNum { get; set; } = 0;
		public string Manufacturer { get; set; } = "";
		public string ApplianceName { get; set; } = "";
		public float AppliancePrice { get; set; } = 0;
		public int YearConstructed { get; set; } = 0;
	}
}
