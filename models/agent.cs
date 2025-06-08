using System;

public class Agent
{
    public int id { get; set; }

    public string codeName { get; set; }

    public string realName { get; set; }

    public string location { get; set; }

    public string status { get; set; }

    public int missionsCompleted { get; set; }

    public Agent(string codeName, string realName, string location, string status, int missionsCompleted = 0)
    {
        this.codeName = codeName;
        this.realName = realName;
        this.location = location;
        this.status = status;
        this.missionsCompleted = missionsCompleted;
    }


    public void printAgent()
    {
        Console.WriteLine($"id: {this.id}, code name: {this.codeName}, location: {this.location}, status: {this.status}, missionsCompleted: {this.missionsCompleted}.")
    }
}
