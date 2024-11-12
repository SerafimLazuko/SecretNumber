namespace SecretNumber.Core.GameMaster
{
    public abstract class GameMasterBase : IGameMaster
    {
        private int _secretNumber;

        public GameMasterBase(int min, int max)
        {
            GenerateNewSecretNumber(min, max);
        }

        public virtual void GenerateNewSecretNumber(int min, int max)
        {
            Random random = new Random();
            _secretNumber = random.Next(min, max);
        }

        public virtual int CheckGuessedValue(int guessed)
        {
            return guessed.CompareTo(_secretNumber);
        }
    }
}
