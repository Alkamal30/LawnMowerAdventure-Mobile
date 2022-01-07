using Leopotam.Ecs;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class CompletionOfTheLevel : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InitialGrassAmountComponent> currentProgressFilter = null;
        private readonly EcsFilter<CharacterComponent> characterFilter = null;

        private readonly SceneConfiguration sceneConfig;
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
            if (sceneConfig.isCompletionOfTheLevel)
            {

                foreach (var i in characterFilter)
                {
                    ref var character = ref characterFilter.Get1(i);

                    character.MovementSpeed = 0;

                    doTweenUIController.OpenWinPopupPanels();
                }
            }
        }
    }
}