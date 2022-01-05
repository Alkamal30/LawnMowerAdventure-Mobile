using System.Collections.Generic;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class CoinGenerator : MonoBehaviour
    {
        [SerializeField] private StarController starController;

        [SerializeField] private int initialGrassAmount;

        private void Awake()
        {
            starController = GetComponent<StarController>();
        }

        private void Start()
        {
            initialGrassAmount = starController.initialGrassAmount;
        }

        private void Update()
        {
            if (starController.currentGrassCount == (initialGrassAmount / 2))
            {
                Debug.Log("1");
            }

            if (starController.currentGrassCount == (initialGrassAmount / 4))
            {
                Debug.Log("2");
            }

            if (starController.currentGrassCount == (initialGrassAmount / 6))
            {
                Debug.Log("3");
            }

            if (starController.currentGrassCount == (initialGrassAmount / 8))
            {
                Debug.Log("4");
            }

            if (starController.currentGrassCount == (initialGrassAmount / 10))
            {
                Debug.Log("5");
            }
        }
    }
}