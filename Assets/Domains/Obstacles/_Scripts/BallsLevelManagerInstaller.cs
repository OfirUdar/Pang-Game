using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallsLevelManagerInstaller : MonoInstaller
    {
        [SerializeField] private BallPointSpawn[] _points;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BallsLevelManager>().AsSingle().WithArguments(_points);

        }
    }

}
