using System.Text.RegularExpressions;

namespace AoC2024.Day3;

public partial class Day3 : IRunnable
{
    [GeneratedRegex(@"mul\((?<Left>\d+),(?<Right>\d+)\)")]
    private partial Regex MulRegex();

    private Regex _regex => MulRegex();

    internal enum Op
    {
        Do,
            Dont,
    }
    // part 2
    // do() - enable mul
    // mul(x,y) - x * y
    // don't() - disable mul
    //
    // plan:
    // create a dict int->match
    // take all indices of mul matches
    // take all indices of do and don't matches
    // put them into a sorted dict
    // iterate thru dict and keep track of bool isenabled
    public int Run2(string file)
    {
        string text = File.ReadAllText($"3/{file}");

        SortedDictionary<int, object> dict = new();

        //text.

        int result = 0;
        return result;
    }

    public int Run(string file)
    {
        string text = File.ReadAllText($"3/{file}");

        var matches = _regex.Matches(text);

        int result = 0;
        foreach (Match match in matches) {
            int left = int.Parse(match.Groups["Left"].Value);
            int right = int.Parse(match.Groups["Right"].Value);

            result += left * right;
        }

        return result;
    }
}
