using System.Text;

var lines = File.ReadLines(@".\input.txt", Encoding.UTF8);
var sum = 0;

foreach (var line in lines)
{
    var game = line.Split(":");
    var minCubes = new Dictionary<string, int>
    {
        { "red", 0 },
        { "green", 0 },
        {"blue", 0}
    };
    foreach (var sets in game[1].Trim().Split(";"))
    {
        foreach (var cube in sets.Trim().Split(','))
        {
            var infos = cube.Trim().Split(" ");
            var number = Int32.Parse(infos[0]);
            var colour = infos[1];

            if (minCubes[colour] < number)
            {
                minCubes[colour] = number;
            }
        }
    }

    var result = 1;
    foreach (var cubesNumber in minCubes.Values)
    {
        result *= cubesNumber;
    }

    sum += result;
}

Console.WriteLine("The sum of the power of all game minimum cubes is : " + sum);