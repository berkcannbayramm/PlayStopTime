using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Obstacle
{
    [CustomEditor(typeof(ObstacleBase), true)]
    public class ObstacleBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var obstacleBase = (ObstacleBase)target;

            obstacleBase.ObstacleType = (ObstacleType)EditorGUILayout.EnumPopup("Obstacle Tyoe", obstacleBase.ObstacleType);

            switch (obstacleBase.ObstacleType)
            {
                case ObstacleType.None:
                    break;
                case ObstacleType.Spin:
                    obstacleBase.SpinObstacle.RotationDirection = EditorGUILayout.FloatField("Rotation Direction", obstacleBase.SpinObstacle.RotationDirection);
                    
                    obstacleBase.SpinObstacle.RotationSpeed = EditorGUILayout.FloatField("Rotation Speed", obstacleBase.SpinObstacle.RotationSpeed);

                    obstacleBase.meshRenderer = (MeshRenderer)EditorGUILayout.ObjectField("Mesh Renderer", obstacleBase.meshRenderer, typeof(MeshRenderer), true);

                    if (!obstacleBase.meshRenderer)
                    {
                        EditorGUILayout.HelpBox("Select Mesh Renderer!", MessageType.Error);
                        return;
                    }

                    EditorGUI.BeginChangeCheck();

                    obstacleBase.Color = EditorGUILayout.ColorField("Base Color", obstacleBase.Color);

                    if (EditorGUI.EndChangeCheck())
                    {
                        obstacleBase.meshRenderer.sharedMaterial.color = obstacleBase.Color;
                    }

                    break;
            }
        }
    }
}
