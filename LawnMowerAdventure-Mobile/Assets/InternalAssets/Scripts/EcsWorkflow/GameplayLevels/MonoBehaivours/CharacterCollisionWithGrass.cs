using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class CharacterCollisionWithGrass : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(Helper.Tag.Player)) return;

            GrassHandlerSystem.OnCurrentGrassCount(-1);

            Destroy(gameObject);
        }
    }
}