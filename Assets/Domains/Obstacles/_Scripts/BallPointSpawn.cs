using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallPointSpawn : MonoBehaviour
    {
        [SerializeField] private BallDataSO _ballData;
        [SerializeField] private Vector2 _startForce = new Vector2(2, 1);

        [Inject] private readonly IBallsSpawner _ballSpawner;

        public BallDataSO BallData => _ballData;

        private void Start()
        {
            var ball = _ballSpawner.Spawn(_ballData.Prefab, transform.position);
            ball.GetComponent<Rigidbody2D>().AddForce(_startForce, ForceMode2D.Impulse);
        }
    }

}
