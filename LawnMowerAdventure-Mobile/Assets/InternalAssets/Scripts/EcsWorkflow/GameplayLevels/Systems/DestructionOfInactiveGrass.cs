using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class DestructionOfInactiveGrass : IEcsInitSystem
    {
        public void Init()
        {
            var allGrass = GameObject.FindGameObjectsWithTag(Helper.Tag.Grass);

            foreach (var item in allGrass)
            {
                if (item.activeSelf == false)
                    GameObject.Destroy(item);
            }
        }
    }
}