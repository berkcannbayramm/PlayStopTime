using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private IPlayerMove _playerMove;
        private void Awake()
        {
            _playerMove = GetComponent<IPlayerMove>();
#if UNITY_EDITOR
            Debug.LogWarning("Please use simulator");
#endif
        }
        private void Update()
        {
            if (Input.touchCount > 0) _playerMove.Move();
        }
    }
}
