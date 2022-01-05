using System.Collections.Generic;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class SceneConfigurationData : MonoBehaviour
    {
        #region Fields //TODO: Create T List
        public List<LawnMower> currentLawnMower;
        public List<CameraConfigurations> cameraConfig;
        public List<CharacterInputSettings> characterInputSettings;
        public List<CoinSpawnSettings> coinSpawnSettings;
        public List<CharacterSpawnPoint> characterSpawnPoints;
        public List<CurrentStateStars> currentStateStars;
        public List<WoodLogTrapSettings> woodLogTrapSettings;
        public List<WinSettings> winSettings;
        public List<Currency> currency;
        #endregion

        #region Methods
        public void AddLawnMower(LawnMower lawnMowers) => currentLawnMower.Add(lawnMowers);
        public void RemoveLawnMower(LawnMower lawnMowers) => currentLawnMower.Remove(lawnMowers);

        public void AddCameraConfig(CameraConfigurations cameraConfigu) => cameraConfig.Add(cameraConfigu);
        public void RemoveCameraConfig(CameraConfigurations cameraConfigu) => cameraConfig.Remove(cameraConfigu);
        #endregion
    }
}