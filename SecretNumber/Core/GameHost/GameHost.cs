using SecretNumber.Core.GameMaster;

namespace SecretNumber.Core.GameHost
{
    public class GameHost
    {
        private IGameMaster _gameMaster;
        private GameSettings.GameSettings _settings;
        private int _triesLeft;

        public GameHost(IGameMaster gameMaster, GameSettings.GameSettings settings)
        {
            _triesLeft = settings.tries;
            _settings = settings;
            _gameMaster = gameMaster;
        }

        public void GameRestart()
        {
            _triesLeft = _settings.tries;
            _gameMaster.GenerateNewSecretNumber(_settings.minValue, _settings.maxValue);
        }

        public string CheckGuessed(int guessed)
        {
            if (_triesLeft == 0)
            {
                return Properties.Resources.NoTriesLeftWarning;
            }

            _triesLeft--;

            var check = _gameMaster.CheckGuessedValue(guessed);

            var result = string.Empty;

            switch (check)
            {
                case 1:
                    result = string.Format(Properties.Resources.GuessedBiggerThanSecret, _triesLeft);
                    break;
                case -1:
                    result = string.Format(Properties.Resources.GuessedSmallerThanSecret, _triesLeft);
                    break;
                case 0:
                    result = Properties.Resources.GuessedRight;
                    _triesLeft = 0;
                    break;
                default:
                    result = string.Format(Properties.Resources.Default_GameMaster, _triesLeft);
                    break;
            }

            return result;
        }
    }
}
