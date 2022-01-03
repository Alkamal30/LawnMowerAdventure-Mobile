using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class StarHandlerSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<InitialGrassAmountComponent> initialAmountGrassFilter = null;

        private int initialGrassAmount = 0;
        private string sceneName;

        public void Init()
        {
            SetSceneName();

            SetInitialAmountGrass();

            CheckingIfPlayerPrefsExists();
        }

        public void Run()
        {
            foreach (var i in initialAmountGrassFilter)
            {
                ref var initialGrassAmountComponent = ref initialAmountGrassFilter.Get1(i);
                ref var currentGrass                = ref initialGrassAmountComponent.InitialGrassAmount;

                if (currentGrass == (initialGrassAmount / 2) || currentGrass == (initialGrassAmount / 2) + Random.Range(1, 10))
                {
                    if ((PlayerPrefs.GetInt(sceneName, 1) == 1) ||
                        (PlayerPrefs.GetInt(sceneName, 2) == 2) ||
                        (PlayerPrefs.GetInt(sceneName, 3) == 3)) return;

                    SetStars(1);
                }

                if (currentGrass == (initialGrassAmount / 3) || currentGrass == (initialGrassAmount / 3) + Random.Range(1, 10))
                {
                    if ((PlayerPrefs.GetInt(sceneName, 2) == 2) ||
                        (PlayerPrefs.GetInt(sceneName, 3) == 3)) return;

                    SetStars(2);
                }

                if (initialGrassAmountComponent.InitialGrassAmount == 0)
                {
                    if (PlayerPrefs.GetInt(sceneName, 3) == 3) return;

                    SetStars(3);
                }
            }
        }

        private void SetSceneName() => sceneName = SceneManager.GetActiveScene().name;

        private void SetInitialAmountGrass()
        {
            foreach (var i in initialAmountGrassFilter)
            {
                ref var initialAmountGrassComponent = ref initialAmountGrassFilter.Get1(i);

                initialGrassAmount = initialAmountGrassComponent.InitialGrassAmount;
            }
        }

        private void CheckingIfPlayerPrefsExists()
        {
            for (int i = 0; i < 3; i++)
            {
                if (PlayerPrefs.GetInt(sceneName, i) == default)
                    PlayerPrefs.SetInt(sceneName, 0);
            }
        }

        private void SetStars(int score)
        {
            SetStarForLevel(sceneName, score);

            PlayerPrefs.SetInt(sceneName, score);
        }

        private void SetStarForLevel(string sceneName, int star)
        {
            int index = 1;

            for (int i = 0; i < 24; i++)
                if (sceneName.Equals($"Level_{index++}"))
                    StarData.Instance.stateStarLevel[i] = star;
        }
    }
}