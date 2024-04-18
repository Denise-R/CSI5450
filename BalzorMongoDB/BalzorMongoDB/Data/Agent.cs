using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for Agent table 

namespace BalzorMongoDB.Data
{
	public class Agent
	{
		// creating Agent instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public int agentID { get; set; } = 0;
		public string firstName { get; set; } = "";
		public string lastName { get; set; } = "";
	}
}
