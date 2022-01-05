using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public class Grass : MonoBehaviour
    {
        private StarController starController;

        private void Awake()
        {
            if (starController == null)
                starController = GameObject.FindGameObjectWithTag(Helper.Tag.GameController).GetComponent<StarController>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Helper.Tag.Player))
            {
                //starController.OnCurrentGrassCount(-1);

                Destroy(gameObject);
            }
        }
    }
}