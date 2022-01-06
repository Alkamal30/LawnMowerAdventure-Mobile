using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New/Character Spawn Point", menuName = "CreateGameData/Character Spawn Point", order = 0)]
    public sealed class CharacterSpawnPoint : ScriptableObject
    {
        public Transform spawnPoint = default;
    }
}