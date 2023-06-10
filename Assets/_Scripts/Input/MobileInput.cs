using System;

namespace Game
{
    public class MobileInput : IUserInput
    {
        public float Horizontal { get; set; }

        public event Action ShotPressed;

        public void InvokeShotPressed()
        {
            ShotPressed?.Invoke();
        }
    }
}
