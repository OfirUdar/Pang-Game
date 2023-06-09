using System;
using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallBounceDirection : IInitializable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Vector2 _startForce;

        public BallBounceDirection(Rigidbody2D rigidbody, Vector2 startForce)
        {
            _rigidbody = rigidbody;
            _startForce = startForce;
        }

        public void Initialize()
        {
            _rigidbody.AddForce(_startForce, ForceMode2D.Impulse);
        }

    }

}
