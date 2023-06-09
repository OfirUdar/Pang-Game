using UnityEngine;

namespace Game.Weapon
{
    public interface IProjectile
    {
        public bool CanFire();
        public void Fire(Vector3 startPosition);
    }



}