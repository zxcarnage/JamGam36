using Player;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "CrawlBackwards", menuName = "State/Player State/Crawl Backwards", order = 0)]
    public class CrawlBackwardsState : Crawl
    {
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            _wallSpriteRenderer = _collisionCheck.GetLeftWall();
            Animate();
        }
        protected override Vector2 CalculatePosition()
        {
            var bounds = _wallSpriteRenderer.bounds;
            var newXPos = bounds.min.x;
            return new Vector2(newXPos, 
                _transform.position.y);
        }

        public override void CaptureInput()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            
        }

        public override void TryChangeState()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}