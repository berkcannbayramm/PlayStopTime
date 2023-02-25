using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public enum ObstacleType
    {
        None,
        Spin
    }
    public class ObstacleBase : MonoBehaviour
    {
        public Color32 Color;
        public MeshRenderer meshRenderer;

        public ObstacleType ObstacleType;
        public SpinObstacle SpinObstacle;
    }

    [Serializable]
    public class SpinObstacle
    {
        public float RotationDirection;
        public float RotationSpeed;
    }
}
