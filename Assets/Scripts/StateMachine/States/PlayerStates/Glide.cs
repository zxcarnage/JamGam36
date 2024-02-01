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
        private GroundCheck _groundCheck;

        private float _horizontal;
        
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_groundCheck) _groundCheck = parent.GetComponent<GroundCheck>();
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
            _rigidbody.velocity = new Vector2(_glideHorizontalSpeed * _horizontal, -1 * _glideDownSpeed);
        }

        public override void TryChangeState()
        {
            if(_groundCheck.Ground())
                _machine.SetState(typeof(GroundMovement));
        }

        public override void Exit()
        {
            
        }
    }
}