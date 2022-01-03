using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "Lawn Mower_", menuName = "Create Lawn Mower Model", order = 0)]
    public class CharacterContainer : ScriptableObject
    {
        public List<LawmMowers> lawmMowers;
    }

    [System.Serializable]
    public class LawmMowers
    {
        public GameObject prefab;
    }
}