using BalzorMongoDB.Data;
using BalzorMongoDB.Service;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class AppliancesOwned
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int modelNameNum { get; set; } = 0;
		public string manufacturer { get; set; } = "";
		public string applianceName { get; set; } = "";
		public int homeID { get; set; } = 0;
		public int quantity { get; set; } = 0;
		public int retailPrice { get; set; } = 0;
	}
}


