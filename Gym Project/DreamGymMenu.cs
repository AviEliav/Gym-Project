using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Channels;
using System.Xml.Serialization;

namespace Gym_Project
{
    internal class DreamGymMenu
    {

        List<Client> clients = new List<Client>();
        List<Coach> coaches = new List<Coach>();

        string clientPath = Connection.ClientConnection;
        string coachPath = Connection.CoachConnection;

        public DreamGymMenu()
        {
            ClientList(clientPath);
            CoachList(coachPath);

            DisplayMenu();
        }


        public void DisplayMenu()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"

                           
             ░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗    ████████╗░█████╗░
             ░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║    ╚══██╔══╝██╔══██╗
             ░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║    ░░░██║░░░██║░░██║
             ░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║    ░░░██║░░░██║░░██║
             ░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║    ░░░██║░░░╚█████╔╝
             ░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝    ░░░╚═╝░░░░╚════╝░ ");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(@"


             ██████╗░██████╗░███████╗░█████╗░███╗░░░███╗    ░██████╗░██╗░░░██╗███╗░░░███╗
             ██╔══██╗██╔══██╗██╔════╝██╔══██╗████╗░████║    ██╔════╝░╚██╗░██╔╝████╗░████║
             ██║░░██║██████╔╝█████╗░░███████║██╔████╔██║    ██║░░██╗░░╚████╔╝░██╔████╔██║
             ██║░░██║██╔══██╗██╔══╝░░██╔══██║██║╚██╔╝██║    ██║░░╚██╗░░╚██╔╝░░██║╚██╔╝██║
             ██████╔╝██║░░██║███████╗██║░░██║██║░╚═╝░██║    ╚██████╔╝░░░██║░░░██║░╚═╝░██║
             ╚═════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚═╝░░░░░╚═╝    ░╚═════╝░░░░╚═╝░░░╚═╝░░░░░╚═╝");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();



                Console.WriteLine("\n Press 1 to enter client section\n Press 2 to enter coach section\n Press 3 to exit");
                int.TryParse(Console.ReadLine(), out int buttonNum);

                while (buttonNum != 1 && buttonNum != 2 && buttonNum !=3)
                {
                   
                    Console.WriteLine("\n Please try again,\n Press 1 to enter client section\n Press 2 to enter coach section\n Press 3 to exit");
                    int.TryParse(Console.ReadLine(), out buttonNum);
                }

                if (buttonNum == 1)
                {
                    Console.WriteLine("\n Press 1 to add client");
                    Console.WriteLine(" Press 2 to edit client");
                    Console.WriteLine(" Press 3 to delete client");
                    Console.WriteLine(" Press 4 to see clinet list");
                    Console.WriteLine(" Press 5 to return\n");
                    int.TryParse(Console.ReadLine(), out int choice);


                    while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5)
                    {
                        Console.WriteLine("Please try again, Choose from the follwing opetions above\n");
                        int.TryParse(Console.ReadLine(), out choice);
                    }

                    switch (choice)
                    {
                        case 1:
                            AddClientForm();
                            break;

                        case 2:
                            EditClientForm();
                            break;

                        case 3:
                            DeleteClient();
                            break;

                        case 4:
                            ClientList(clientPath);
                            PrintAllClient();
                            break;

                        case 5:
                            Thread.Sleep(500);
                            DisplayMenu();
                            break;
                    }
                }



                else if (buttonNum == 2)
                {
                    Console.WriteLine("\n Press 1 to add coach");
                    Console.WriteLine(" Press 2 to edit coach");
                    Console.WriteLine(" Press 3 to Delete coach");
                    Console.WriteLine(" Press 4 to see couch list");
                    Console.WriteLine(" Press 5 to return\n");
                    int.TryParse(Console.ReadLine(), out int choice);


                    while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5)
                    {
                        Console.WriteLine("Please try again, Choose from the follwing options above\n");
                        int.TryParse(Console.ReadLine(), out choice);
                    }

