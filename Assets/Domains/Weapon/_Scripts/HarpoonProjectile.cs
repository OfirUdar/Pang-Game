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
            if (collision.gameObject.tag.Equals("Wall"))
                gameObject.SetActive(false);

            if (collision.transform.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeFullDamage();
                gameObject.SetActive(false);
            }
        }

    }



}