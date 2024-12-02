namespace AoC2024.Day2;

class Day2
{
    public Day2()
    {
        
    }

    private bool AreLevelsSafe(int[] levels)
    {
        int delta = levels[0] - levels[1];
        if (Math.Abs(delta) < 1 || Math.Abs(delta) > 3)
            return false;
        for (int i = 1; i < levels.Length - 1; ++i) {
            int delta2 = levels[i] - levels[i+1];
            if (delta * delta2 < 1 || Math.Abs(delta2) > 3)
                return false;
            delta = delta2;
        }
        return true;
    }

    public int Run(string file)
    {
        using StreamReader sr = File.OpenText($"2/{file}");

        int result = 0;
        string? line;
        while ((line = sr.ReadLine()) != null) {
            //Console.WriteLine($"Line: {line}");
            var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] levels = Array.ConvertAll(nums, int.Parse);
            
            if (AreLevelsSafe(levels)) {
                //Console.WriteLine("Safe");
                result++;
            } else {
                //Console.WriteLine("Unsafe");
            }
        }

        return result;
    }
}