                    switch (choice)
                    {
                        case 1:
                            AddCoachForm();
                            break;

                        case 2:
                            EditCoachForm();
                            break;

                        case 3:
                            DeleteCoach();
                            break;

                        case 4:
                            CoachList(coachPath);
                            PrintAllCoach();
                            break;

                        case 5:
                            Thread.Sleep(500);
                            DisplayMenu();
                            break;
                    }
                }

                else 
                {
                    Environment.Exit(0);
                }
            
            
            
            }
        }




        #region Client Options
        public void AddClientForm()
        {
            Client c = new Client();

            Console.WriteLine("\nPlease enter ID number (9 digits)");
            c.Id = Console.ReadLine();

            Console.WriteLine("\nPlease enter First name");
            c.FirstName = Console.ReadLine();

            Console.WriteLine("\nPlease enter Last name");
            c.LastName = Console.ReadLine();

            Console.WriteLine("\nPlease enter Gender (F / M / O)");
            c.Gender = Console.ReadLine()[0];

            Console.WriteLine("\nPlease enter Date of birth (day/month/full year)");
            c.DOB = Console.ReadLine();

            Console.WriteLine("\nPlease enter Address");
            c.Address = Console.ReadLine();

            Console.WriteLine("\nPlease enter mobile Phone number");
            c.PhoneNumber = Console.ReadLine();

            Console.WriteLine("\nPlease enter Email address");
            c.Email = Console.ReadLine();

            Validation v = new Validation();
            Console.WriteLine("\nPlease enter Height (in Meters)");
            c.Height = v.ValidHeight(Console.ReadLine());


            Console.WriteLine("\nPlease enter Weight (in Kg)");
            c.Weight = v.ValidWeight(Console.ReadLine());


            Console.WriteLine("\nYour BMI is");
            Console.WriteLine(c.BmiCalaulation());

            c.IsActive = true;

            FileHandler.SaveClient(c);

            Console.WriteLine("\nAdded sucessfull");
        }


        public void EditClientForm()
        {

            Client editClient = FileHandler.LoadClinet();

            Console.WriteLine("\nChoose what would you like to edit\n");
            Console.WriteLine("Press 1 to edit First name\nPress 2 to edit Last name\nPress 3 to edit Gender\nPress 4 to edit Date of birth\nPress 5 to edit Address\nPress 6 to edit Phone number\nPress 7 to edit Email\nPress 8 to edit Height\nPress 9 to edit Weight\n");


            int.TryParse(Console.ReadLine(), out int choice);

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5 && choice != 6 && choice != 7 && choice != 8 && choice != 9)
            {
                Console.WriteLine("Please try again\n");
                int.TryParse(Console.ReadLine(), out choice);
            }


            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nPlease enter the new First name");
                    editClient.FirstName = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("\nPlease enter the new Last name");
                    editClient.LastName = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("\nPlease enter the new Gender");
                    editClient.Gender = Console.ReadLine()[0];
                    break;

                case 4:
                    Console.WriteLine("\nPlease enter the new Date of birth");
                    editClient.DOB = Console.ReadLine();
                    break;

                case 5:
                    Console.WriteLine("\nPlease enter the new Address");
                    editClient.Address = Console.ReadLine();
                    break;

                case 6:
                    Console.WriteLine("\nPlease enter the new Phone number");
                    editClient.PhoneNumber = Console.ReadLine();
                    break;

                case 7:
                    Console.WriteLine("\nPlease enter the new Email");
                    editClient.Email = Console.ReadLine();
                    break;

                case 8:
                    Console.WriteLine("\nplease enter the new Height");
                    editClient.Height = double.Parse(Console.ReadLine());
                    break;

                case 9:
                    Console.WriteLine("\nPlease enter the new Weight");
                    editClient.Weight = double.Parse(Console.ReadLine());
                    break;
            }

            FileHandler.SaveClient(editClient);
            Console.WriteLine("\nEdit sucessfully");
        }


        public void DeleteClient()
        {
            Client deleteClient = FileHandler.LoadClinet();
            Console.WriteLine("\nPress 1 if you sure you want to delete this client\nPress any key to return to home page\n");
            int.TryParse(Console.ReadLine(), out int delete);

            while (delete != 1)
            {
                DisplayMenu();
            }

            deleteClient.IsActive = false;
            FileHandler.SaveClient(deleteClient);
            Console.WriteLine("\nClient deleted sucessfully");
        }


        public void ClientList(string path)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        using (var reader = new StreamReader(file))
                        {
                            Client client = JsonSerializer.Deserialize<Client>(reader.ReadToEnd());
                            clients.Add(client);
                        }


                    }
                }
            }
            catch (Exception)
            {
                Directory.CreateDirectory(path);
            }

        }


        public void PrintAllClient()
        {
            foreach (var item in clients)
            {
                Console.WriteLine(item);
            }

        }
        #endregion



        



        #region Coach opations
        public void AddCoachForm()
        {
            Coach t = new Coach();

            Console.WriteLine("\nPlease enter ID number (9 digits)");
            t.Id = Console.ReadLine();

            Console.WriteLine("\nPlease enter First name");
            t.FirstName = Console.ReadLine();

            Console.WriteLine("\nPlease enter Last name");
            t.LastName = Console.ReadLine();

            Console.WriteLine("\nPlease enter Gender (F / M / O)");
            t.Gender = Console.ReadLine()[0];

            Console.WriteLine("\nPlease enter Date of birth (day/month/full year)");
            t.DOB = Console.ReadLine();

            Console.WriteLine("\nPlease enter Address");
            t.Address = Console.ReadLine();

            Console.WriteLine("\nPlease enter mobile Phone number");
            t.PhoneNumber = Console.ReadLine();

            Console.WriteLine("\nPlease enter Email address");
            t.Email = Console.ReadLine();

            Console.WriteLine("\nPlease enter Bank name");
            t.BankName = Console.ReadLine();

            Console.WriteLine("\nPlease enter Branch number");
            t.BankBranch = Console.ReadLine();

            Console.WriteLine("\nPlease enter Account number");
            t.AccountNumber = Console.ReadLine();

            Console.WriteLine("\nPlease enter Profession");
            t.Profession = Console.ReadLine();

            t.IsActive = true;

            FileHandler.SaveCoach(t);
            Console.WriteLine("\nAdded sucessfull");
        }


        public void EditCoachForm()
        {
            Coach editCoach = FileHandler.LoadCoach();

            Console.WriteLine("\nChoose what would you like to edit\n");
            Console.WriteLine("Press 1 to edit First name\nPress 2 to edit Last name\nPress 3 to edit Gender\nPress 4 to edit Date of birth\nPress 5 to edit Address\nPress 6 to edit Phone number\nPress 7 to edit Email\nPress 8 to edit Bank name\nPress 9 to edit Bank branch\nPress 10 to edit bank Account number\nPress 11 to edit Profession\n");


            int.TryParse(Console.ReadLine(), out int choice);

            while (choice != 1 && choice != 2 && choice != 3 && choice != 4 && choice != 5 && choice != 6 && choice != 7 && choice != 8 && choice != 9 && choice != 10 && choice != 11)
            {
                Console.WriteLine("Please try again, Choose from the follwing options above\n");
                int.TryParse(Console.ReadLine(), out choice);
            }


            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nPlease enter the new First name");
                    editCoach.FirstName = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("\nPlease enter the new Last name");
                    editCoach.LastName = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("\nPlease enter the new Gender");
                    editCoach.Gender = Console.ReadLine()[0];
                    break;

                case 4:
                    Console.WriteLine("\nPlease enter the new Date of birth");
                    editCoach.DOB = Console.ReadLine();
                    break;

                case 5:
                    Console.WriteLine("\nPlease enter the new Address");
                    editCoach.Address = Console.ReadLine();
                    break;

                case 6:
                    Console.WriteLine("\nPlease enter the new Phone number");
                    editCoach.PhoneNumber = Console.ReadLine();
                    break;

                case 7:
                    Console.WriteLine("\nPlease enter the new Email");
                    editCoach.Email = Console.ReadLine();
                    break;

                case 8:
                    Console.WriteLine("\nPlease enter the new Bank name");
                    editCoach.BankName = Console.ReadLine();
                    break;

                case 9:
                    Console.WriteLine("\nPlease enter the new Bank branch");
                    editCoach.BankBranch = Console.ReadLine();
                    break;

                case 10:
                    Console.WriteLine("\nPlease enter the new bank Account number");
                    editCoach.AccountNumber = Console.ReadLine();
                    break;

                case 11:
                    Console.WriteLine("\nPlease enter the new Profession");
                    editCoach.Profession = Console.ReadLine();
                    break;
            }

            FileHandler.SaveCoach(editCoach);
            Console.WriteLine("\nEdit sucessfully");

        }


        public void DeleteCoach()
        {
            Coach deleteCoach = FileHandler.LoadCoach();
            Console.WriteLine("\nPress 1 if you sure you want to delete this coach\nPress any key to return to home page\n");
            int.TryParse(Console.ReadLine(), out int delete);

            while (delete != 1)
            {
                DisplayMenu();
            }

            deleteCoach.IsActive = false;
            FileHandler.SaveCoach(deleteCoach);
            Console.WriteLine("Deleted sucessfully");
        }


        public void CoachList(string path)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        using (var reader = new StreamReader(file))
                        {
                            Coach coach = JsonSerializer.Deserialize<Coach>(reader.ReadToEnd());
                            coaches.Add(coach);
                        }
                    }
                }
            }

            catch(Exception)
            {
                Directory.CreateDirectory(path);
            }
        }


        public void PrintAllCoach()
        {
            foreach (var item in coaches)
            {
                Console.WriteLine(item);
            }

        }
        #endregion









    }
}
