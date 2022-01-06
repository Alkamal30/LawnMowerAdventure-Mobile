using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class DataInitializationSystem : IEcsPreInitSystem
    {
        private readonly SceneConfigurationData sceneConfig;

        public void PreInit() => VictoryColliderBlock();

        public void VictoryColliderBlock()
        {
            sceneConfig.winSettings[0].winCollider.GetComponent<UnityEngine.BoxCollider>().enabled = false;

            if (sceneConfig.winSettings[0].winCollider.GetComponent<UnityEngine.BoxCollider>().enabled == true)
                sceneConfig.winSettings[0].winCollider.GetComponent<UnityEngine.BoxCollider>().enabled = false;
            else
                Debug.Log("Error");
        }
    }
}