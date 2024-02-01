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

        public SpriteRenderer GetGroundSprite()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, _radius, _collisionMask);
            if (hit.collider)
            {
                var spriteRender = hit.collider.GetComponent<SpriteRenderer>();
                if (spriteRender)
                    return spriteRender;
            }

            return null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _radius);
        }
    }
}