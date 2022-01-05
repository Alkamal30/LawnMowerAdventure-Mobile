using UnityEngine;

public sealed class LightAnimation : MonoBehaviour
{
    [SerializeField] private Light lightPoint;

    [SerializeField] private float maxRange = 0.8f;
    [SerializeField] private float minRange = 0.4f;

    private void Update() =>
        lightPoint.range = Mathf.PingPong(Time.deltaTime, maxRange - minRange) + minRange;
}
