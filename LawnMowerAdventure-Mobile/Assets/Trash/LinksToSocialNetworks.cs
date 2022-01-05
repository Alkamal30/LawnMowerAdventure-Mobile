using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class LinksToSocialNetworks : MonoBehaviour
    {
        public void OpenUrl(string url) => Application.OpenURL($@"{url}");
    }
}