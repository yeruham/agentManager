using System;

public class menuAgents
{
    private DALAgents dalAgents;

    public menuAgents()
    {
        dalAgents = new DALAgents();
    }

    public void start()
    {
        string choice = "";
        do
        {
            Console.WriteLine("To add new agent press 1.\n" +
                "For show existing agents press 2.\n" +
                "To delete an agent press 3.\n" +
                "To updata location of agent press 4" +
                "To exit press 5");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Agent agent = this.creatAgent();
                    dalAgents.addAgent(agent);
                    break;
                
                case "2":
                    dalAgents.GetAllAgents();
                    break;
                
                case "3":
                    Console.WriteLine("enter num id of agent");
                    int agentId = Convert.ToInt32(Console.ReadLine());
                    dalAgents.DeleteAgent(agentId);
                    break;
                
                case "4":
                    Console.WriteLine("enter num id of agent");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter new location");
                    string newLocation = Console.ReadLine();
                    dalAgents.updateLocation(id, newLocation);
                    break;
            }


        } while (choice != "5");
    }

    public Agent creatAgent()
    {
        Console.WriteLine("Insert codeName, realName, location, status, with commas!!");
        string[] paramters = Console.ReadLine().Split(',');
        
        string codeName = paramters[0];
        string realName = paramters[1];
        string location = paramters[2];
        string status = paramters[3];
        
        Agent agent = new Agent(codeName, realName, location, status);
        return agent;
    }
} 
