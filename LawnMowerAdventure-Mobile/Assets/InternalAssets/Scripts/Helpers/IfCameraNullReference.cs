using UnityEngine;

public sealed class IfCameraNullReference : MonoBehaviour
{
    private Canvas doTweenCanwas;

    private void Awake() => doTweenCanwas = GetComponent<Canvas>();
    
    private void Start() => doTweenCanwas.worldCamera = GameObject.FindGameObjectWithTag(Helper.Tag.MainCamera).GetComponent<Camera>();
}
