using Zenject;

namespace Game.Obstcale
{
    public class BallsLevelManager : IInitializable, ILateDisposable
    {
        private readonly IBallsSpawner _ballsSpawner;
        private readonly ILevelsManager _levelsManager;
        private readonly int _totalBallsAmount;

        private int _ballDespawnedAmount = 0;


        public BallsLevelManager(BallPointSpawn[] ballPoints, IBallsSpawner ballsSpawner,ILevelsManager levelsManager)
        {
            _ballsSpawner = ballsSpawner;
            _levelsManager = levelsManager;

            foreach (var ballPoint in ballPoints)
            {
                _totalBallsAmount += CalculateTotalBalls(ballPoint.BallData) + 1;
            }
        }

        public void Initialize()
        {
            _ballsSpawner.Despawned += OnBallDespawned;
        }
        public void LateDispose()
        {
            _ballsSpawner.Despawned -= OnBallDespawned;
        }

        private int CalculateTotalBalls(BallDataSO ballData)
        {
            int count = 0;
            foreach (var child in ballData.Children)
            {
                count += CalculateTotalBalls(child.Child) + child.Amount;
            }
            return count;
        }

        private void OnBallDespawned()
        {
            _ballDespawnedAmount++;
            CheckLevelWin();
        }

        private void CheckLevelWin()
        {
            if (_ballDespawnedAmount == _totalBallsAmount)
            {
                _levelsManager.NextLevelAsync();
            }
        }
    }
}