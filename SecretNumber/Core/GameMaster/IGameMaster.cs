namespace SecretNumber.Core.GameMaster
{
    public interface IGameMaster
    {
        public void GenerateNewSecretNumber(int min, int max);

        public int CheckGuessedValue(int guessed);
    }
}
