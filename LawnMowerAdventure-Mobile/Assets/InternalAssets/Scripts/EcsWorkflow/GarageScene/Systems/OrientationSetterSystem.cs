using Leopotam.Ecs;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    internal sealed class OrientationSetterSystem : IEcsPreInitSystem
    {
        public void PreInit()
        {
            Screen.orientation = ScreenOrientation.Landscape;
            Screen.orientation = ScreenOrientation.AutoRotation;

            Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
            Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = true;
        }
    }
}