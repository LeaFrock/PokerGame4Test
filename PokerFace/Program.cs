// See https://aka.ms/new-console-template for more information
using PokerFace;

GemeConfig gameConfig = new()
{
    Group = new int[] { 3, 5, 7 },
    PlayerCount = 2
};
PokerGame game = new(gameConfig);
string input; int row, pickCount, currentPlayer;
while (!game.IsOver)
{
    currentPlayer = game.NextPlayer();
    Console.WriteLine($"Player{currentPlayer} Round, input please...");
    while (true)
    {
        input = Console.ReadLine();
        if (!ValidateInputFormat(input, out row, out pickCount))
        {
            Console.WriteLine("Invalid Input. Format: \"<Row> <PickCount>\"");
            continue;
        }
        if (!game.CanPick(row, pickCount))
        {
            Console.WriteLine("Invalid Pick. Pick again...");
            continue;
        }
        break;
    }
    game.NewRound(currentPlayer, row, pickCount);
}
game.Over();
Console.ReadKey();

static bool ValidateInputFormat(string input, out int row, out int pickCount)
{
    if (string.IsNullOrWhiteSpace(input))
    {
        row = 0; pickCount = 0;
        return false;
    }
    string[] temp = input.Split(' ');
    if (temp.Length != 2)
    {
        row = 0; pickCount = 0;
        return false;
    }
    if (!int.TryParse(temp[0], out row))
    {
        pickCount = 0;
        return false;
    }
    if (!int.TryParse(temp[1], out pickCount))
    {
        return false;
    }
    return true;
}