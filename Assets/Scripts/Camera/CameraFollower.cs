using System;
using Player;
using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _xOffset;
        [SerializeField] private float _yOffset;

        private void LateUpdate()
        {
            transform.position = new Vector3(_player.transform.position.x + _xOffset, 
                _player.transform.position.y + _yOffset,
                transform.position.z);
        }
    }
}