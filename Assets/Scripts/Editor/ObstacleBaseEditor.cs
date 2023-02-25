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

                    obstacleBase.TweenSpeed = EditorGUILayout.FloatField("Tween Speed", obstacleBase.TweenSpeed);

                    EditorUtils.DrawUILine(Color.gray);
                    
                    break;

                case ObstacleType.Block:

                    obstacleBase.BlockObstacle.TargetPosition = (Transform)EditorGUILayout.ObjectField("Target Position", obstacleBase.BlockObstacle.TargetPosition, typeof(Transform), true);

                    obstacleBase.TweenSpeed = EditorGUILayout.FloatField("Tween Speed", obstacleBase.TweenSpeed);

                    EditorUtils.DrawUILine(Color.gray);

                    break;
            }

            if (obstacleBase.ObstacleType == ObstacleType.None) return;

            obstacleBase.MeshRenderer = (MeshRenderer)EditorGUILayout.ObjectField("Mesh Renderer", obstacleBase.MeshRenderer, typeof(MeshRenderer), true);

            if (!obstacleBase.MeshRenderer)
            {
                EditorGUILayout.HelpBox("Select Mesh Renderer!", MessageType.Error);
                return;
            }

            EditorGUI.BeginChangeCheck();

            obstacleBase.Color = EditorGUILayout.ColorField("Base Color", obstacleBase.Color);

            if (EditorGUI.EndChangeCheck())
            {
                obstacleBase.MeshRenderer.material.color = obstacleBase.Color;
            }
        }
    }
}
