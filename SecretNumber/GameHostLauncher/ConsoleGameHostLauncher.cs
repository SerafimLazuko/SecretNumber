using SecretNumber.Core.GameMaster;
using SecretNumber.Core.GameSettings;

namespace SecretNumber.GameHost
{
    internal class ConsoleGameHostLauncher : IGameHostLauncher
    {
        private Core.GameHost.GameHost _game;
        private string _gameParametersString;

        public ConsoleGameHostLauncher()
        {
            IGameSettingsProvider gameSettingsProvider = new GameSettingsFromFileProvider();
            var gameSettings = gameSettingsProvider.ProvideSettings();
            DefaultGameMaster gameMaster = new DefaultGameMaster(gameSettings.minValue, gameSettings.maxValue);
            _game = new Core.GameHost.GameHost(gameMaster, gameSettings);
            _gameParametersString = string.Format(Properties.Resources.GameParameters, gameSettings.minValue, gameSettings.maxValue, gameSettings.tries);
        }

        public string GameLaunched()
        {
            return Properties.Resources.GameStarted + "\n" + _gameParametersString;
        }

        public string GameRestarted() 
        {
            return Properties.Resources.GameRestart + "\n" + _gameParametersString;
        }

        public string ProcessInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return Properties.Resources.DefaultTextHelpCommand;
            }

            if (input == "help")
            {
                return Properties.Resources.HelpCommand;
            }

            if (input == "new")
            {
                _game.GameRestart();
                return GameRestarted();
            }

            if (input == "quit")
            {
                return Properties.Resources.GameOver;
            }

            if (int.TryParse(input, out int exitCode))
            {
                return _game.CheckGuessed(exitCode);
            }

            return Properties.Resources.Default_GameLauncher;
        }
    }
}
