using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    /// <summary>
    /// Панель для сброса звёзд пройденных уровней.
    /// </summary>
    public sealed class DevMode : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        public void OpenDevPanel() => panel.SetActive(!panel.activeSelf);

        public void StarReset()
        {
            for (int i = 0; i < StarData.Instance.stateStarLevel.Length; i++)
                StarData.Instance.stateStarLevel[i] = 0;

            int index = 1;

            for (int i = 0; i < StarData.Instance.stateStarLevel.Length; i++)
                PlayerPrefs.SetInt($"Level_{index++}", 0);
        }
    }
}