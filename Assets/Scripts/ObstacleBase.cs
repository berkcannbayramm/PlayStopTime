using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Obstacle
{
    public enum ObstacleType
    {
        None,
        Spin,
        Block
    }
    public class ObstacleBase : MonoBehaviour
    {
        public Color32 Color;
        public MeshRenderer MeshRenderer;
        public ObstacleType ObstacleType;
        public SpinObstacle SpinObstacle;
        public BlockObstacle BlockObstacle;
        public float TweenSpeed;

        private void OnDestroy()
        {
            DOTween.Kill(this);
        }

        public virtual void StartObstacleMove(ObstacleType obstacleType)
        {
            switch(obstacleType)
            {
                case ObstacleType.None:
                    break;
                case ObstacleType.Spin:
                    SpinMove();
                    break;
                case ObstacleType.Block:
                    BlockMove();
                    break;
            }
        }
        private void SpinMove()
        {
            MeshRenderer.material.color = Color;

            transform.DORotate(new Vector3(0, 0, SpinObstacle.RotationDirection), TweenSpeed).SetId(this).SetLoops(-1,LoopType.Incremental).SetEase(Ease.Linear);
        }
        private void BlockMove()
        {
            MeshRenderer.material.color = Color;

            transform.DOMoveX(BlockObstacle.TargetPosition.position.x, TweenSpeed).SetId(this).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }

    [Serializable]
    public class SpinObstacle
    {
        public float RotationDirection;
    }
    [Serializable]
    public class BlockObstacle
    {
        public Transform TargetPosition;
    }
}
