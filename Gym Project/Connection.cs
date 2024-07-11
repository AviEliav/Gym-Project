using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Project
{
    public static class Connection
    {
        public static string ClientConnection = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Gym System", "Client Data");
        public static string CoachConnection =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Gym System", "Coach Data");
    }
}
