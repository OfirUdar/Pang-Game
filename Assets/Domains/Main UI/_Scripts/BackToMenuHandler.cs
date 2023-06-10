using Udar.SceneManager;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class BackToMenuHandler : MonoBehaviour
    {
        [SerializeField] private Button _backToMenuButton;
        [SerializeField] private SceneField _menuScene;

        private void OnEnable()
        {
            _backToMenuButton.onClick.AddListener(OnClicked);
        }
        private void OnDisable()
        {
            _backToMenuButton.onClick.RemoveListener(OnClicked);
        }


        private void OnClicked()
        {
            SceneChanger.LoadSingleAsync(_menuScene.Name);
        }

    }

}
