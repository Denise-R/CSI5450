﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// creating class for Company table 

namespace BalzorMongoDB.Data
{
	public class Company
	{
		// creating Company instance

		[BsonRepresentation(BsonType.ObjectId)]
		public string _id { get; set; } = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
		public string companyName { get; set; } = "";
		public int officeID { get; set; } = 0;
		public string cityName { get; set; } = "";
	}
}
