using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class EcsGarageScene : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
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
            _systems.Add(new OrientationSetterSystem());
        }

        private void AddInjections()
        {
        }
    }
}