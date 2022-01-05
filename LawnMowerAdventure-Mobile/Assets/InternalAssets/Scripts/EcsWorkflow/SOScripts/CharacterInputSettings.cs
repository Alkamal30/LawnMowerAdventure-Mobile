using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CreateAssetMenu(fileName = "New Character Input Settings", menuName = "Create New Character Input Settings", order = 0)]
    public sealed class CharacterInputSettings : ScriptableObject
    {
        public float rotateTo = 0f;
    }
}