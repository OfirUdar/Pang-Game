using UnityEngine;
using Zenject;

namespace Game.Weapon
{
    public class HarpoonInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private HarpoonProjectile _projectile;

        public override void InstallBindings()
        {
            Container.Bind<IProjectile>().FromInstance(_projectile);
            Container.Bind<IWeapon>().To<HarpoonWeapon>().AsSingle().WithArguments(_playerTransform);
        }
    }

}
