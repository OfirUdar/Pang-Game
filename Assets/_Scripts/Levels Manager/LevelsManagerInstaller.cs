using Udar.SceneManager;
using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelsManagerInstaller : MonoInstaller
    {
        [SerializeField] private SceneCompositeSO _levels;

        public override void InstallBindings()
        {
            Container.Bind<ILevelsManager>().To<LevelsManager>().AsSingle().WithArguments(_levels.Names);
        }
    }
}