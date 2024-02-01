using System;
using UnityEngine;

namespace Player
{
    public class CollisionCheck : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.05f;
        [SerializeField] private LayerMask _groundCollisionMask;
        [SerializeField] private LayerMask _crawlCollisionMask;
        
        public bool Ground()
        {
            return Physics2D.OverlapCircle(
                transform.position, 
                _radius, 
                _groundCollisionMask);
        }

        public SpriteRenderer GetGroundSprite()
        {
            return GetSpriteRenderer(transform.up * -1, _groundCollisionMask);
        }

        private SpriteRenderer GetSpriteRenderer(Vector2 direction, LayerMask collisionMask)
        {
            Ray ray = new Ray(transform.position, direction);
            var hit = Physics2D.Raycast(ray.origin, ray.direction, _radius, collisionMask);
            if (hit.collider)
            {
                var spriteRender = hit.collider.GetComponent<SpriteRenderer>();
                if (spriteRender)
                    return spriteRender;
            }

            return null;
        }

        public SpriteRenderer GetRightWall()
        {
            return GetSpriteRenderer(transform.right, _crawlCollisionMask);
        }
        
        public SpriteRenderer GetLeftWall()
        {
            return GetSpriteRenderer(transform.right * -1, _crawlCollisionMask);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _radius);
        }
    }
}