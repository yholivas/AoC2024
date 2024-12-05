namespace AoC2024.Day4;

public class Day4 : IRunnable
{
    private bool IsMatch(string text, int idx, int[] offsets, char[] matchList)
    {
        for (int i = 0; i < 3; ++i) {
            int offset = offsets[i];
            char matchChar = matchList[i];

            int peekIdx = idx + offset;
            if (peekIdx >= text.Length || text[peekIdx] != matchChar)
                return false;
        }

        return true;
    }

    public int Run(string file)
    {
        int result = 0;

        string text = File.ReadAllText($"4/{file}");

        int lineLength = 0;
        while (text[lineLength] != '\n')
            lineLength++;
        lineLength++;

        int[][] offsets = [
            [lineLength, lineLength * 2, lineLength * 3],
            [lineLength + 1, (lineLength + 1) * 2, (lineLength + 1) * 3],
            [1, 2, 3],
            [lineLength - 1, (lineLength - 1) * 2, (lineLength - 1) * 3]
        ];

        char[] xList = ['M', 'A', 'S'];
        char[] sList = ['A', 'M', 'X'];

        for (int i = 0; i < text.Length; ++i) {
            char ch = text[i];
            if (ch == 'X' || ch == 'S') {
                char[] list = ch == 'X' ? xList : sList;

                foreach (int[] offsetList in offsets) {
                    if (IsMatch(text, i, offsetList, list))
                        result++;
                }
            }
        }

        return result;
    }

    public int Run2(string file)
    {
        int result = 0;

        return result;
    }
}
