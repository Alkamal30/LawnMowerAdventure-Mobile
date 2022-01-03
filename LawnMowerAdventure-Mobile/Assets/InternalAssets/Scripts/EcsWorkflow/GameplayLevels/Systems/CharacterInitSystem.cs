using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class PlayerInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly SceneConfiguration sceneConfiguration;

        public void Init()
        {
            var characterEntity = _world.NewEntity();

            var playerGO = Object.Instantiate(sceneConfiguration.characterPrefab, sceneConfiguration.spawnPoint.position, Quaternion.identity);
           // var playerGO = Object.Instantiate(sceneConfiguration.characterContainer.lawmMowers., sceneConfiguration.spawnPoint.position, Quaternion.identity);

            ref var character = ref characterEntity.Get<CharacterComponent>();

            character.characterGO = playerGO;
            character.characterSpeed = sceneConfiguration.characterSpeed;
        }
    }
}