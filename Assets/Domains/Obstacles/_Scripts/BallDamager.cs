using UnityEngine;

namespace Game.Obstcale
{
    public class BallDamager : MonoBehaviour
    {

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                if(collision.gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeFullDamage();
                }
            }
        }
    }

}
