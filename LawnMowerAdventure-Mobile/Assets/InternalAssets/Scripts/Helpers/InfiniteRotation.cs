using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld.Helpers
{
    public enum Axis { Horizontal, Vertical, All, None }

    public sealed class InfiniteRotation : MonoBehaviour
    {
        [SerializeField] float speedRotation = 0.1f;
        [SerializeField] Axis axisRotation = Axis.None;

        private void Update()
        {
            if (!axisRotation.Equals(Axis.None))
            {
                switch (axisRotation)
                {
                    case Axis.Horizontal: transform.Rotate(speedRotation    * Time.deltaTime,                                                           0, 0); break;
                    case Axis.Vertical:   transform.Rotate(0, speedRotation * Time.deltaTime,                                                              0); break;
                    case Axis.All:        transform.Rotate(speedRotation    * Time.deltaTime, speedRotation * Time.deltaTime, speedRotation * Time.deltaTime); break;
                }
            }
        }
    }
}