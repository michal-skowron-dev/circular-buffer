using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularBuffer
{
    class Program
    {
        static char[] coll = new char[7];
        static List<char> signs = new List<char>();
        static string choice;
        static int delete, position, i;
        static bool start;

        static void Show()
        {
            Console.WriteLine(string.Format("[{0}] [{1}] [{2}] [{3}] [{4}] [{5}] [{6}]", coll[0], coll[1], coll[2], coll[3], coll[4], coll[5], coll[6]));
            Console.WriteLine();
        }

        static void Write()
        {
            SetPosition();
            Console.WriteLine("Any word to write:");
            signs.AddRange(Console.ReadLine());

            while (signs.Count != 0)
            {
                coll[position] = signs[0];
                signs.RemoveAt(0);
                CalculatePosition();
            }

            Console.WriteLine();
        }

        static void Remove()
        {

            Console.WriteLine("How many elements to remove?");
            int.TryParse(Console.ReadLine(), out delete);

            for (i = 0; i < delete; i++)
                coll[(position + i) % 6] = '\0';

            Console.WriteLine();
        }

        static void CalculatePosition()
        {
            position = (position + 1) % 7;
        }

        static void SetPosition()
        {
            if (!start)
            {
                while (true)
                {
                    Console.WriteLine("Set start position: 0 1 2 3 4 5 6");
                    int.TryParse(Console.ReadLine(), out position);

                    if (position >= 0 && position <= 6)
                    {
                        start = true;
                        return;
                    }
                }
            }
        }

        static void Info()
        {
            Console.WriteLine("Commands: Show, Write, Remove, Info, Exit");
            Console.WriteLine();
        }

        static void Menu()
        {
            Info();
            while (true)
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "Show":   Show();   break;
                    case "Write":  Write();  break;
                    case "Remove": Remove(); break;
                    case "Info":   Info();   break;
                    case "Exit":             return;
                    default:       Info();   break;
                }
            }
        }

        static void Main(string[] args)
        {
            Menu();
            Console.ReadKey();
        }
    }
}
