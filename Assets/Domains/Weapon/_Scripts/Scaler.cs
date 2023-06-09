using UnityEngine;

namespace Game
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private readonly float _speed = 15f;

        private void OnDisable()
        {
            var size = _spriteRenderer.size;
            size.y = 0;
            _spriteRenderer.size = size;
        }
        public void Update()
        {
            var size = _spriteRenderer.size;
            size.y += _speed * Time.deltaTime;
            _spriteRenderer.size = size;
        }
    }




}
