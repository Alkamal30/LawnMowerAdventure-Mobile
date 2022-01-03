using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public sealed class WicketController : MonoBehaviour
    {
        // Value for tests.
        [SerializeField] private float leftRotateEnter = -90f;
        [SerializeField] private float rightRotateEnter = 90f;
        [Space]
        [SerializeField] private float leftRotateExit = 0f;
        [SerializeField] private float rightRotateExit = 0f;

        private GameObject[] wickets;

        private void Awake() => wickets = new GameObject[FindingChildObjectCount()];

        private void Start() => FindingChildPrefabs();

        private void OnTriggerEnter(Collider other) => OnTriggerMode(other, leftRotateEnter, rightRotateEnter);

        private void OnTriggerExit(Collider other) => OnTriggerMode(other, leftRotateExit, rightRotateExit);

        private void SetRotationAngle(float leftWicket = 0f, float rightWicket = 0f)
        {
            wickets[0].transform.localRotation = Quaternion.Euler(0, leftWicket, 0);
            wickets[1].transform.localRotation = Quaternion.Euler(0, rightWicket, 0);
        }

        private void FindingChildPrefabs()
        {
            for (int i = 0; i < transform.childCount; i++)
                wickets[i] = transform.GetChild(i).transform.gameObject;
        }

        private int FindingChildObjectCount() => transform.childCount;

        private void OnTriggerMode(Collider collider, float left, float right)
        {
            if (collider.gameObject.CompareTag(Helper.Tag.Player))
                SetRotationAngle(left, right);
        }
    }
}