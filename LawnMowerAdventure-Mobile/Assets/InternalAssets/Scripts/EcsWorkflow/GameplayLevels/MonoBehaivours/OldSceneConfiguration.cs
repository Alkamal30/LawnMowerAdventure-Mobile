using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;

namespace AbyssMothGames.LawnMowerWorld
{
    [RequireComponent(typeof(LoadingLawnMowerModel))]
    [RequireComponent(typeof(SceneConfigurationData))]
    public sealed class OldSceneConfiguration : MonoBehaviour
    {
        //public LoadingLawnMowerModel loadingLawnMowerModel;

        [Space]
        [Header("Win settings")]
        public Collider winCollider;
        public bool isCompletionOfTheLevel = false;


        //private void Awake()
        //{
        //    loadingLawnMowerModel = GetComponent<LoadingLawnMowerModel>();

        //    loadingLawnMowerModel.CheckingTheCurrentLawnMowerModel(ref characterContainer, out characterPrefab);
        //}
    }
}