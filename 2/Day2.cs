namespace AoC2024.Day2;

class Day2 : IRunnable
{
    public Day2()
    {
        
    }


    // 68 66 67 69 72 73 76
    // getting rid of the first value (68) would render it safe
    //
    // 1 3 2 4 5
    // getting rid of the second value would render it safe
    private bool AreLevelsSafe(int[] levels, int ignore)
    {
        int i, j;
        if (ignore == 0) {
            i = 1;
            j = 2;
        } else if (ignore == 1) {
            i = 0;
            j = 2;
        } else {
            i = 0;
            j = 1;
        }

        int delta = levels[i] - levels[j];
        if (Math.Abs(delta) < 1 || Math.Abs(delta) > 3)
            return false;
        while (j < levels.Length) {
            int delta2 = levels[i] - levels[j];
            if (delta * delta2 < 1 || Math.Abs(delta2) > 3)
                return false;
            delta = delta2;
            i = j;
            if (j + 1 == ignore)
                j = j + 2;
            else
                j++;
        }
        return true;
    }

    private bool AreLevelsSafe(int[] levels)
    {
        int i = -1;
        while (i < levels.Length) {
            if (AreLevelsSafe(levels, i++))
                return true;
        }
        return false;
    }

    public int Run(string file)
    {
        using StreamReader sr = File.OpenText($"2/{file}");

        int result = 0;
        string? line;
        while ((line = sr.ReadLine()) != null) {
            var nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] levels = Array.ConvertAll(nums, int.Parse);
            
            if (AreLevelsSafe(levels))
                result++;
        }

        return result;
    }

    public int Run2(string file) {return 0;}
}
