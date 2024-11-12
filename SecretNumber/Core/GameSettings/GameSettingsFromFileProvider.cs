using System.Configuration;

namespace SecretNumber.Core.GameSettings
{
    internal class GameSettingsFromFileProvider : IGameSettingsProvider
    {
        private readonly GameSettings _gameSettings;

        public GameSettingsFromFileProvider()
        {
            _gameSettings = LoadSettings();
        }

        private GameSettings LoadSettings()
        {
            var tries = int.Parse(ConfigurationManager.AppSettings.Get("Tries"));
            var minValue = int.Parse(ConfigurationManager.AppSettings.Get("MinValue"));
            var maxValue = int.Parse(ConfigurationManager.AppSettings.Get("MaxValue"));

            return new GameSettings(tries, minValue, maxValue);
        }

        public GameSettings ProvideSettings() => _gameSettings;
    }
}
