using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Coin Spawn Settings", menuName = "Create New Coin Spawn Settings", order = 0)]
    public sealed class CoinSpawnSettings : ScriptableObject
    {
        [Range(0f, 100f)]
        public float lowerBoundOfCoinSpawn;
        [Range(0f, 20f)]
        public float coinSpawnRate;
    }
}