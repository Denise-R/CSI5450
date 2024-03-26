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
		public string id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string SSN { get; set; } = "";
		public int HomeID { get; set; } = 0;
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public int Dependents { get; set; } = 0;
		public int Income { get; set; } = 0;
		public int Age { get; set; } = 0;
		public string Proffession { get; set; } = "";
		public bool IsCurrentOwner { get; set; } = true;
	}
}
