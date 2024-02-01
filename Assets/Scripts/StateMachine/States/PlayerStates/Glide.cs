using Player;
using UnityEngine;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Glide", menuName = "State/Player State/Glide", order = 0)]
    public class Glide : State<PlayerController>
    {
        [SerializeField] private float _glideDownSpeed;
        [SerializeField] private float _glideHorizontalSpeed;

        private Rigidbody2D _rigidbody;
        private CollisionCheck _collisionCheck;

        private float _horizontal;
        
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_collisionCheck) _collisionCheck = parent.GetComponent<CollisionCheck>();
        }

        public override void CaptureInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
        }

        public override void Update()
        {
            
        }

        public override void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_glideHorizontalSpeed * _horizontal, -1 * _glideDownSpeed * _rigidbody.gravityScale);
        }

        public override void TryChangeState()
        {
            if(_collisionCheck.Ground())
                _machine.SetState(typeof(GroundMovement));
        }

        public override void Exit()
        {
            
        }
    }
}