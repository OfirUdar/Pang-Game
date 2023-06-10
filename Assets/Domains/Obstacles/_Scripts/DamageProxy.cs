using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class DamageProxy : MonoBehaviour, IDamageable
    {
        private IDamageable _damageable;

        [Inject]
        public void Construct(IDamageable damagable)
        {
            _damageable = damagable;
        }
        public void TakeDamage(int amount)
        {
            _damageable.TakeDamage(amount);
        }

        public void TakeFullDamage()
        {
            _damageable.TakeFullDamage();
        }
    }

}
