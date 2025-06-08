using MySql.Data.MySqlClient;

public class DALAgents
{
    private string connectionStr = "server=localhost;user=root;password=;database=eagleeyedb";
    private MySqlConnection connaction;

    public DALAgents()
    {
        this.startConnection();
    }
    private void startConnection()
    {
        connaction = new MySqlConnection(connectionStr);
    }

    private void openConnection()
    {
        connaction.Open();
    }

    private void stopConnection()
    {
        connaction.Close();
    }


    public void addAgent(Agent agent)
    {
        int id = agent.id;
        string codeName = agent.codeName;
        string realName = agent.realName;
        string location = agent.location;
        string status = agent.status;
        int missionsCompleted = agent.missionsCompleted;
        
        string sqlCommand = $"INSERT INTO agents(id, codeName, realName, location, status, missionsCompleted)" +
            $" VALUSE({id},{codeName},{realName},{location},{status},{missionsCompleted})";


    }

}
