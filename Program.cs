internal class Program
{
    private static void Main(string[] args)
    {
        string fileName = "students.txt";
        if (args.Length > 0)
        {
            fileName = args[0];
        }

        IEnumerable<string> studentsFromFile;
        try
        {
            studentsFromFile = File.ReadLines(fileName);
        }
        catch
        {
            Console.WriteLine("No student list found, using demo list.");
            Console.ReadKey();
            studentsFromFile = new List<string>() { "Stefan", "Gun", "Tröstur" };
        }

        Random randomGenerator = new();
        List<string> studentsToAsk = new();

        while (true)
        {
            studentsToAsk = new List<string>(studentsFromFile);

            while (studentsToAsk.Count > 0)
            {
                Console.Clear();
                int randomNumber = randomGenerator.Next(studentsToAsk.Count);
                string student = studentsToAsk[randomNumber];

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Kvar att fråga: " + studentsToAsk.Count);
                Console.ForegroundColor = ConsoleColor.Green;
                //dotnet add package FIGlet.Net --version 1.1.2
                Console.WriteLine(new WenceyWang.FIGlet.AsciiArt(student));
                studentsToAsk.Remove(student);

                //Kolla om vi trycker ESC, isf avsluta programmet
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.Escape)
                {
                    Console.ResetColor();
                    Environment.Exit(0);
                }
            }

            Console.ResetColor();
            Console.WriteLine("Listan är slut. Vill du börja om? (j/N)");
            if (Console.ReadKey().Key != ConsoleKey.J)
            {
                break;
            }
        }
    }
}