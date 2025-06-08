using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

public class DALAgents
{
    private string connectionStr = "server=localhost;user=root;password=;database=eagleeyedb";
    string query;
    private MySqlConnection connaction;
    private MySqlCommand command;

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
        string codeName = agent.codeName;
        string realName = agent.realName;
        string location = agent.location;
        string status = agent.status;
        int missionsCompleted = agent.missionsCompleted;

        query = "INSERT INTO agents(codeName, realName, location, status, missionsCompleted)" +
            " VALUES(@codeName, @realName ,@location ,@status ,@missionsCompleted);";

        this.openConnection();

        try
        {
            command = new MySqlCommand(query, connaction);
            
            command.Parameters.AddWithValue("@codeName", codeName);
            command.Parameters.AddWithValue("@realName", realName);
            command.Parameters.AddWithValue("@location", location);
            command.Parameters.AddWithValue("@status", status);
            command.Parameters.AddWithValue("@missionsCompleted", missionsCompleted);
            
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: ", e.Message);
        }


        this.stopConnection();

    }

    public List<Agent> GetAllAgents()
    {
        List<Agent> agents = new List<Agent>();
        query = "SELECT * FROM agents";
        this.openConnection();

        try
        {
            command = new MySqlCommand(query, connaction);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                string codeName = reader.GetString("codeName");
                string realName = reader.GetString("realName");
                string location = reader.GetString("location");
                string status = reader.GetString("status");
                int missionsCompleted = reader.GetInt32("missionsCompleted");
                Agent agent = new Agent(codeName, realName, location, status, missionsCompleted);
                agent.printAgent();
                agents.Add(agent);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: ", e.Message);
        }
        finally
        {
            this.stopConnection();
        }
        
        return agents;
    }

    public void DeleteAgent(int agentId)
    {
        this.openConnection();
        query = "DELETE FROM agents WHERE id= @id";
        try
        {
            command = new MySqlCommand(query, connaction);

            command.Parameters.AddWithValue("@id", agentId);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: ", e.Message);
        }
        finally
        {
            this.stopConnection();
        }
    }

    public void updateLocation(int agentId, string newLocation)
    {
        this.openConnection();
        query = "UPDATE agents SET location = @location WHERE id = @id";
        try
        {
            command = new MySqlCommand(query, connaction);

            command.Parameters.AddWithValue("@location", newLocation);
            command.Parameters.AddWithValue("@id", agentId);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: ", e.Message);
        }
        finally
        {
            this.stopConnection();
        }
    }
}
