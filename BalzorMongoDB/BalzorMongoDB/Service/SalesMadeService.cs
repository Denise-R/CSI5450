﻿using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class SalesMadeService : ISalesMade
	{
		// creating connection to database
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<SalesMade> _salesMadeTable = null;
		public SalesMadeService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); 
			_salesMadeTable = _database.GetCollection<SalesMade>("SalesMade");
		}

		// creating function to delete one entry
		public string Delete(string salesMadeID)
		{
			_salesMadeTable.DeleteOne(x => x._id == salesMadeID);
			return "Deleted";
		}

		// getting one entry 
		public SalesMade GetSaleMade(string salesMadeID)
		{
			return _salesMadeTable.Find(x => x._id == salesMadeID).FirstOrDefault();
		}


		//getting all entries
		public List<SalesMade> GetSalesMade()
		{
			return _salesMadeTable.Find(FilterDefinition<SalesMade>.Empty).ToList();
		}

		// function to add or update an entry
		public void SaveOrUpdate(SalesMade salesMade)
		{
			var salesMadeObj = _salesMadeTable.Find(x => x._id == salesMade._id).FirstOrDefault();
			if (salesMadeObj == null)
			{
				_salesMadeTable.InsertOne(salesMade);
			}
			else
			{
				_salesMadeTable.ReplaceOne(x => x._id == salesMade._id, salesMade);
			}
		}
	}
}
