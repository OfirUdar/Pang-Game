using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private Vector2 _startForce = new Vector2(2, 0);
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BallDataSO _ballData;


        public override void InstallBindings()
        {
            Container.Bind<IBallSplitter>().To<BallSplitter>().AsSingle();

            Container.Bind<BallDataSO>().FromInstance(_ballData);

            Container.Bind<IDiedCommand>().To<BallDiedCommand>().AsSingle()
                .WithArguments(_rigidbody.gameObject);

            Container.BindInterfacesTo<Health>().AsSingle().WithArguments(100);

            Container.BindInterfacesAndSelfTo<BallBounceDirection>().AsSingle()
                .WithArguments(_rigidbody, _startForce);
        }
    }



    public class BallDiedCommand : IDiedCommand
    {
        private readonly GameObject _ballGameObject;
        private readonly IBallSplitter _ballSplitter;

        public BallDiedCommand(GameObject ballGameObject, IBallSplitter ballSplitter)
        {
            _ballGameObject = ballGameObject;
            _ballSplitter = ballSplitter;
        }

        public void Execute()
        {
            _ballGameObject.SetActive(false);
            _ballSplitter.Split();
        }
    }
    public interface IBallSplitter
    {
        public void Split();
    }

    public class BallSplitter : IBallSplitter
    {
        private readonly BallDataSO _ballData;

        public BallSplitter(BallDataSO ballData)
        {
            _ballData = ballData;
        }

        public void Split()
        {
            foreach (var emitChildData in _ballData.Children)
            {
                for (int i = 0; i < emitChildData.Amount; i++)
                {
                    //var childInstance = GameObject.Instantiate(emitChildData.Child.Prefab);
                    //childInstance.GetComponent<Rigidbody2D>().AddForce()
                }
            }
        }
    }

}
