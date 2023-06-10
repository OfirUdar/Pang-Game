using Udar.SceneManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private SceneField _mobileInputUIScene;

        public override void InstallBindings()
        {
            if (Application.isMobilePlatform)
            {
                Application.targetFrameRate = 60;
                Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
                SceneManager.LoadScene(_mobileInputUIScene.Name, LoadSceneMode.Additive);
            }
            else
            {
                Container.Bind(typeof(IUserInput), typeof(ITickable)).To<PCInput>().AsSingle();
            }
        }
    }

}
