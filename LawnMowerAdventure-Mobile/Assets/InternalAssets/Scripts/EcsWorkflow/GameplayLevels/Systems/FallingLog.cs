using Leopotam.Ecs;
using UnityEngine;

/*
 TODO: Review -> SceneConfigurationData
 Не, ну это пзц... Надо будет создать контейнеры для хранения полей в классе SceneConfigurationData
 Ну или хотя бы заняться ревью полей и именований, так как это уже говнокод.
 */

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class FallingLog : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<FallingLogComponent> fallingLogFilter = null;

        private readonly SceneUIConfiguretion uiConfiguration;
        private readonly SceneConfigurationData sceneConfiguration;

        private bool isFallingLogstate = default;

        public void Init()
        {
            var fallingLogEntity = _world.NewEntity();

            isFallingLogstate = sceneConfiguration.woodLogTrapSettings[0].isLiftingIndent;

            ref var fallingLogComponent = ref fallingLogEntity.Get<FallingLogComponent>();

            {
                fallingLogComponent.FallingLogGO =   sceneConfiguration.woodLogTrapSettings[0].fallingLogPrefab;
                fallingLogComponent.StartPositionY = sceneConfiguration.woodLogTrapSettings[0].startPositionY;
                fallingLogComponent.LiftingIndent =  sceneConfiguration.woodLogTrapSettings[0].liftingIndent;
            }

            // TODO: Cleare all listeners.
            uiConfiguration.LeftTurnButton.onClick.AddListener(() => FallingLogTrapLifting());
            uiConfiguration.RightTurnButton.onClick.AddListener(() => FallingLogTrapLifting());
        }

        private void FallingLogTrapLifting()
        {
            foreach (var i in fallingLogFilter)
            {
                ref var fallingLogComponent = ref fallingLogFilter.Get1(i);

                ref var fallingLogGO = ref fallingLogComponent.FallingLogGO;
                ref var startPositionY = ref fallingLogComponent.StartPositionY;
                ref var liftingIndent = ref fallingLogComponent.LiftingIndent;

                FallingLogTrap(ref fallingLogGO, ref startPositionY, ref liftingIndent);
            }
        }

        private void FallingLogTrap(ref GameObject fallingLog, ref float startPositionY, ref float liftingIndent)
        {
            if (isFallingLogstate)
            {
                fallingLog.transform.position =
                    new Vector3(fallingLog.transform.position.x, startPositionY + liftingIndent, fallingLog.transform.position.z);

                isFallingLogstate = false;
            }
            else
            {
                fallingLog.transform.position =
                    new Vector3(fallingLog.transform.position.x, startPositionY, fallingLog.transform.position.z);

                isFallingLogstate = true;
            }
        }
    }
}