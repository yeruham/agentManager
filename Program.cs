using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Agent agent = new Agent("s", "aviva", "jerusalem", "Retired");
            //DALAgents agents = new DALAgents();
            //agents.addAgent(agent);
            //agents.GetAllAgents();
            //agents.DeleteAgent(3);
            //agents.updateLocation(1, "tel aviv");
            menuAgents menu = new menuAgents();
            menu.start();

        }
    }
}
