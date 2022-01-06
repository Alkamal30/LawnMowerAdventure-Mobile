using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New/WinSettings", menuName = "CreateGameData/Win Settings", order = 0)]
    public sealed class WinSettings : ScriptableObject
    {
        public GameObject winCollider;
    }
}