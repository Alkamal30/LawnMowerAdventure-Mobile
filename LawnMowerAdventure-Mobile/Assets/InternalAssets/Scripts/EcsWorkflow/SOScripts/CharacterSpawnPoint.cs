using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Character Spawn Point", menuName = "Create New Character Spawn Point", order = 0)]
    public sealed class CharacterSpawnPoint : ScriptableObject
    {
        public Transform spawnPoint = default;
    }
}