namespace SecretNumber.GameHost
{
    public interface IGameHostLauncher
    {
        public string GameLaunched();

        public string GameRestarted();

        public string ProcessInput(string input);
    }
}