namespace SecretNumber.Core.GameSettings
{
    public class GameSettings
    {
        public readonly int tries;
        public readonly int minValue;
        public readonly int maxValue;

        public GameSettings(int tries, int minValue, int maxValue)
        {
            this.tries = tries;
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}
