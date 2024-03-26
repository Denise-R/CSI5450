using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class Home
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int HomeID { get; set; } = 0;
		public int FloorSpace { get; set; } = 0;
		public int Floors { get; set; } = 0;
		public int Bedrooms { get; set; } = 0;
		public double Bathrooms { get; set; } = 0;
		public int LandSize { get; set; } = 0;
		public int YearConstructed { get; set; } = 0;
		public string HomeType { get; set; } = "";
		public string ExtraFeatures { get; set; } = "";
		public int UnitNum { get; set; } = 0;
	}
}
