using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class Death : MonoBehaviour
    {
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
                doTweenUIController.OpenLoserPopupPanels();

                Destroy(GameObject.FindGameObjectWithTag(Helper.Tag.Player));
                //IJunior.TypedScenes.DeathScene.Load();
            }
        }
    }
}