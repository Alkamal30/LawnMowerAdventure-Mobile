using UnityEditor;
using UnityEngine;

namespace AbyssMothGames.LawnMowerWorld
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(HorizontalCameraMovementComponent))]
    public sealed class HorizontalCameraMovement : Editor
    {
        private HorizontalCameraMovementComponent horizontalCameraMovementComponent;

        private SerializedProperty axisOfCameraMovement;
        private SerializedProperty camera;

        // Button mode
        private SerializedProperty buttonLeft;
        private SerializedProperty buttonRight;
        private SerializedProperty horizontalMovementIndex;
        private SerializedProperty horizontalMovementInterval;
        private SerializedProperty leftEdgeOfTheScreen;
        private SerializedProperty rightEdgeOfTheScreen;

        // Mouse mode
        private SerializedProperty speedSmoothTransition;
        private SerializedProperty minLeftCameraPosition;
        private SerializedProperty maxLeftCameraPosition;

        // Camera mode
        private SerializedProperty cameraMode;

        private void OnEnable()
        {
            horizontalCameraMovementComponent = target as HorizontalCameraMovementComponent;

            camera = serializedObject.FindProperty("cameraForHorizontalMovement");

            axisOfCameraMovement = serializedObject.FindProperty("axisOfCameraMovement");

            // Button mode
            buttonLeft = serializedObject.FindProperty("buttonLeft");
            buttonRight = serializedObject.FindProperty("buttonRight");
            horizontalMovementIndex = serializedObject.FindProperty("horizontalMovementIndex");
            horizontalMovementInterval = serializedObject.FindProperty("horizontalMovementInterval");
            leftEdgeOfTheScreen = serializedObject.FindProperty("leftEdgeOfTheScreen");
            rightEdgeOfTheScreen = serializedObject.FindProperty("rightEdgeOfTheScreen");

            // Mouse mode                          
            speedSmoothTransition = serializedObject.FindProperty("speedSmoothTransition");
            minLeftCameraPosition = serializedObject.FindProperty("minLeftCameraPosition");
            maxLeftCameraPosition = serializedObject.FindProperty("maxLeftCameraPosition");

            // Camera mode
            cameraMode = serializedObject.FindProperty("cameraMode");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            {
                // Header
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.PropertyField(camera);
                    EditorGUILayout.Space();
                    EditorGUILayout.PropertyField(axisOfCameraMovement);
                }

                if (horizontalCameraMovementComponent.AxisOfCameraMovement.Equals(AxisOfCameraMovement.Button))
                {
                    EditorGUILayout.Space();
                    {
                        EditorGUILayout.PropertyField(buttonLeft);
                        EditorGUILayout.PropertyField(buttonRight);
                    }
                    EditorGUILayout.Space();

                    EditorGUILayout.IntSlider(leftEdgeOfTheScreen, 0, 100, new GUIContent("Left Edge Of The Screen"));
                    EditorGUILayout.IntSlider(rightEdgeOfTheScreen, 0, 100, new GUIContent("Right Edge Of The Screen"));
                    EditorGUILayout.Space();
                    EditorGUILayout.IntSlider(horizontalMovementIndex, 0, 100, new GUIContent("Horizontal Movement Index"));
                    EditorGUILayout.IntSlider(horizontalMovementInterval, 0, 100, new GUIContent("Horizontal Movement Interval"));
                }

                if (horizontalCameraMovementComponent.AxisOfCameraMovement.Equals(AxisOfCameraMovement.Horizontal))
                {
                    EditorGUILayout.Space();
                    {
                        EditorGUILayout.PropertyField(speedSmoothTransition);
                        EditorGUILayout.PropertyField(minLeftCameraPosition);
                        EditorGUILayout.PropertyField(maxLeftCameraPosition);
                        EditorGUILayout.PropertyField(cameraMode);
                    }
                    EditorGUILayout.Space();
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}