using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class EcsForGameLevels : MonoBehaviour
    {
        public SceneConfigurationData sceneConfigurationData;
        public OldSceneConfiguration oldSceneConfig;
        public SceneUIConfiguretion uIConfiguretion;
        public DoTweenUIController doTweenUIController;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Awake()
        {
            if (sceneConfigurationData == null)
                sceneConfigurationData = FindObjectOfType<SceneConfigurationData>();

            if (oldSceneConfig == null)
                oldSceneConfig = FindObjectOfType<OldSceneConfiguration>();

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
               // .Add(new DataInitializationSystem())

                .Add(new PlayerInitSystem())
                .Add(new LawnMowerSwingInitSystem())

                .Add(new GrassArrayInitSystem())
                .Add(new GrassHandlerSystem())

                .Add(new EndlessMovementForwardSystem())
                .Add(new CharacterFollowSystem())
                .Add(new StarHandlerSystem())

                .Add(new GrassDestroyHandlerSystem())
                .Add(new CoinsSpawnSystem())

                .Add(new SpawnWinColliderSystem())

                .Add(new CompletionOfTheLevelSystem())
                ;

            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name.Equals("Level_6"))
                _systems.Add(new FallingLogSystem());

        }

        private void AddInjections()
        {
            _systems
                .Inject(oldSceneConfig)
                .Inject(sceneConfigurationData)
                .Inject(uIConfiguretion)
                ;

            if (doTweenUIController != null)
                _systems.Inject(doTweenUIController);
        }
    }
}