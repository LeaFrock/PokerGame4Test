using System.Text;

namespace PokerFace
{
    public struct PokerGameRound
    {
        private static readonly StringBuilder _sb = new(32);
        private static int _rounds = 0;

        public PokerGameRound(int player, int row, int pickCount)
        {
            Id = ++_rounds;
            Player = player;
            Row = row;
            PickCount = pickCount;
        }

        public int Id { get; set; }

        public int Player { get; }

        public int Row { get; }

        public int PickCount { get; }

        public override string ToString()
        {
            string s = _sb.Append("Round[")
                .Append(Id)
                .Append("]: Player")
                .Append(Player)
                .Append(" picks ")
                .Append(PickCount)
                .Append(" pokers from Row")
                .Append(Row)
                .ToString();
            _sb.Clear();
            return s;
        }
    }
}