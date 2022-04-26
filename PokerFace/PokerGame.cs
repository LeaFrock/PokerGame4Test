namespace PokerFace
{
    public class PokerGame
    {
        private readonly int[] _state;
        private int _left;
        private PokerGameRound _currentRound = default;

        public int LeftCount => _left;

        public int PlayerCount { get; }

        public PokerGame(GemeConfig config)
        {
            config.Check();
            _state = config.Group.ToArray();
            _left = _state.Sum();
            PlayerCount = config.PlayerCount;
            Console.WriteLine("Game Start!");
        }

        public bool IsOver => _left <= 1;

        public bool CanPick(int row, int count)
            => row >= 1 && count >= 1
            && row <= _state.Length && count <= _state[row - 1];

        public void NewRound(int player, int row, int count)
        {
            _state[row - 1] -= count;
            _left -= count;
            _currentRound = new(player, row, count);
            Console.WriteLine(_currentRound.ToString());
            Console.WriteLine($"CurrentState: {System.Text.Json.JsonSerializer.Serialize(_state)}");
        }

        public void Over()
        {
            if (LeftCount > 1)
            {
                return;
            }
            if (LeftCount == 1)
            {
                Console.WriteLine($"Player{NextPlayer()} lose.");
            }
            else if (LeftCount == 0)
            {
                Console.WriteLine($"Player{_currentRound.Player} lose.");
            }
            Console.WriteLine("Game Over!");
        }

        public int NextPlayer()
            => _currentRound.Player == PlayerCount ? 1 : _currentRound.Player + 1;
    }
}