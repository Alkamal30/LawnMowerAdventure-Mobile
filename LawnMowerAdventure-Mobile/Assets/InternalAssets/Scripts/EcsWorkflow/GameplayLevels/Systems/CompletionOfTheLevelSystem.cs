using Leopotam.Ecs;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class CompletionOfTheLevelSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InitialGrassAmountComponent> currentProgressFilter = null;
        private readonly EcsFilter<CharacterComponent> characterFilter = null;

        private readonly SceneConfigurationData sceneConfig;
        private readonly DoTweenUIController doTweenUIController;

        public void Init()
        {
            foreach (var i in currentProgressFilter)
            {
                ref var initialGrassAmount = ref currentProgressFilter.Get1(i);
            }
        }

        public void Run()
        {
            if (sceneConfig.winSettings[0].isCompletionOfTheLevel)
            {

                foreach (var i in characterFilter)
                {
                    ref var character = ref characterFilter.Get1(i);

                    character.characterSpeed = 0;

                    sceneConfig.winSettings[0].isCompletionOfTheLevel = false;
                    sceneConfig.winSettings[0].winCollider.enabled = false;

                    doTweenUIController.OpenWinPopupPanels();
                }
            }
        }
    }
}