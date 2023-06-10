using System;
using Udar.SceneManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game.Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private SceneField _menu;
        [SerializeField] private SceneFieldComposite _mainScenes;

        [Inject] private readonly ILevelsManager _levelsManager;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
        }
        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
        }


        private void OnPlayClicked()
        {
            LoadMainAsync();
        }

        private async void LoadMainAsync()
        {
            await SceneChanger.AwaitLoadAddtiveAsync(_mainScenes.Names);
            await _levelsManager.LoadAsync();
            SceneChanger.UnloadAsync(_menu.Name);
        }

    }

}
