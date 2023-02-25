using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public class Obstacle : ObstacleBase
    {

        private void Start()
        {
            StartObstacleMove(ObstacleType);
        }
        public override void StartObstacleMove(ObstacleType obstacleType)
        {
            base.StartObstacleMove(obstacleType);
        }
    }
}
