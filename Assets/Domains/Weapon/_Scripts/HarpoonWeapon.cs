using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Game.Weapon
{
    public class HarpoonWeapon : IWeapon
    {
        private readonly Transform _playerTransform;
        private readonly IProjectile _projectile;

        public HarpoonWeapon(Transform playerTransform, IProjectile projectile)
        {
            _playerTransform = playerTransform;
            _projectile = projectile;
        }

        public void Fire()
        {
            if (_projectile.CanFire())
                _projectile.Fire(_playerTransform.position + Vector3.up * 0.05f);
        }
    }



}