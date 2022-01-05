using UnityEngine;
using UnityEngine.UI;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class StarData : MonoBehaviour
    {
        public static StarData Instance;
        [Space]

        // TODO: Реализовать ступенчатый массив.
        public GameObject[] starsLevel_1;
        public GameObject[] starsLevel_2;
        public GameObject[] starsLevel_3;
        public GameObject[] starsLevel_4;
        public GameObject[] starsLevel_5;
        public GameObject[] starsLevel_6;
        public GameObject[] starsLevel_7;
        public GameObject[] starsLevel_8;
        public GameObject[] starsLevel_9;
        public GameObject[] starsLevel_10;
        public GameObject[] starsLevel_11;
        public GameObject[] starsLevel_12;
        public GameObject[] starsLevel_13;
        public GameObject[] starsLevel_14;
        public GameObject[] starsLevel_15;
        public GameObject[] starsLevel_16;
        public GameObject[] starsLevel_17;
        public GameObject[] starsLevel_18;
        public GameObject[] starsLevel_19;
        public GameObject[] starsLevel_20;
        public GameObject[] starsLevel_21;
        public GameObject[] starsLevel_22;
        public GameObject[] starsLevel_23;
        public GameObject[] starsLevel_24;
        public GameObject[] starsLevel_25;

        [Space]
        public int[] stateStarLevel;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

            stateStarLevel = new int[25];

            LoadStarIndex();
        }

        private void Start()
        {
            LoadStarIndex();

            // TODO: Убрать это убожество.
            SetColorSpriteStars(ref starsLevel_1, 0);
            SetColorSpriteStars(ref starsLevel_2, 1);
            SetColorSpriteStars(ref starsLevel_3, 2);
            SetColorSpriteStars(ref starsLevel_4, 3);
            SetColorSpriteStars(ref starsLevel_5, 4);
            SetColorSpriteStars(ref starsLevel_6, 5);
            SetColorSpriteStars(ref starsLevel_7, 6);
            SetColorSpriteStars(ref starsLevel_8, 7);
            SetColorSpriteStars(ref starsLevel_9, 8);
            SetColorSpriteStars(ref starsLevel_10, 9);
            SetColorSpriteStars(ref starsLevel_11, 10);
            SetColorSpriteStars(ref starsLevel_12, 11);
            SetColorSpriteStars(ref starsLevel_13, 12);
            SetColorSpriteStars(ref starsLevel_14, 13);
            SetColorSpriteStars(ref starsLevel_15, 14);
            SetColorSpriteStars(ref starsLevel_16, 15);
            SetColorSpriteStars(ref starsLevel_17, 16);
            SetColorSpriteStars(ref starsLevel_18, 17);
            SetColorSpriteStars(ref starsLevel_19, 18);
            SetColorSpriteStars(ref starsLevel_20, 19);
            SetColorSpriteStars(ref starsLevel_21, 20);
            SetColorSpriteStars(ref starsLevel_22, 21);
            SetColorSpriteStars(ref starsLevel_23, 22);
            SetColorSpriteStars(ref starsLevel_24, 23);
            SetColorSpriteStars(ref starsLevel_25, 24);
        }

        public void SetColorSpriteStars(ref GameObject[] level, int index)
        {
            if (stateStarLevel[index] == 1)
            {
                level[0].GetComponent<Image>().color = Color.white;
            }

            if (stateStarLevel[index] == 2)
            {
                level[0].GetComponent<Image>().color = Color.white;
                level[1].GetComponent<Image>().color = Color.white;
            }

            if (stateStarLevel[index] == 3)
            {
                level[0].GetComponent<Image>().color = Color.white;
                level[1].GetComponent<Image>().color = Color.white;
                level[2].GetComponent<Image>().color = Color.white;
            }
        }

        public void LoadStarIndex()
        {
            int index = 1;

            for (int i = 0; i < stateStarLevel.Length; i++)
            {
                stateStarLevel[i] = PlayerPrefs.GetInt($"Level_{index++}");
            }
        }
    }
}