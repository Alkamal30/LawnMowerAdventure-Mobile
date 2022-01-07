using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class EndlessMovementForwardSystem : IEcsRunSystem
    {
        public readonly EcsWorld _world = null;
        public readonly EcsFilter<CharacterComponent> characterFilter = null;

        public void Run()
        {
            foreach (var i in characterFilter)
            {
                ref var character = ref characterFilter.Get1(i);

                if (character.GameObject == null)
                {
                    Debug.Log("The player's object reference has gone off or the player has lost.");

                    return;
                }

                character.Rigidbody.velocity = character.Transform.forward * character.MovementSpeed;
            }
        }
    }
}