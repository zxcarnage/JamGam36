using System;
using Player;
using UnityEngine;

namespace Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _xOffset;

        private void LateUpdate()
        {
            transform.position = new Vector3(_player.transform.position.x + _xOffset, 
                transform.position.y,
                transform.position.z);
        }
    }
}