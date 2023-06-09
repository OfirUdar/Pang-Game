using UnityEngine;
using Zenject;

namespace Game
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            if(Application.isMobilePlatform)
            {
                Container.Bind<IUserInput>().To<MobileInput>().AsSingle();
            }
            else
            {
                Container.Bind(typeof(IUserInput),typeof(ITickable)).To<PCInput>().AsSingle();
            }
        }
    }

}
