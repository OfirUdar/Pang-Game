using UnityEngine;

namespace Game.Obstcale
{
    public class BallSplitter : IBallSplitter
    {
        private readonly BallDataSO _ballData;
        private readonly Rigidbody2D _rigidbody;
        private readonly IBallsSpawner _ballSpawner;

        public BallSplitter(BallDataSO ballData, Rigidbody2D rigidbody,IBallsSpawner ballsSpawner)
        {
            _ballData = ballData;
            _rigidbody = rigidbody;
            _ballSpawner = ballsSpawner;
        }

        public void Split()
        {
            foreach (var emitChildData in _ballData.Children)
            {
                for (int i = 0; i < emitChildData.Amount; i++)
                {
                    bool isRight = i % 2 == 0;
                    var position = isRight ? Vector2.right : Vector2.left;
                    //var childInstance = GameObject.Instantiate(emitChildData.Child.Prefab,
                    //    _rigidbody.position + position / 4f, Quaternion.identity);
                    var childInstance = _ballSpawner.Spawn(emitChildData.Child.Prefab,
                        _rigidbody.position + position / 4f);

                    if (isRight)
                        childInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 5f),ForceMode2D.Impulse);
                    else
                        childInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 5f), ForceMode2D.Impulse);
                }
            }
        }
    }

}
