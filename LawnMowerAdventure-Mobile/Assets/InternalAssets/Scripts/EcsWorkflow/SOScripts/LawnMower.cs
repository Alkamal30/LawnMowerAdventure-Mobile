using UnityEditor;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Lawn Mower", menuName = "CreateGameData/Lawn Mower", order = 0)]
    public sealed class LawnMower : ScriptableObject
    {
        public new string name;
        public GameObject prefab;
        [Space]
        public float speed;
        public int price;

    }
}
