using Player;
using UnityEngine;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "ReversedGravity", menuName = "State/Player State/Reversed Gravity", order = 0)]
    public class ReversedGravity : State<PlayerController>
    {
        [SerializeField] private float _yOffset = 0.0f;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _groundSpriteRenderer;
        private SpriteRenderer _spriteRenderer;
        private CollisionCheck _collisionCheck;
        private bool _reversed = false;

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_collisionCheck) _collisionCheck = parent.GetComponent<CollisionCheck>();
            if (!_spriteRenderer) _spriteRenderer = parent.PlayerModel;
            if(!_groundSpriteRenderer) _groundSpriteRenderer = _collisionCheck.GetGroundSprite();
            ReverseGravity();
            _machine.SetState(typeof(GroundMovement));
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

        private void ReverseGravity()
        {
            ReverseSpritePos();
            ReverseSpriteTransform();
            _rigidbody.gravityScale *= -1;
            _reversed = !_reversed;
        }

        private void ReverseSpritePos()
        {
            var bounds = _groundSpriteRenderer.bounds;
            var newYPos = _reversed ? bounds.max.y + _yOffset : bounds.min.y - _yOffset;
            var newPosition = new Vector2(_rigidbody.position.x, 
                newYPos);
            _rigidbody.position = newPosition;
        }

        private void ReverseSpriteTransform()
        {
            _spriteRenderer.flipY = !_spriteRenderer.flipY;
        }
    }
}