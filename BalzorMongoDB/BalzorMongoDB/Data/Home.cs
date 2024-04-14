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
		public string _id { get; set; } = 
			MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int homeID { get; set; } = 0;
		public int floorSpace { get; set; } = 0;
		public int floors { get; set; } = 0;
		public int bedRooms { get; set; } = 0;
		public double bathRooms { get; set; } = 0;
		public int landSize { get; set; } = 0;
		public int yearConstructed { get; set; } = 0;
		public string homeType { get; set; } = "";
		public string extraFeatures { get; set; } = "";
		public int unitNum { get; set; } = 0;
	}
}


