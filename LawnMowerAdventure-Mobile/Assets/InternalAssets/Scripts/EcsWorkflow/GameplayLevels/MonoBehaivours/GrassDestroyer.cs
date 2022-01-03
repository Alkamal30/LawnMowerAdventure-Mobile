using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class GrassDestroyer : MonoBehaviour
    {
        public delegate void Delegate(Vector3 grassPosition);

        public Delegate OnGrassDestroyedDelegate;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(Helper.Tag.Grass) == false) return;

            Vector3 grassPosition = other.gameObject.transform.position;

            Destroy(other.gameObject);

            OnGrassDestroyedDelegate.Invoke(grassPosition);
        }
    }
}