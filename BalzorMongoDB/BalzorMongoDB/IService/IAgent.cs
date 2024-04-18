using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAgent
	{
		// updating or creating single entry

		void SaveOrUpdate(Agent agent);

		//getting one entry
		Agent GetAgent(string agentID);

		//getting all entries
		List<Agent> GetAgents();

		//deleting an antry
		string Delete(string agentID);
	}
}
