using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class GrassArrayInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            var grassArrayEntity = _world.NewEntity();

            ref var grassCount = ref grassArrayEntity.Get<InitialGrassAmountComponent>();
           
            grassCount.InitialGrassAmount = GameObject.FindGameObjectsWithTag(Helper.Tag.Grass).Length;
            grassCount.CurrentGrassAmount = grassCount.InitialGrassAmount;
        }
    }
}