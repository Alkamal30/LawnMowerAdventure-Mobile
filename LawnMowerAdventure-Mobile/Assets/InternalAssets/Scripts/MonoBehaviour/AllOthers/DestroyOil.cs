using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class DestroyOil : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Helper.Tag.Oil))
                Destroy(collision.gameObject);
        }
    }
}