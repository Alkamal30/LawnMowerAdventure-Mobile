using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Currency ", menuName = "Create New Currency ", order = 0)]
    public sealed class Currency : ScriptableObject
    {
        public GameObject Coin;
        public float coinAddForce = 15f;
    }
}