using System.Threading.Tasks;

namespace Game
{
    public class LevelsManager : ILevelsManager
    {
        private string _currentLevel;
        private int _currentLevelIndex = 0;

        private readonly string[] _levels;


        public LevelsManager(string[] levels)
        {
            _levels = levels;
        }

        public async Task LoadAsync()
        {
            _currentLevel = _levels[_currentLevelIndex];
            await SceneChanger.AwaitLoadAddtiveAsync(_currentLevel);
        }

        public async Task NextLevelAsync()
        {
            if (_currentLevelIndex + 1 == _levels.Length)
                return;

            _currentLevelIndex++;
            await SceneChanger.AwaitUnloadAsync(_currentLevel);
            await LoadAsync();
        }

        public async void RestartCurrent()
        {
            await SceneChanger.AwaitUnloadAsync(_currentLevel);
            await SceneChanger.AwaitLoadAddtiveAsync(_currentLevel);
        }
    }
}