using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class EcsLawnMowerShop : MonoBehaviour
    {
        public ShopController shopController;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            if (shopController == null)
                shopController = GameObject.FindObjectOfType<ShopController>();
        }

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems.ConvertScene();

            AddInjections();
            AddSystems();
            AddOneFrame();

            _systems.Init();
        }

        private void Update() => _systems?.Run();

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;

                _world.Destroy();
                _world = null;
            }
        }

        private void AddOneFrame()
        {

        }

        private void AddSystems()
        {

        }

        private void AddInjections()
        {

        }
    }
}