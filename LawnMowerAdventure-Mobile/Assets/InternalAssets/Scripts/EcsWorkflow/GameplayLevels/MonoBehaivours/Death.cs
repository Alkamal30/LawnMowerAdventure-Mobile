using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class Death : MonoBehaviour
    {
        private SceneConfigurationData sceneConfig;
        private DoTweenUIController doTweenUIController;

        private void Awake()
        {
            if (doTweenUIController == null)
                doTweenUIController = GameObject.FindObjectOfType<DoTweenUIController>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Helper.Tag.Player))
            {
                var player = GameObject.FindGameObjectWithTag(Helper.Tag.Player);

                doTweenUIController.OpenLoserPopupPanels();

                // sceneConfig.winSettings[0].isCompletionOfTheLevel = false;
                // sceneConfig.winSettings[0].winCollider.enabled = false;

                Destroy(player);
                //IJunior.TypedScenes.DeathScene.Load();
            }
        }
    }
}