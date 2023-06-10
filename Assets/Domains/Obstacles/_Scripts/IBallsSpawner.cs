using System;
using UnityEngine;

namespace Game.Obstcale
{
    public interface IBallsSpawner
    {
        public GameObject Spawn(GameObject pfb, Vector3 position);
        public void Despawn(GameObject instance);

        public event Action Despawned;
    }
}