using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public struct CharacterTrackingCameraComponent
    {
        public Transform cameraTransform;
        public Vector3 currentVelocity;
        public Vector3 offset;
        public float cameraSmoothness;
    }
}