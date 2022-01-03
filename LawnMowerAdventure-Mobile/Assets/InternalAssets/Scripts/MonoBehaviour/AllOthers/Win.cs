using AbyssMothGames.LawnMowerWorld.Levels;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class Win : MonoBehaviour
    {
        //[SerializeField] private StarController starController;
        [SerializeField] private OnClickByButton clickByButton;

        private void Start()
        {
            //  starController = FindObjectOfType<StarController>();
            clickByButton = FindObjectOfType<OnClickByButton>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(Helper.Tag.Player))
            {
                clickByButton.OnClickButtonWinScene();
                //for (int i = 0; i < StarController.Instance.isStar.Length; i++)
                  // StarController.Instance.isStar[i] = false;

                // TODO: Added win animation;
                //if (StarController.Instance.FirstStar() || StarController.Instance.SecondStar() || StarController.Instance.ThreeStar() == true)
            }
        }
    }
}