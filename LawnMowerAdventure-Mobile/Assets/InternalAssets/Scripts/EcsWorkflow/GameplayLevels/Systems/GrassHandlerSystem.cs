using Leopotam.Ecs;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class GrassHandlerSystem : IEcsInitSystem, IEcsRunSystem
    {
        public static Events.CurrentGrassCount OnCurrentGrassCount;

        private readonly EcsFilter<InitialGrassAmountComponent> filter = null;
        private int currentGrassCount;

        public void Init()
        {
            OnCurrentGrassCount += CalculationCurrentGrassCount;

            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                ref var currentGrassAmount = ref entity.Get<InitialGrassAmountComponent>();

                currentGrassCount = currentGrassAmount.InitialGrassAmount;
            }
        }

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                ref var currentGrassAmount = ref entity.Get<InitialGrassAmountComponent>();

                currentGrassAmount.InitialGrassAmount = currentGrassCount;
            }

            UnsubscribingEvent();
        }

        private int CalculationCurrentGrassCount(int count) => currentGrassCount += count;

        private void UnsubscribingEvent()
        {
            if (currentGrassCount <= 0)
            {
                if (OnCurrentGrassCount != null)
                    OnCurrentGrassCount -= CalculationCurrentGrassCount;

                return;
            }
        }
    }
}