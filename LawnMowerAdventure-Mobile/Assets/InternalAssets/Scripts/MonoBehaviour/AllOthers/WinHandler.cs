using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public class WinHandler : MonoBehaviour
    {
        private SceneConfiguration sceneConfiguration;

        private void Awake()
        {
            if (sceneConfiguration == null)
                sceneConfiguration = GameObject.FindObjectOfType<SceneConfiguration>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Helper.Tag.Player)) return;

            sceneConfiguration.isCompletionOfTheLevel = true;

            Debug.Log(sceneConfiguration.isCompletionOfTheLevel);
        }
    }
}
