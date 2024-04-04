using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BalzorMongoDB.Data
{
	public class HomeOwner
	{
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
	}
}
