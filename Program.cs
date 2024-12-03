namespace AoC2024;

class Program
{
    static void Main(string[] args)
    {
        int day = 2;
        if (args.Length > 0)
            int.TryParse(args[0], out day);

        string file = "input";
        if (args.Length > 1)
            file = args[1];

        Console.WriteLine($"Running day {day}");

        int result = 0;
        IRunnable prog;
        switch (day) {
            case 2:
                prog = new Day2.Day2();
                result = prog.Run(file); 
                break;
            case 3:
                prog = new Day3.Day3();
                result = prog.Run(file);
                break;
            default:
                break;
        }

        Console.WriteLine($"Result: {result}");

        Console.WriteLine("Have a nice day 🙂");
    }
}
