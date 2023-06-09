using System;
using UnityEngine;

namespace Game.Obstcale
{
    [CreateAssetMenu(fileName = "Ball", menuName = "Game/Obstcales/New Ball", order = 0)]
    public class BallDataSO : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }

        [Tooltip("Emit children when destroyed")]
        [field: SerializeField] public EmitChild[] Children { get; private set; }

    }
    [Serializable]
    public class EmitChild
    {
        [field: SerializeField] public int Amount { get; private set; }
        [field: SerializeField] public BallDataSO Child { get; private set; }
    }

}
