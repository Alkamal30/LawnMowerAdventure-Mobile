using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Win Settings", menuName = "Create New Win Settings", order = 0)]
    public sealed class WinSettings : ScriptableObject
    {
        public Collider winCollider;
        public bool isCompletionOfTheLevel = false;
    }
}