using DG.Tweening;
using Player;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace StateMachine.States.PlayerStates
{
    public abstract class Crawl : State<PlayerController>
    {
        [SerializeField] private float _animationDuration;
        [SerializeField] protected float _xOffset;
        protected Transform _transform;
        protected CollisionCheck _collisionCheck;
        protected SpriteRenderer _wallSpriteRenderer;
        

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_transform) _transform = parent.GetComponent<Transform>();
            if (!_collisionCheck) _collisionCheck = parent.GetComponent<CollisionCheck>();
            _wallSpriteRenderer = _collisionCheck.GetRightWall();
        }

        protected void Animate()
        {
            Debug.Log("animation started");
            var newPosition = CalculatePosition();
            _transform.DOMoveX(newPosition.X + _xOffset, _animationDuration).SetEase(Ease.Linear).OnComplete(() => {_machine.SetState(typeof(GroundMovement));});
        }

        protected abstract Vector2 CalculatePosition();
    }
}