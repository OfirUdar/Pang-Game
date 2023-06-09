using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Rigidbody2D _playerRigidBody;

        private readonly MovementData _movemenetData = new MovementData()
        {
            Speed = 10,
        };

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Shooter>().AsSingle();
            Container.Bind(typeof(ITickable), typeof(IFixedTickable)).To<Movement>().AsSingle()
                .WithArguments(_playerRigidBody, _movemenetData);
        }

    }
}
