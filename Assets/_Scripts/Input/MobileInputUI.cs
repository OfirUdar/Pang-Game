using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class MobileInputUI : MonoBehaviour
    {
        [SerializeField] private PointerDownDetecter _moveRightButton;
        [SerializeField] private PointerDownDetecter _moveLeftButton;
        [SerializeField] private Button _shootButton;

        [Inject] private MobileInput _input;

        private void OnEnable()
        {
            _moveRightButton.Down += OnRightPressed;
            _moveRightButton.Up += OnPointerUp;
            _moveLeftButton.Down += OnLeftPressed;
            _moveLeftButton.Up += OnPointerUp;

            _shootButton.onClick.AddListener(OnShootButtonClicked);
        }
        private void OnDisable()
        {
            _moveRightButton.Down -= OnRightPressed;
            _moveRightButton.Up -= OnPointerUp;
            _moveLeftButton.Down -= OnLeftPressed;
            _moveLeftButton.Up -= OnPointerUp;

            _shootButton.onClick.RemoveListener(OnShootButtonClicked);
        }

        private void OnRightPressed()
        {
            _input.Horizontal = 1;
        }
        private void OnLeftPressed()
        {
            _input.Horizontal = -1;
        }
        private void OnPointerUp()
        {
            _input.Horizontal = 0;
        }
        private void OnShootButtonClicked()
        {
            _input.InvokeShotPressed();
        }


    }
}
