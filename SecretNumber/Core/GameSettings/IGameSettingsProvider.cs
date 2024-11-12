namespace SecretNumber.Core.GameSettings
{
    public interface IGameSettingsProvider
    {
        public GameSettings ProvideSettings();
    }
}