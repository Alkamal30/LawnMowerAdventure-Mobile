using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    public enum AxisOfCameraMovement { Horizontal, Button }
    public enum CameraMode { Perspective, Orthographics }

    public class HorizontalCameraMovementComponent : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Camera cameraForHorizontalMovement;
        [SerializeField] private AxisOfCameraMovement axisOfCameraMovement = AxisOfCameraMovement.Horizontal;

        // Button
        [SerializeField] private GameObject buttonLeft;
        [SerializeField] private GameObject buttonRight;
        [SerializeField] private int horizontalMovementIndex = 0;
        [SerializeField] private int horizontalMovementInterval = 1;
        [SerializeField] private int leftEdgeOfTheScreen = 0;
        [SerializeField] private int rightEdgeOfTheScreen = 5;

        // Mous
        [SerializeField] private float speedSmoothTransition = 4f;
        [SerializeField] private float minLeftCameraPosition = 0f;
        [SerializeField] private float maxLeftCameraPosition = 30f;

        // Camera Mode
        [SerializeField] private CameraMode cameraMode = CameraMode.Orthographics;

        private Vector2 startPosition;
        private float targetPosition;
        #endregion

        #region Prop
        public AxisOfCameraMovement AxisOfCameraMovement { get => axisOfCameraMovement; set => axisOfCameraMovement = value; }
        public Camera CameraForHorizontalMovement { get => cameraForHorizontalMovement; set => cameraForHorizontalMovement = value; }
        public GameObject ButtonLeft { get => buttonLeft; set => buttonLeft = value; }
        public GameObject ButtonRight { get => buttonRight; set => buttonRight = value; }
        public int HorizontalMovementIndex { get => horizontalMovementIndex; set => horizontalMovementIndex = value; }
        public float SpeedSmoothTransition { get => speedSmoothTransition; set => speedSmoothTransition = value; }
        public float MinLeftCameraPosition { get => minLeftCameraPosition; set => minLeftCameraPosition = value; }
        public float MaxLeftCameraPosition { get => maxLeftCameraPosition; set => maxLeftCameraPosition = value; }
        public int HorizontalMovementInterval { get => horizontalMovementInterval; set => horizontalMovementInterval = value; }
        public int LeftEdgeOfTheScreen { get => leftEdgeOfTheScreen; set => leftEdgeOfTheScreen = value; }
        public int RightEdgeOfTheScreen { get => rightEdgeOfTheScreen; set => rightEdgeOfTheScreen = value; }
        #endregion

        private void Awake()
        {
            if (CameraForHorizontalMovement == null)
            {
                CameraForHorizontalMovement = GameObject.FindGameObjectWithTag(Helper.Tag.MainCamera).GetComponent<Camera>();

                if (CameraForHorizontalMovement == null)
                    CameraForHorizontalMovement = GameObject.FindObjectOfType<Camera>();

                // TODO: Logs
            }

            // Button
            {
                HorizontalMovementIndex = 0;

                if (ButtonLeft != null && ButtonLeft.activeSelf == true)
                    buttonLeft.SetActive(false);
            }

            // Mouse
            {
                targetPosition = CameraForHorizontalMovement.transform.position.x;
            }
        }

        private void Update()
        {
            //cameraForHorizontalMovement.transform.position = new Vector3(Mathf.Lerp(cameraForHorizontalMovement.transform.position.x, targetPosition, speedSmoothTransition * Time.deltaTime), cameraForHorizontalMovement.transform.position.y, cameraForHorizontalMovement.transform.position.z);

            if (AxisOfCameraMovement == AxisOfCameraMovement.Button)
            {
                ButtonActivate(true);

                { // TODO: Add min and max value range
                    if (HorizontalMovementIndex == leftEdgeOfTheScreen)
                    {
                        ButtonLeft.SetActive(false);

                        return;
                    }

                    if (HorizontalMovementIndex == rightEdgeOfTheScreen)
                    {
                        buttonRight.SetActive(false);

                        return;
                    }
                }
            }

            if (AxisOfCameraMovement == AxisOfCameraMovement.Horizontal)
            {
                if (cameraMode == CameraMode.Orthographics)
                {
                    if (ButtonLeft && ButtonRight != null)
                        ButtonActivate(false);

                    {
                        if (Input.GetMouseButtonDown(0))             //.ScreenToViewportPoint
                            startPosition = cameraForHorizontalMovement.ScreenToWorldPoint(Input.mousePosition);

                        if (Input.GetMouseButton(0))
                        {                                      //.ScreenToViewportPoint
                            var pos = cameraForHorizontalMovement.ScreenToWorldPoint(Input.mousePosition).x - startPosition.x;

                            targetPosition = Mathf.Clamp(cameraForHorizontalMovement.transform.position.x - pos, minLeftCameraPosition, maxLeftCameraPosition);
                        }

                        cameraForHorizontalMovement.transform.position = new Vector3(Mathf.Lerp(cameraForHorizontalMovement.transform.position.x, targetPosition, speedSmoothTransition * Time.deltaTime), cameraForHorizontalMovement.transform.position.y, cameraForHorizontalMovement.transform.position.z);
                    }
                }

                if (cameraMode == CameraMode.Perspective)
                {
                    if (ButtonLeft && ButtonRight != null)
                        ButtonActivate(false);

                    {
                        if (Input.GetMouseButtonDown(0))             //.ScreenToViewportPoint
                            startPosition = cameraForHorizontalMovement.ScreenToViewportPoint(Input.mousePosition);

                        if (Input.GetMouseButton(0))
                        {                                      //.ScreenToViewportPoint
                            var pos = cameraForHorizontalMovement.ScreenToViewportPoint(Input.mousePosition).x - startPosition.x;

                            targetPosition = Mathf.Clamp(cameraForHorizontalMovement.transform.position.x - pos, minLeftCameraPosition, maxLeftCameraPosition);
                        }

                        cameraForHorizontalMovement.transform.position = new Vector3(Mathf.Lerp(cameraForHorizontalMovement.transform.position.x, targetPosition, speedSmoothTransition * Time.deltaTime), cameraForHorizontalMovement.transform.position.y, cameraForHorizontalMovement.transform.position.z);
                    }
                }
            }
        }

        #region Button
        public void LeftIsland()
        {
            if (HorizontalMovementIndex > 0) HorizontalMovementIndex -= HorizontalMovementInterval;

            ButtonRight.SetActive(true);

            CameraForHorizontalMovement.transform.position = new Vector3(CameraForHorizontalMovement.transform.position.x - horizontalMovementInterval, CameraForHorizontalMovement.transform.position.y, CameraForHorizontalMovement.transform.position.z);
        }

        public void RightIsland()
        {
            HorizontalMovementIndex += HorizontalMovementInterval;

            ButtonLeft.SetActive(true);

            CameraForHorizontalMovement.transform.position = new Vector3(CameraForHorizontalMovement.transform.position.x + horizontalMovementInterval, CameraForHorizontalMovement.transform.position.y, CameraForHorizontalMovement.transform.position.z);
        }

        private void ButtonActivate(bool isActiv)
        {
            ButtonLeft.SetActive(isActiv);
            ButtonRight.SetActive(isActiv);
        }
        #endregion
    }
}