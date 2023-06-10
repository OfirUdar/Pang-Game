using UnityEngine;

namespace Game.Obstcale
{
    public class BallDiedCommand : IDiedCommand
    {
        private readonly GameObject _ballGameObject;
        private readonly IBallSplitter _ballSplitter;
        private readonly IBallsSpawner _ballSpawner;

        public BallDiedCommand(GameObject ballGameObject, IBallSplitter ballSplitter,IBallsSpawner ballSpawner)
        {
            _ballGameObject = ballGameObject;
            _ballSplitter = ballSplitter;
            _ballSpawner = ballSpawner;
        }

        public void Execute()
        {
            _ballSpawner.Despawn(_ballGameObject);
            _ballSplitter.Split();
        }
    }

}
