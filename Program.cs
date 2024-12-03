namespace AoC2024;

class Program
{
    static void Main(string[] args)
    {
        Arguments arguments = ParseArgs(args);

        Console.WriteLine($"Running day {arguments.Day}");

        IRunnable prog = arguments.Day switch {
            1 => new Day1.Day1(),
            2 => new Day2.Day2(),
            3 => new Day3.Day3(),
            _ => throw new ArgumentException("Invalid day specified")
        };

        int result = arguments.IsRun2 ? prog.Run2(arguments.File) : prog.Run(arguments.File);

        Console.WriteLine($"Result: {result}");

        Console.WriteLine("Have a nice day 🙂");
    }

    private static Arguments ParseArgs(string[] args)
    {
        Arguments arguments = new();
        int i = 0;
        while (i < args.Length) {
            if (args[i] == "--file")
                arguments.File = args[++i];
            else if (args[i] == "--day") {
                int.TryParse(args[++i], out int day);
                arguments.Day = day;
            } else if (args[i] == "-2")
                arguments.IsRun2 = true;

            i++;
        }

        return arguments;
    }

    internal class Arguments
    {
        public string File = "input";
        public int Day = 1;
        public bool IsRun2 = false;
    }
}
