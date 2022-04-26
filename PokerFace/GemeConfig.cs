namespace PokerFace
{
    public class GemeConfig
    {
        public int[] Group { get; set; }

        public int PlayerCount { get; set; } = 2;

        public void Check()
        {
            ArgumentNullException.ThrowIfNull(Group);
            if (Group.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Group));
            }
            if (PlayerCount < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(PlayerCount));
            }
        }
    }
}