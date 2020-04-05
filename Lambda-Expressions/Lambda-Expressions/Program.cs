using System;
using System.Linq;

namespace Lambda_Expression
{
    class Info
    {
        public static string[] numNames =
        {
            "zero",
            "first",
            "second",
            "third"
        };
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            do
            {
                Console.Clear();

                Console.WriteLine("----------------------------");
                Console.WriteLine("1. Square Numbers");
                Console.WriteLine("2. Test 2 Numbers for Equality");
                Console.WriteLine("3. Is the Text to long?");
                Console.WriteLine("4. Greet something");
                Console.WriteLine("5. Double a Tuple");
                Console.WriteLine("6. Find the Odd Numbers");
                Console.WriteLine();
                Console.WriteLine("9. Exit");
                Console.WriteLine("----------------------------");

                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.D1:
                        SquareNumbers();
                        break;
                    case ConsoleKey.D2:
                        TestTwoNumbers();
                        break;
                    case ConsoleKey.D3:
                        TestToLong();
                        break;
                    case ConsoleKey.D4:
                        Greet();
                        break;
                    case ConsoleKey.D5:
                        DoubleNumbers();
                        break;
                    case ConsoleKey.D6:
                        OddNumbers();
                        break;
                }
            } while (!(cki.Key == ConsoleKey.D9));
        }

        static int InputInt(string arg)
        {
            int Input;

            do
            {
                Console.Write(arg);
            } while (!(int.TryParse(Console.ReadLine(), out Input)));

            return Input;
        }

        static string InputString(string arg)
        {
            Console.Write(arg);
            string Input = Console.ReadLine();
            return Input;
        }

        static void SquareNumbers()
        {
            Console.Clear();

            int[] numbers = new int[0];

            do
            {
                Array.Resize(ref numbers, numbers.Length + 1);
                numbers[numbers.Length - 1] = InputInt("What number do you want to add: ");
                Console.Write("Do you want to add another number (y/n): ");
            } while (Console.ReadLine() != "n");

            var squaredNumbers = numbers.Select(x => x * x);

            Console.WriteLine(string.Join(" ", squaredNumbers));
            Console.ReadKey();
        }

        static void TestTwoNumbers()
        {
            Console.Clear();

            Func<int, int, bool> TestForEquality = (x, y) => x == y;

            int num1 = InputInt($"What is the {Info.numNames[1]} number: ");
            int num2 = InputInt($"What is the {Info.numNames[2]} number: ");

            Console.WriteLine(TestForEquality(num1, num2));
            Console.ReadKey();
        }

        static void TestToLong()
        {
            Console.Clear();

            Func<int, string, bool> TestForToLong = (x, y) => y.Length > x;

            int num = InputInt("What is the max Length for the text: ");
            string text = InputString("What is the text: ");

            Console.WriteLine(TestForToLong(num, text));
            Console.ReadKey();
        }

        static void Greet()
        {
            Console.Clear();
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}";
                Console.WriteLine(greeting);
            };

            string name = InputString("Who do you want to greet: ");

            greet(name);
            Console.ReadKey();
        }

        static void DoubleNumbers()
        {
            Console.Clear();
            Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3);

            int[] Input = new int[3];

            for (int counter = 0; counter < 3; counter++)
            {
                Input[counter] = InputInt($"What is the {Info.numNames[counter + 1]} number: ");
            }

            var numbers = (Input[0], Input[1], Input[2]);
            var doubleNumbers = doubleThem(numbers);
            Console.WriteLine($"Start: {numbers} End: {doubleNumbers}");
            Console.ReadKey();
        }

        static void OddNumbers()
        {
            Console.Clear();
            int[] numbers = new int[0];
            do
            {
                Array.Resize(ref numbers, numbers.Length + 1);
                numbers[numbers.Length - 1] = InputInt("What number do you want to add: ");
                Console.WriteLine("Do you want to add another number (y/n): ");
            } while (Console.ReadLine() != "n");

            int oddnumber = numbers.Count(n => n % 2 == 1);
            Console.WriteLine($"Count: {oddnumber} oddNumbers: {string.Join(" ", numbers)}");
            Console.ReadKey();
        }
    }
}
