using System.IO;
using System.Text.Json;

namespace Gym_Project
{
    internal class FileHandler
    {

        public static void SaveClient(Client c)
        {
            string path= Path.Combine(Connection.ClientConnection,c.Id);
         
            Directory.CreateDirectory(path);

            string filePath = $"{c.Id}.json";

            string fullPath = Path.Combine(path, filePath);

            string stringedObject = JsonSerializer.Serialize(c);

            File.WriteAllText(fullPath, stringedObject);          
        }

        
        

        public static Client LoadClinet()
        {
            Console.WriteLine("\nPlease enter client ID");
            string num = Console.ReadLine();

            string path = Path.Combine(Connection.ClientConnection, num);

            string fliePath = $"{num}.json";

            string fullPath = Path.Combine(path, fliePath);

            while (!File.Exists(fullPath))
            {
                Console.WriteLine("\nInvalid ID Please try again");
                num = Console.ReadLine();

                path = Path.Combine(Connection.ClientConnection, num);

                fliePath = $"{num}.json";

                fullPath = Path.Combine(path, fliePath);
            }

            string stringedObject = File.ReadAllText(fullPath);

            Client editClient = JsonSerializer.Deserialize<Client>(stringedObject);

            return editClient;
        }






        public static void SaveCoach(Coach t)
        {
            string path = Path.Combine(Connection.CoachConnection, t.Id);

            Directory.CreateDirectory(path);

            string filePath = $"{t.Id}.json";

            string fullPath = Path.Combine(path, filePath);

            string stringedObject = JsonSerializer.Serialize(t);

            File.WriteAllText(fullPath, stringedObject);

        }


        public static Coach LoadCoach()
        {

            Console.WriteLine("\nPlease enter coach ID");
            string num = Console.ReadLine();

            string path = Path.Combine(Connection.CoachConnection, num);

            string fliePath = $"{num}.json";

            string fullPath = Path.Combine(path, fliePath);

            while (!File.Exists(fullPath))
            {
                Console.WriteLine("\nInvalid ID Please try again");
                num = Console.ReadLine();

                path = Path.Combine(Connection.CoachConnection, num);

                fliePath = $"{num}.json";

                fullPath = Path.Combine(path, fliePath);
            }

            string stringedObject = File.ReadAllText(fullPath);

            Coach editCoach = JsonSerializer.Deserialize<Coach>(stringedObject);

            return editCoach;






        }
    }
}
