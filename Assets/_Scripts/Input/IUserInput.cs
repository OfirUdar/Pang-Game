using System;

namespace Game
{
    public interface IUserInput
    {
        public float Horizontal { get; }
        public event Action ShotPressed;

    }
}
