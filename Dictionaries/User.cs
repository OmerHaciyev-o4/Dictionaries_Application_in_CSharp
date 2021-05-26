using System;
using System.IO;
using System.Threading;

namespace Dictionaries
{
    public class User
    {
        public User(){}

        public User(string userName, string password, string wordsType)
        {
            string newFolder = Path.Combine(@"", "BasicFiles");
            Directory.CreateDirectory(newFolder);
            File.AppendAllText(@"BasicFiles\users.txt", userName + "_" + password + "|" + wordsType + "\n");
        }

        public static void Login()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t\tUser Menu -> Welcome");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1) Add Word and surrounded");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2) Word and surrounded make say");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3) Word and surrounded deleted");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("4) Search Word");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("0) Exit");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Select: ");
            string select = Console.ReadLine();

            if (select == "1")
            {
                Words.AddWord();
            }
            else if (select == "2")
            {
                Words.MakeSayWord();
            }
            else if (select == "3")
            {
                Words.DeletedWord();
            }
            else if (select == "4")
            {
                Console.Clear();
                Console.Write("Enter Username: "); string userName = Console.ReadLine();
                string filePath = @"BasicFiles\" + userName + @"Words.txt";
                string[] fileOutput = new[] {"false"};
                Boolean temp = false;

                try
                {
                    fileOutput = File.ReadAllLines(filePath);
                    temp = true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Words no created");
                    Thread.Sleep(2000);
                    Console.Clear();
                    User.Login();
                }

                if (temp == true)
                {
                    temp = false;
                    Words.SearchWord(fileOutput, temp);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You did not make the right choice");
                Thread.Sleep(2000);
                Console.Clear();
                Login();
            }
        }
    }
}