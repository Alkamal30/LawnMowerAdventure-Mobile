//////
//// Rimuru 18.12.2021 12:30
//// Замена управления на единую неведимую кнопку во весь экран.
//////

using Leopotam.Ecs;

namespace AbyssMothGames.LawnMowerWorld
{
    public enum Turn { LEFT = -90, RIGHT = 90 }

    internal sealed class LawnMowerSwingInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<CharacterComponent> _characterFilter = null;

        private readonly SceneUIConfiguretion _uiConfiguration;

        public void Init()
        {
            _uiConfiguration.LeftTurnButton.onClick.AddListener(OnLeftTurnButtonDown);
            _uiConfiguration.RightTurnButton.onClick.AddListener(OnRightTurnButtonDown);
        }

        private void OnLeftTurnButtonDown() => RotateCharacterAtAngle((float)Turn.LEFT);

        private void OnRightTurnButtonDown() => RotateCharacterAtAngle((float)Turn.RIGHT);

        private void RotateCharacterAtAngle(float angle)
        {
            foreach (int index in _characterFilter)
            {
                ref var characterComponent = ref _characterFilter.Get1(index);
                var characterTransform = characterComponent.characterGO.transform;

                characterTransform.Rotate(0, angle, 0);
            }
        }
    }
}