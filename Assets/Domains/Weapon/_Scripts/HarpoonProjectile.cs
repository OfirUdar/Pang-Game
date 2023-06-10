using UnityEngine;

namespace Game.Weapon
{
    public class HarpoonProjectile : MonoBehaviour, IProjectile
    {
        public bool CanFire()
        {
            return !gameObject.activeSelf;
        }

        public void Fire(Vector3 startPosition)
        {
            transform.position = startPosition;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
                gameObject.SetActive(false);

            if (!collision.gameObject.CompareTag("Player") &&
                collision.transform.TryGetComponent(out IDamageable damagable))
            {
                damagable.TakeFullDamage();
                gameObject.SetActive(false);
            }
        }

    }



}