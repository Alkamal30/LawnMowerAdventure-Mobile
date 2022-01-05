using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

namespace AbyssMothGames.LawnMowerWorld
{
    [RequireComponent(typeof(LoadingLawnMowerModel))]
    public sealed class SceneConfiguration : MonoBehaviour
    {
        public LoadingLawnMowerModel loadingLawnMowerModel;

        [Space]
        [Header("Lawn Mower")]
        public GameObject characterPrefab = default;
        public float characterSpeed = default;
        public CharacterContainer characterContainer;

        [Space]
        [Header("Camera")]
        public Vector3 currentVelocity = default;
        public Vector3 offset = default;
        public float cameraSmoothness = default;

        [Space]
        [Header("Input")]
        public float rotateTo = 0f;

        [Space]
        [Header("Level")]
        public Transform spawnPoint = default;
        [Range(0f, 100f)]
        public float lowerBoundOfCoinSpawn;
        [Range(0f, 20f)]
        public float coinSpawnRate;

        //[Space]
        //[Header("Runtime")]
        //public int grassCount = default;

        [Space]
        [Header("For Star System")]
        public bool isFirstStar = false;
        [FormerlySerializedAs("isSecondtStar")] public bool isSecondStar = false;
        public bool isThreeStar = false;

        [Space]
        [Header("For WoodLog_Trap")]
        public GameObject fallingLogPrefab = default;
        public float startPositionY = 2.12f;
        public float liftingIndent = 1f;
        public bool isLiftingIndent = true;

        [Space]
        [Header("Win settings")]
        public Collider winCollider;
        public bool isCompletionOfTheLevel = false;
        [Space]

        [Header("Currency")]
        public GameObject Coin;
        public float coinAddForce = 15f;

        private void Awake()
        {
            loadingLawnMowerModel = GetComponent<LoadingLawnMowerModel>();

            loadingLawnMowerModel.CheckingTheCurrentLawnMowerModel(ref characterContainer, out characterPrefab);
        }
    }
}