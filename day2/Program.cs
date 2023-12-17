using System.Text;

var lines = File.ReadLines(@".\input.txt", Encoding.UTF8);

var cubesInBag = new Dictionary<string, int>
{
    {"red", 12},
    {"blue", 14},
    {"green", 13}
};

var validGames = new List<int>();

foreach (var line in lines)
{
    var game = line.Split(":");
    var gameNumber = Int32.Parse(game[0].Trim().Split(" ")[1]);
    if (GameIsValid(game[1], cubesInBag))
    {
        validGames.Add(gameNumber);
    }
}

Console.WriteLine("The sum of all valid game numbers' is : " + validGames.Sum());

static bool GameIsValid(string game, Dictionary<string, int> cubesInBag)
{
    var sets = game.Trim().Split(";");
    foreach (var set in sets)
    {
        if (!SetIsValid(set, cubesInBag))
        {
            return false;
        }
    }
    return true;
}

static bool SetIsValid(string set, Dictionary<string, int> cubesInBag)
{
    var cubes = set.Trim().Split(",");
    foreach (var cube in cubes)
    {
        var infos = cube.Trim().Split(" ");
        var number = Int32.Parse(infos[0]);
        var colour = infos[1];

        if (cubesInBag[colour] < number)
        {
            return false;
        }
    }
    return true;
}