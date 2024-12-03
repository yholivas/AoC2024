namespace AoC2024.Day1;

public class Day1 : IRunnable
{
    private void ParseFile(string file, out List<int> lefts, out List<int> rights)
    {
        using StreamReader sr = File.OpenText($"1/{file}");
        string? line;
        lefts = [];
        rights = [];
        while ((line = sr.ReadLine()) != null) {
            string[] vals = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            lefts.Add(int.Parse(vals[0]));
            rights.Add(int.Parse(vals[1]));
        }
        lefts.Sort();
        rights.Sort();
    }

    public int Run(string file)
    {
        ParseFile(file, out List<int> lefts, out List<int> rights);
        int dist = 0;
        for (int i = 0; i < lefts.Count; ++i) {
            dist += Math.Abs(rights[i] - lefts[i]);
        }

        return dist;
    }

    public int Run2(string file)
    {
        ParseFile(file, out List<int> lefts, out List<int> rights);
        int sim = 0;
        foreach (int val in lefts) {
            if (rights.Contains(val))
                sim += rights.FindAll(num => num == val).Count * val;
        }

        return sim;
    }
}
