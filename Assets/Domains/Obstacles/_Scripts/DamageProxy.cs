using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class DamageProxy : MonoBehaviour, IDamagable
    {
        private IDamagable _damageable;

        [Inject]
        public void Construct(IDamagable damagable)
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
