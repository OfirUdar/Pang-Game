using System;
using UnityEngine;
using Zenject;

namespace Game
{
    public class PCInput : IUserInput, ITickable
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public event Action ShotPressed;

        public void Tick()
        {
            var horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
                ShotPressed?.Invoke();
        }
    }
}
