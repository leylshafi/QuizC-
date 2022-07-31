using System;
using System.Threading;

namespace hw2
{
    class Program
    {
        static void Main()
        {
            int score = 0;

            string[,] questions = new string[,]
            {
                {"What is the boiling point temperature (water)?", "10,0","0,0","100,1" },
                {  "Which fruit is associated with Isaac Newton?","Apple,1","Banana,0","Orange,0" },
                {  "In which city did Diana, Princess of Wales, died?","Baku,0","Paris,1","London,0" },
                {  "Which actor played Rocky?","Carl,0","Sylvester,1","Dan,0"},
                { "What is the capital city of Australia?","Baku,0","London,0","Canberra,1"},
                {"What is the capital city of Azerbaijan?", "Ganja,0","Baku,1","Sumgayit,0" },
                { "Ganja is famous for whom?","Nasimi,0","Nizami,1","None,0" },
                {   "This year is the year of","Shusha,1","Nizami,0","Olympic,0" },
                {  "What is the Italian word for \"pie\"?","Pizza,1","Pia,0","None,0"},
                { "What is one quarter of 1,000?","200,0","250,1","15,0" }
            };

            int choice=default;
            bool ask = true;
            Console.WriteLine("Welcome to Quiz!");
            Thread.Sleep(1000);
            Console.Clear();

            for (int i = 0; i < questions.Length; i++)
            {
                while (ask)
                {
                    
                    if (i < 10)
                    {
                        Console.WriteLine($"{i + 1}){questions[i, 0]}");
                        for (int j = 1; j < 4; j++)
                        {
                            
                            if (j == choice)
                                Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{(char)(j + 64)}) {questions[i, j].Split(',')[0]}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (choice != 0)
                                    choice--;
                                else
                                    choice = 3;
                                break;
                            case ConsoleKey.DownArrow:
                                if (choice != 3)
                                    choice++;
                                else
                                    choice = 0;
                                break;
                            case ConsoleKey.Enter:
                                ask = false;
                                Console.Clear();
                                Console.WriteLine($"{i + 1}) {questions[i, 0]}");
                                for (int f = 1; f < 4; f++)
                                {
                                    if (f == choice && questions[i, f].Split(',')[1] == "1")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        score += 10;
                                    }
                                    else if (f == choice)
                                    {
                                        score -= 10;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    Console.WriteLine($"{(char)(f + 65)}) {questions[i, f].Split(',')[0]}");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                if (score < 0) score = 0;
                                Console.WriteLine($"Score: {score}");
                                Thread.Sleep(1000);
                                i++;
                                break;

                        }
                        Console.Clear();
                        ask = true;
                        if (i == 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"            Your total score is {score}!");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("                 Congratulations!!!".PadRight(40));
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(0);
                        }
                    }
                }
            }
           

        }

    }
}
