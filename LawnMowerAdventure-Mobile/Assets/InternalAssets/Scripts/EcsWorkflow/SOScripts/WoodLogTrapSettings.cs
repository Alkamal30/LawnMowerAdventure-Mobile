using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Wood Log Trap Settings", menuName = "Create Wood Log Trap Settings", order = 0)]
    public sealed class WoodLogTrapSettings : ScriptableObject
    {
        public GameObject fallingLogPrefab = default;
        public float startPositionY = 2.12f;
        public float liftingIndent = 1f;
        public bool isLiftingIndent = true;
    }
}