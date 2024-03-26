using BalzorMongoDB.Data;

namespace BalzorMongoDB.IService
{
	public interface IAgent
	{
		void SaveOrUpdate(Agent agent);
		Agent GetAgent(string agentID);
		List<Agent> GetAgents();
		string Delete(string agentID);
	}
}
