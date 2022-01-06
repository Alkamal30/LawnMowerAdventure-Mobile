using Leopotam.Ecs;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class DataInitializationSystem : IEcsPreInitSystem
    {
        private readonly SceneConfigurationData sceneConfig;

        public void PreInit() => VictoryColliderBlock();

        public void VictoryColliderBlock()
        {
            sceneConfig.winSettings[0].isCompletionOfTheLevel = false;
            sceneConfig.winSettings[0].winCollider.enabled = false;
        }
    }
}