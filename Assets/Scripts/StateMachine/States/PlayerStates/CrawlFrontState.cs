using CustomEventBus;
using CustomServiceLocator;
using DG.Tweening;
using Player;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "CrawlFront", menuName = "State/Player State/Crawl Front", order = 0)]
    public class CrawlFrontState : Crawl
    {
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            _wallSpriteRenderer = _collisionCheck.GetRightWall();
            Animate();
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

        protected override Vector2 CalculatePosition()
        {
            var bounds = _wallSpriteRenderer.bounds;
            var newXPos = bounds.max.x;
            return new Vector2(newXPos, 
                _transform.position.y);
        }
    }
}