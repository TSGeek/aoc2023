using System.Text;

var matchList = new Dictionary<string, int>
{
    {"1", 1},
    {"2", 2},
    {"3", 3},
    {"4", 4},
    {"5", 5},
    {"6", 6},
    {"7", 7},
    {"8", 8},
    {"9", 9},
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9},
};
var sum = 0;
var lineCount = 1;
var matchedLines = new List<string>();
var lines = File.ReadLines(@".\input.txt", Encoding.UTF8);

foreach (var line in lines)
{
    matchedLines.Clear();
    for (int i = 0; i < line.Length; i++)
    {
        foreach (var match in matchList)
        {
            if (!(match.Key.Length > line.Length - i))
            {
                var word = line.Substring(i, match.Key.Length);
                if (word.Equals(match.Key))
                {
                    matchedLines.Add(word);
                }
            }
        }
    }

    var num1 = matchList.FirstOrDefault(m => m.Key == matchedLines[0]).Value;
    var num2 = matchedLines.Count() > 1 ? matchList.FirstOrDefault(m => m.Key == matchedLines[matchedLines.Count()-1]).Value : num1;
    
    Console.WriteLine("For line" + lineCount + " : number 1 = " + num1 + ", number 2 = " + num2);

    sum += (num1 * 10 + num2);
    lineCount++;
}
Console.WriteLine("The sum of all lines is : " + sum);