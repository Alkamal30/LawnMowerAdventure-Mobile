using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public class WinHandler : MonoBehaviour
    {
        private SceneConfigurationData sceneConfiguration;
        private bool isLock = false;

        private void Awake()
        {
            if (sceneConfiguration == null)
                sceneConfiguration = GameObject.FindObjectOfType<SceneConfigurationData>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Helper.Tag.Player)) return;

            // if (isLock == false)
            // if (sceneConfiguration.winSettings[0].isCompletionOfTheLevel == false)
            sceneConfiguration.winSettings[0].isCompletionOfTheLevel = true;
            // i//sLock = true;
        }
    }
}