using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly SceneConfigurationData sceneConfig;

        public void Init()
        {
            var characterEntity = _world.NewEntity();

            var playerGO = Object.Instantiate(sceneConfig.currentLawnMower[0].prefab, sceneConfig.characterSpawnPoints[0].spawnPoint.position, Quaternion.identity);

            ref var character = ref characterEntity.Get<CharacterComponent>();

            character.characterGO = playerGO;
            character.characterSpeed = sceneConfig.currentLawnMower[0].speed;
        }
    }
}