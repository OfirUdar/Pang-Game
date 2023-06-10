using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BallDataSO _ballData;


        public override void InstallBindings()
        {
            Container.Bind<IBallSplitter>().To<BallSplitter>().AsSingle()
                .WithArguments(_rigidbody);

            Container.Bind<BallDataSO>().FromInstance(_ballData);

            Container.Bind<IDiedCommand>().To<BallDiedCommand>().AsSingle()
                .WithArguments(_rigidbody.gameObject);

            Container.BindInterfacesTo<Health>().AsSingle().WithArguments(100);
        }
    }

}
