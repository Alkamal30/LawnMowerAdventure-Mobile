using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class SpawnWinCollider : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InitialGrassAmountComponent> initialGrassAmountFilter;
        private readonly SceneConfiguration sceneConfig;

        private int initialGrassAmount;

        public void Init()
        {
            foreach (var i in initialGrassAmountFilter)
            {
                ref var currentGrassAmount = ref initialGrassAmountFilter.Get1(i);

                initialGrassAmount = currentGrassAmount.InitialGrassAmount;
            }
        }

        public void Run()
        {
            foreach (var i in initialGrassAmountFilter)
            {
                ref var currentGrassAmount = ref initialGrassAmountFilter.Get1(i);

                // 50% passing the level.
                if (currentGrassAmount.InitialGrassAmount == (initialGrassAmount / 2) || currentGrassAmount.InitialGrassAmount == (initialGrassAmount / 2) + Random.Range(1, 10))
                {
                    sceneConfig.winCollider.enabled = true;

                    UnityEngine.Debug.Log("Is active collider!");
                }
            }
        }


    }
}