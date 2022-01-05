using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Camera Configurations", menuName = "Create New Camera Configurations", order = 0)]
    public sealed class CameraConfigurations : ScriptableObject
    {
        public Vector3 currentVelocity = default;   // Default setting (0, 0, 0)
        public Vector3 offset = default;            // Default setting (2.5, 4.5, -3)
        public float cameraSmoothness = default;    // Default setting (0.05)
    }
}