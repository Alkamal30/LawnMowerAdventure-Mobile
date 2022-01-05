using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class CoinsSpawnSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CoinSpawnEvent> _coinSpawnEventfilter = null;
        private readonly EcsFilter<CoinComponent> _coinFilter = null;
        private readonly SceneConfiguration sceneConfiguration;

        public void Init()
        {
            var coinEcs = _world.NewEntity();

            ref var coin = ref coinEcs.Get<CoinComponent>().Coin;

            coin = sceneConfiguration.Coin;
        }

        public void Run()
        {
            foreach (int index1 in _coinSpawnEventfilter)
            {
                ref var coinSpawnEvent = ref _coinSpawnEventfilter.Get1(index1);

                foreach (var index2 in _coinFilter)
                {

                    ref var coin = ref _coinFilter.Get1(index2);
                    // Spawn Coin Code
                    {
                        var coinInstance = Object.Instantiate(coin.Coin, coinSpawnEvent.SpawnPoint, Quaternion.identity);
                        coinInstance.GetComponent<Rigidbody>().AddForce(Vector3.up * sceneConfiguration.coinAddForce); // * Time.deltaTime
                    }
                }

                ref var entity = ref _coinSpawnEventfilter.GetEntity(index1);

                entity.Destroy();
            }
        }
    }
}