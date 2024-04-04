using BalzorMongoDB.Data;
using BalzorMongoDB.IService;
using MongoDB.Driver;

namespace BalzorMongoDB.Service
{
	public class AgentService : IAgent
	{
		private MongoClient _mongoClient = null;
		private IMongoDatabase _database = null;
		private IMongoCollection<Agent> _agentTable = null;
		public AgentService()
		{
			_mongoClient = new MongoClient("mongodb://127.0.0.1:27017/");
			_database = _mongoClient.GetDatabase("RealEstate"); // fix me
			_agentTable = _database.GetCollection<Agent>("Agent"); // name of table "Agent"
		}
		public string Delete(string agentID)
		{
			_agentTable.DeleteOne(x => x._id == agentID);
			return "Deleted";
		}

		public Agent GetAgent(string agentID)
		{
			return _agentTable.Find(x => x._id == agentID).FirstOrDefault();
		}

		public List<Agent> GetAgents()
		{
			return _agentTable.Find(FilterDefinition<Agent>.Empty).ToList();
		}

		public void SaveOrUpdate(Agent agent)
		{
			var agentObj = _agentTable.Find(x => x._id == agent._id).FirstOrDefault();
			if (agentObj == null)
			{
				_agentTable.InsertOne(agent);
			}
			else
			{
				_agentTable.ReplaceOne(x => x._id == agent._id, agent);
			}
		}
	}

}
