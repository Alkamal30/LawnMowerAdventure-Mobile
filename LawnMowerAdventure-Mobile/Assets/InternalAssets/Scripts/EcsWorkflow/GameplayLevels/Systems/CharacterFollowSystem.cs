using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal class CharacterFollowSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _worlad = null;
        private readonly EcsFilter<CharacterComponent> characterFilter = null;

        private readonly SceneConfigurationData sceneConfig;
        private EcsEntity cameraEntity;

        public void Init()
        {
            var cameraEntity = _worlad.NewEntity();

            ref var cameraComponent = ref cameraEntity.Get<CharacterTrackingCameraComponent>();

            cameraComponent.cameraTransform = Camera.main.transform;
            cameraComponent.cameraSmoothness = sceneConfig.cameraConfig[0].cameraSmoothness;
            cameraComponent.currentVelocity = Vector3.zero;
            cameraComponent.offset = sceneConfig.cameraConfig[0].offset;

            this.cameraEntity = cameraEntity;
        }

        public void Run()
        {
            if (!cameraEntity.IsAlive()) return;

            ref var cameraComponent = ref cameraEntity.Get<CharacterTrackingCameraComponent>();

            foreach (var i in characterFilter)
            {
                ref var playerComponent = ref characterFilter.Get1(i);

                var currentPosition = cameraComponent.cameraTransform.position;

                if (playerComponent.characterGO == null)
                {
                    Debug.Log("The player's object reference has gone off or the player has lost.");

                    return;
                }

                var targetPoint = playerComponent.characterGO.transform.position + cameraComponent.offset;

                cameraComponent.cameraTransform.position =
                    Vector3.SmoothDamp
                    (
                        currentPosition,
                        targetPoint,
                        ref cameraComponent.currentVelocity,
                        cameraComponent.cameraSmoothness
                    );
            }
        }
    }
}