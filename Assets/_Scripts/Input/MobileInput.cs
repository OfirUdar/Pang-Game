using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MobileInput : MonoBehaviour, IUserInput
    {
        [SerializeField] private PointerDownDetecter _moveRightButton;
        [SerializeField] private PointerDownDetecter _moveLeftButton;
        [SerializeField] private Button _shootButton;

        public float Horizontal { get; private set; }
        public event Action ShotPressed;

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
            Horizontal = 1;
        }
        private void OnLeftPressed()
        {
            Horizontal = -1;
        }
        private void OnPointerUp()
        {
            Horizontal = 0;
        }
        private void OnShootButtonClicked()
        {
            ShotPressed?.Invoke();
        }


    }
}
