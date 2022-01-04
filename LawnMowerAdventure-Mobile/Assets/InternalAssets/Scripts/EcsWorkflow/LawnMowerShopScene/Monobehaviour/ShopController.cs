using UnityEngine;
using Helper;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class ShopController : MonoBehaviour
    {
        public void BuyLawnMower_0()
        {
            PlayerPrefs.SetString(PPTag.LawnMower_0, PPTag.True);

            PlayerPrefs.SetString(PPTag.LawnMower_1, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_2, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_3, PPTag.False);
        }

        public void BuyLawnMower_1()
        {
            PlayerPrefs.SetString(PPTag.LawnMower_1, PPTag.True);

            PlayerPrefs.SetString(PPTag.LawnMower_0, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_2, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_3, PPTag.False);
        }

        public void BuyLawnMower_2()
        {
            PlayerPrefs.SetString(PPTag.LawnMower_2, PPTag.True);

            PlayerPrefs.SetString(PPTag.LawnMower_0, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_1, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_3, PPTag.False);
        }

        public void BuyLawnMower_3()
        {
            PlayerPrefs.SetString(PPTag.LawnMower_3, PPTag.True);

            PlayerPrefs.SetString(PPTag.LawnMower_0, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_1, PPTag.False);
            PlayerPrefs.SetString(PPTag.LawnMower_2, PPTag.False);
        }
    }
}