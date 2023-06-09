using UnityEngine;
using Zenject;

namespace Game.Player
{
    public class Movement : ITickable, IFixedTickable
    {
        private readonly IUserInput _userInput;
        private readonly MovementData _movementData;
        private readonly Rigidbody2D _rigidbody;

        private Vector2 _horizontalInput;
        public Movement(IUserInput userInput, MovementData movementData, Rigidbody2D rigidbody)
        {
            _userInput = userInput;
            _movementData = movementData;
            _rigidbody = rigidbody;
        }

        public void Tick()
        {
            _horizontalInput = new Vector2(_userInput.Horizontal, 0) * _movementData.Speed;
        }


        public void FixedTick()
        {
            _rigidbody.position += _horizontalInput * Time.fixedDeltaTime;
        }
    }
}
