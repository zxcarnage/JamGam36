using System;
using UnityEngine;

namespace Player
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.05f;
        [SerializeField] private LayerMask _collisionMask;
        
        public bool Ground()
        {
            return Physics2D.OverlapCircle(
                transform.position, 
                _radius, 
                _collisionMask);
        }

        private void OnGUI()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, Vector3.down * _radius);
        }
    }
}