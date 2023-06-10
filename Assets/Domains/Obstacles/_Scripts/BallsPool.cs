using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Obstcale
{
    public class BallsPool : IBallsSpawner
    {
        private readonly Dictionary<int, List<GameObject>> _instancesPool
            = new Dictionary<int, List<GameObject>>();

        private readonly DiContainer _container;

        public event Action Despawned;

        public BallsPool(DiContainer container)
        {
            _container = container;
        }

        public GameObject Spawn(GameObject pfb, Vector3 position)
        {
            int pfbID = pfb.GetInstanceID();
            if (_instancesPool.ContainsKey(pfbID))
            {
                foreach (var instance in _instancesPool[pfbID])
                {
                    if (!instance.activeSelf)
                    {
                        instance.transform.position = position;
                        instance.SetActive(true);
                        return instance;
                    }
                }
                var newInstance = Create(pfb);
                newInstance.transform.position = position;
                _instancesPool[pfbID].Add(newInstance);
                return newInstance;
            }

            var newFinallyInstance = Create(pfb);
            newFinallyInstance.transform.position = position;
            _instancesPool.Add(pfbID, new List<GameObject>() { newFinallyInstance });

            return newFinallyInstance;
        }
        public void Despawn(GameObject instance)
        {
            instance.SetActive(false);
            Despawned?.Invoke();
        }

        private GameObject Create(GameObject pfb)
        {
            var context = _container.InstantiatePrefabForComponent<GameObjectContext>(pfb);
            return context.gameObject;
        }
    }
}