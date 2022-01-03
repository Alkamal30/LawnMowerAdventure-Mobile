using UnityEngine;
using Helper;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class LoadingLawnMowerModel : MonoBehaviour
    {
        public void CheckingTheCurrentLawnMowerModel(ref CharacterContainer characterContainer, out GameObject characterPrefab)
        {
            characterPrefab = new GameObject();

            for (int i = 1; i < characterContainer.lawmMowers.Count; i++)
            {
                if (PlayerPrefs.GetString($"{PPTag.LawnMower_}{i}", PPTag.True) == PPTag.True)
                {
                    foreach (var item in characterContainer.lawmMowers)
                    {
                        if (item.prefab.name == $"{PPTag.MainLawnMower_v}{i}")
                        {
                            characterPrefab = item.prefab;
                        }
                    }
                }
            }
        }
    }
}