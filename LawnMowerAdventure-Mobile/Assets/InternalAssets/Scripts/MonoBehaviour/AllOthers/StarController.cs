using UnityEngine;
using UnityEngine.SceneManagement;

namespace AbyssMothGames.LawnMowerWorld
{
    // Система перенесена, этот класс можно удалить.
    //
    //
    //
    //
    //\\////\\\///\//\//\/////\


    public sealed class StarController : MonoBehaviour
    {
        public static StarController Instance; // Убрать инстанс.
        public Events.CurrentGrassCount OnCurrentGrassCount;

        // Инкапсулировать данные.
       // public GrassArray grassArray;

        public int currentGrassCount = 0;
        public int initialGrassAmount = 0;

        public string sceneName;

        public bool[] isStar;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

           // if (grassArray == null)
             //   grassArray = GetComponent<GrassArray>();

            OnCurrentGrassCount += CalculationCurrentGrassCount;
        }
        // Исправить 1 Цель - изменять кол-во травы через событие.
   public int CalculationCurrentGrassCount(int count) => currentGrassCount += count;     

        private void Start()
        {
          //  initialGrassAmount = grassArray.grassArray.Length;
            currentGrassCount = initialGrassAmount;

            sceneName = SceneManager.GetActiveScene().name;

            isStar = new bool[3];
        }

        private void Update()
        {
            if (currentGrassCount <= (initialGrassAmount / 2))
            {
                if (isStar[0] == true) return;
                if (PlayerPrefs.GetInt(sceneName, 1) == 1) return;

                SetStarForLevel(sceneName, 1);

                PlayerPrefs.SetInt(sceneName, 1);

                isStar[0] = true;
            }

            if (currentGrassCount <= (initialGrassAmount / 3))
            {
                if (isStar[1] == true) return;
                if (PlayerPrefs.GetInt(sceneName, 1) == 2) return;

                SetStarForLevel(sceneName, 2);

                PlayerPrefs.SetInt(sceneName, 2);

                isStar[1] = true;
            }

            if (currentGrassCount == 0)
            {
                if (isStar[2] == true) return;
                if (PlayerPrefs.GetInt(sceneName, 1) == 3) return;

                SetStarForLevel(sceneName, 3);

                PlayerPrefs.SetInt(sceneName, 3);

                isStar[2] = true;

                // Отписка от события.
                OnCurrentGrassCount -= CalculationCurrentGrassCount;
            }
        }

        public void SetStarForLevel(string sceneName, int star)
        {
            int index = 1;

            for (int i = 0; i < 24; i++)
                if (sceneName == $"Level_{index++}")
                    StarData.Instance.stateStarLevel[i] = star;
        }
    }
}