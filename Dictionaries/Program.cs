using System;
using System.IO;
using System.Threading;

namespace Dictionaries
{
    public class Program
    {
        public static void Register()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tRegister:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter Words type(Engilish-Turkish): ");
            string wordsType = Console.ReadLine();
            Console.Clear();

            Boolean temp = false;
            string[] fileOutput = new[] { "false" };
            try
            {
                fileOutput = File.ReadAllLines(@"BasicFile\users.txt");
                temp = true;
            }
            catch (Exception)
            { 
                new User(userName, password, wordsType);
                temp = false;
            }

            if (temp == true)
            {
                temp = false;
                string[] temp1;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    temp1 = fileOutput[i].Split('-');
                    if (temp1[0] == userName)
                    {
                        temp = true;
                        break;
                    }
                }

                if (temp == true)
                {
                    Console.WriteLine("User Available under this name. Do you want to login?(y/n): ");
                    string select = Console.ReadLine();
                    if (select == "Y" || select == "y" || select == "Yes" || select == "yes") { Program.Login(); }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The program ends.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
                else
                {
                    new User(userName, password, wordsType);
                    Console.Write("Added to Users. Do you want to login?(y/n): ");
                    string select = Console.ReadLine();
                    if (select == "Y" || select == "y" || select == "Yes" || select == "yes") { Program.Login(); }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The program ends.");
                        Thread.Sleep(2000);
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Saveing");
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("Save successful :)");
                Thread.Sleep(2000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You have registered :)");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Program.Main();
            }
        }

        public static void Login()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tLogin");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter UserName: ");
            string userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter Words Type(English-Turkish): ");
            string wordsType = Console.ReadLine();

            bool temp = false;
            string[] fileOutput = new[] { "false" };
            try
            {
                fileOutput = File.ReadAllLines(@"BasicFiles\users.txt");
                temp = true;
            }
            catch (Exception)
            {
                Console.Clear();
                Program.Register();
            }

            if (temp == true)
            {
                temp = false;
                string[] file;
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    file = fileOutput[i].Split('_', '|');
                    if (file[0] == userName && file[1] == password && file[2] == wordsType)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        for (int j = 0; j < 5; j++)
                        {
                            Console.Clear();
                            Console.Write("Loading");
                            Thread.Sleep(10);
                            Console.Clear();
                            Console.Write("Loading.");
                            Thread.Sleep(10);
                            Console.Clear();
                            Console.Write("Loading..");
                            Thread.Sleep(10);
                            Console.Clear();
                            Console.Write("Loading...");
                            Thread.Sleep(10);
                            Console.Clear();
                        }

                        temp = true;
                        User.Login();
                        break;
                    }
                }

                if (temp == false)
                {
                    Console.Clear();
                    Console.WriteLine("Your name is not within users. Do you want to register?(y/n): ");
                    string select = Console.ReadLine();
                    if (select == "y" || select == "Y" || select == "yes" || select == "Yes")
                    {
                        Console.Clear();
                        Program.Register();
                    }
                    else
                    {
                        Console.Clear();
                        Login();
                    }
                }
            }
        }

        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tMenu");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1) Login");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2) Register");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Select: ");
            string select = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (select == "1")
            {
                Console.Clear();
                Program.Login();
            }
            else if (select == "2")
            {
                Console.Clear();
                Program.Register();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You didn't make the right choice. Program ends.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }
}