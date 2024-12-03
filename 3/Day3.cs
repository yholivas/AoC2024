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
    private void AddOccurences(IDictionary<int, object> dict, string text, string match, object obj)
    {
        int i = 0;
        while ((i = text.IndexOf(match, i)) >= 0) {
            dict.Add(i, obj);
            i++;
        }
    }

    private int ProcessMatch(Match match)
    {
        int left = int.Parse(match.Groups["Left"].Value);
        int right = int.Parse(match.Groups["Right"].Value);

        return left * right;
    }

    public int Run2(string file)
    {
        string text = File.ReadAllText($"3/{file}");

        SortedDictionary<int, object> dict = new();

        AddOccurences(dict, text, "don't()", Op.Dont);
        AddOccurences(dict, text, "do()", Op.Do);

        var matches = _regex.Matches(text);

        int result = 0;
        foreach (Match match in matches)
            dict.Add(match.Index, match);

        bool isEnabled = true;
        foreach (var obj in dict.Values) {
            if (obj is Match match && isEnabled)
                result += ProcessMatch(match);
            else if (obj is Op.Dont)
                isEnabled = false;
            else if (obj is Op.Do)
                isEnabled = true;
        }

        return result;
    }

    public int Run(string file)
    {
        string text = File.ReadAllText($"3/{file}");

        var matches = _regex.Matches(text);

        int result = 0;
        foreach (Match match in matches) {
            result += ProcessMatch(match);
        }

        return result;
    }
}
