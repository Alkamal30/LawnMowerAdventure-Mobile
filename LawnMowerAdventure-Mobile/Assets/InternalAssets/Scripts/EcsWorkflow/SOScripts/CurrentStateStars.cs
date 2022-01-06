using UnityEngine;
using UnityEngine.Serialization;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New/Current State Stars", menuName = "CreateGameData/Current State Stars", order = 0)]
    public sealed class CurrentStateStars : ScriptableObject
    {
        public bool isFirstStar = false;
        [FormerlySerializedAs("isSecondtStar")] public bool isSecondStar = false;
        public bool isThreeStar = false;
    }
}