using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class GrassDestroyHandler : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CharacterComponent> _characterFilter = null;
        private readonly EcsFilter<InitialGrassAmountComponent> _grassAmountFilter = null;
        private readonly SceneConfiguration _sceneConfiguration;

        private int _spawnedCoinsAmount;

        public void Init()
        {
            _spawnedCoinsAmount = -1;

            foreach (int index in _characterFilter)
            {
                ref var character = ref _characterFilter.Get1(index);
                GrassDestroyer characterGrassDestroyer = character.GameObject.GetComponent<GrassDestroyer>();

                // TODO: Отписка от события.
                characterGrassDestroyer.OnGrassDestroyedDelegate += OnGrassDestroyed;
            }
        }

        private void OnGrassDestroyed(Vector3 position)
        {
            ReduceGrassCounter();

            CheckAndCreateCoinSpawnEvent(position);
        }

        private void ReduceGrassCounter()
        {
            ref var grassAmountComponent = ref _grassAmountFilter.Get1(0);

            grassAmountComponent.CurrentGrassAmount--;
        }

        private void CheckAndCreateCoinSpawnEvent(Vector3 position)
        {
            ref var grassAmountComponent = ref _grassAmountFilter.Get1(0);

            // 50%    = initial   current  initial 100
            // result = (200   -  100)  \  200 *   100 
            float grassCutPercentage = (float)(grassAmountComponent.InitialGrassAmount - grassAmountComponent.CurrentGrassAmount) /
                                               grassAmountComponent.InitialGrassAmount * 100f;

            if (grassCutPercentage < _sceneConfiguration.lowerBoundOfCoinSpawn) return;

            grassCutPercentage -= _sceneConfiguration.lowerBoundOfCoinSpawn;

            int coinAmount = (int)(grassCutPercentage / _sceneConfiguration.coinSpawnRate);
            coinAmount -= _spawnedCoinsAmount;

            for (int i = 0; i < coinAmount; i++)
            {
                CreateCoinSpawnEvent(position);

                _spawnedCoinsAmount++;
            }
        }

        private void CreateCoinSpawnEvent(Vector3 position)
        {
            var grassEntity = _world.NewEntity();

            ref var coinSpawnEvent = ref grassEntity.Get<CoinSpawnEvent>();

            coinSpawnEvent.SpawnPoint = position;
        }
    }
}