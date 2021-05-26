using System;
using System.IO;
using System.Threading;

namespace Dictionaries
{
    public class Words
    {
        private static string temp = new string("false");
        private static string[] temp1 = new[]{"false"};

        public static void AddWord()
        {
            #region UserRequest

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("if the translation is two or less, write 'no' to the rest.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter word: ");
            string word = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter the translation of the previous word: ");
            string translation = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter surrounded1: ");
            string surrounded1 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter surrounded2: ");
            string surrounded2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter surrounded3: ");
            string surrounded3 = Console.ReadLine();
            #endregion

            string[] fileOutput = new[] { "false" };
            string filePath = @"BasicFiles\" + username + "Words.txt";
            string filePath1 = @"BasicFiles\users.txt";
            string[] temp2 = new[] { "false" };

            try
            {
                fileOutput = File.ReadAllLines(filePath);
                var temp3 = fileOutput;
                fileOutput = new string[temp3.Length + 1];
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    if (i == fileOutput.Length - 1)
                    {
                        fileOutput[i] = $"{word}|{translation}({surrounded1}|{surrounded2}|{surrounded3})";
                        break;
                    }

                    fileOutput[i] = temp3[i];
                }
                File.WriteAllLines(filePath, fileOutput);
            }
            catch (Exception)
            {
                string temp1 = null;

                fileOutput = File.ReadAllLines(filePath1);

                for (int i = 0; i < fileOutput.Length; i++)
                {
                    temp2 = fileOutput[i].Split(new char[]{'_','|'});
                    if (temp2[0] == username)
                    {
                        temp1 = temp2[2];
                        break;
                    }
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine($"{temp1}");
                    sw.Write(word + "|" + translation + "(" + surrounded1 + "|" + surrounded2 + "|" + surrounded3 + ")");
                }
            }

            Console.Clear();
            Console.WriteLine("Save successful");
            Thread.Sleep(2000);
            Console.Clear();
            User.Login();
        }

        public static void MakeSayWord()
        {
            #region UserRequest

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            //---------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("The word to be said: ");
            string word = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter new word: ");
            string newWord = Console.ReadLine();

            //----------
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("The translation to be said: ");
            string translation = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter new translation word: ");
            string newTranslation = Console.ReadLine();

            //----------
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Will say surrounded1: ");
            string surrounded1 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter new surrounded1: ");
            string newSurrounded1 = Console.ReadLine();

            //----------
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Will say surrounded2: ");
            string surrounded2 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter new surrounded2: ");
            string newSurrounded2 = Console.ReadLine();

            //----------
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Will say surrounded3: ");
            string surrounded3 = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter new surrounded3: ");
            string newSurrounded3 = Console.ReadLine();

            #endregion

            string[] fileOutput = new[] {"false"};
            string filePath = @"BasicFiles\" + username + @"Words.txt";

            try
            {
                fileOutput = File.ReadAllLines(filePath);
                string[] temp = new[] {"false"};

                for (int i = 0; i < fileOutput.Length; i++)
                {
                    temp = fileOutput[i].Split(new char[] {'|', '(', ')'});
                    if (temp[0] == word && temp[1] == translation && temp[2] == surrounded1 && temp[3] == surrounded2 && temp[4] == surrounded3)
                    {
                        fileOutput[i] = $"{newWord}|{newTranslation}({newSurrounded1}|{newSurrounded2}|{newSurrounded3})";
                        break;
                    }
                }

                File.WriteAllLines(filePath, fileOutput);

                Console.Clear();
                Console.WriteLine("words was successfully changed");
                Thread.Sleep(2000);
                Console.Clear();
                User.Login();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Words no created");
                Thread.Sleep(2000);
                Console.Clear();
                User.Login();
            }
        }

        public static void DeletedWord()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter word: ");
            string word = Console.ReadLine();
            Console.Clear();

            string[] fileOutput = new[] {"false"};
            string filePath = @"BasicFiles\" + username + @"Words.txt";

            try
            {
                fileOutput = File.ReadAllLines(filePath);
                string[] temp = new[] {"false"};
                string[] correctinfo = new string[fileOutput.Length - 1];

                for (int i = 0, j = 0; i < fileOutput.Length; i++)
                {
                    temp = fileOutput[i].Split(new char[] {'|', '(', ')'});
                    if (temp[0] != word)
                    {
                        correctinfo[j] = fileOutput[i];
                        j++;
                    }
                }

                File.WriteAllLines(filePath, correctinfo);

                Console.Clear();
                Console.WriteLine("The word was successfully deleted");
                Thread.Sleep(2000);
                Console.Clear();
                User.Login();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Words no created");
                Thread.Sleep(2000);
                Console.Clear();
                User.Login();
            }
        }

        public static void SearchWord(string[] fileOutput, bool t)
        {
            Console.Clear();
            Console.Write("Enter word: ");
            temp = Console.ReadLine();
            if (temp == "Exit" || temp == "exit")
            {
                Console.Clear();
                User.Login();
            }
            else
            {
                Console.Clear();
                for (int i = 0; i < fileOutput.Length; i++)
                {
                    temp1 = fileOutput[i].Split(new char[]{'|','(',')'});
                    if (temp1[0] == temp)
                    {
                        Console.WriteLine("Word:\tTranslationWord:");
                        Console.WriteLine($"{temp1[0]}|\t{temp1[1]}, {temp1[2]}, {temp1[3]}, {temp1[4]}");
                        Console.Write("press the desired button:");
                        Console.ReadKey();
                        t = true;
                        break;
                    }
                }

                if (t == false)
                {
                    Console.Clear();
                    Console.WriteLine("There are no words you are looking for");
                    Thread.Sleep(2000);
                    Console.Clear();
                    t = false;
                }
                SearchWord(fileOutput, t);
            }
        }
    }
}