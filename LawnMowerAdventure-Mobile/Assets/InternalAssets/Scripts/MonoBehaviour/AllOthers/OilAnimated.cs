using System.Collections;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class OilAnimated : MonoBehaviour
    {
        [SerializeField] private GameObject oilPrefab;
        [SerializeField] private float secondsDrop = 1.5f;

        private void Start() => StartCoroutine(nameof(OilDrop));

        private IEnumerator OilDrop()
        {
            while (true)
            {
                Instantiate(oilPrefab, transform.position, Quaternion.identity);

                yield return new WaitForSeconds(secondsDrop);
            }
        }
    }
}