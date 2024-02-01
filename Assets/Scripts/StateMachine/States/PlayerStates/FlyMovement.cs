using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using Player;
using UnityEngine;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "FlyMovement", menuName = "State/Player State/Fly Movement", order = 0)]
    public class FlyMovement : State<PlayerController>
    {
        [SerializeField] private float _flightTime;
        [SerializeField] private float _horizontalFlySpeed;
        [SerializeField] private float _verticalFlySpeed;

        private Rigidbody2D _rigidbody;
        private bool _flyUp;
        private float _horizontal;
        private float _elapsedTime;
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            _elapsedTime = 0f;
        }

        public override void CaptureInput()
        {
            _flyUp = Input.GetKey(KeyCode.Space);
            _horizontal = Input.GetAxis("Horizontal");
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
        }

        public override void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_horizontal * _horizontalFlySpeed, _verticalFlySpeed * _rigidbody.gravityScale);
        }

        public override void TryChangeState()
        {
            if(_elapsedTime >= _flightTime || !_flyUp)
                _machine.SetState(typeof(Glide));
        }

        public override void Exit()
        {
        }
    }
}