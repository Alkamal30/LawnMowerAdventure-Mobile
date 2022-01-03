using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class EcsForGameLevels : MonoBehaviour
    {
        public SceneConfiguration sceneConfiguration;
        public SceneUIConfiguretion uIConfiguretion;
        public DoTweenUIController doTweenUIController;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            if (sceneConfiguration == null)
                sceneConfiguration = FindObjectOfType<SceneConfiguration>();

            if (uIConfiguretion == null)
                uIConfiguretion = FindObjectOfType<SceneUIConfiguretion>();

            if (doTweenUIController == null)
                doTweenUIController = FindObjectOfType<DoTweenUIController>();
        }

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            {
#if UNITY_EDITOR
                Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
                Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            }

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

        private void AddOneFrame() { }

        private void AddSystems()
        {
            _systems
                .Add(new PlayerInitSystem())
                .Add(new LawnMowerSwingInitSystem())

                // .Add(new DestructionOfInactiveGrass())

                .Add(new GrassArrayInitSystem())
                .Add(new GrassHandlerSystem())

                .Add(new EndlessMovementForwardSystem())
                .Add(new CharacterFollowSystem())
                .Add(new StarHandlerSystem())

                .Add(new GrassDestroyHandler())
                .Add(new CoinsSpawnSystem())

                .Add(new SpawnWinCollider())

                .Add(new CompletionOfTheLevel())
                ;

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("Level_6"))
                _systems.Add(new FallingLog());

        }

        private void AddInjections()
        {
            _systems
                .Inject(sceneConfiguration)
                .Inject(uIConfiguretion)
                ;

            // Temperary solution
            if (doTweenUIController != null)
                _systems.Inject(doTweenUIController);
        }
    }
}