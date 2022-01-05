using DG.Tweening;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public enum PopupState { WIN, LOSER }

    public sealed class DoTweenUIController : MonoBehaviour
    {
        [SerializeField] private RectTransform winPopupPanel;
        [SerializeField] private RectTransform loserPopupPanel;
        [Space]
        [SerializeField] private float duration = 0.25f;

        private void Awake()
        {
            if (winPopupPanel == null)
                winPopupPanel = GameObject.FindGameObjectWithTag(Helper.Tag.WinPanel).GetComponent<RectTransform>();

            if (loserPopupPanel == null)
                loserPopupPanel = GameObject.FindGameObjectWithTag(Helper.Tag.LoserPanel).GetComponent<RectTransform>();
        }

        public void OpenPopupPanel(PopupState popupState)
        {
            switch (popupState)
            {
                case PopupState.WIN:
                    {
                        winPopupPanel.DOAnchorPos(new Vector2(-1650, 0), duration);
                    }
                    break;
                case PopupState.LOSER:
                    {
                        loserPopupPanel.DOAnchorPos(new Vector2(1650, 0), duration);
                    }
                    break;
            }
        }

        public void ClosePopupPanel(PopupState popupState)
        {
            switch (popupState)
            {
                case PopupState.WIN:
                    {
                        winPopupPanel.DOAnchorPos(new Vector2(0, -1650), duration);
                    }
                    break;
                case PopupState.LOSER:
                    {
                        loserPopupPanel.DOAnchorPos(new Vector2(0, 1650), duration);
                    }
                    break;
            }
        }

        public void OpenWinPopupPanels()
        {
            winPopupPanel.DOAnchorPos(new Vector2(0, 0), duration);     // open
            loserPopupPanel.DOAnchorPos(new Vector2(1650, 0), duration);// close
        }

        public void OpenLoserPopupPanels()
        {
            winPopupPanel.DOAnchorPos(new Vector2(-1650, 0), 0.025f); // close
            loserPopupPanel.DOAnchorPos(new Vector2(0, 0), 0.025f);   // open
        }

        public void CloseAll()
        {
            winPopupPanel.DOAnchorPos(new Vector2(-1650, 0), duration); // close
            loserPopupPanel.DOAnchorPos(new Vector2(1650, 0), duration);// close
        }

        public void OpenAll()
        {
            winPopupPanel.DOAnchorPos(new Vector2(0, 0), duration);  // open
            loserPopupPanel.DOAnchorPos(new Vector2(0, 0), duration);// open
        }
    }
}