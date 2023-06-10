using System.Threading.Tasks;
using Udar.SceneManager;

namespace Game
{
    public interface ILevelsManager
    {
        public void RestartCurrent();
        public Task LoadAsync();
        public Task NextLevelAsync();
    }
}