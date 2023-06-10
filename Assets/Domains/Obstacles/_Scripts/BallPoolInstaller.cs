using Zenject;

namespace Game.Obstcale
{
    public class BallPoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BallsPool>().AsSingle();
        }
    }

}
