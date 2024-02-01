using System;
using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using Player;
using UnityEngine;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "GroundMovement", menuName = "State/Player State/Ground Movement", order = 0)]
    public class GroundMovement : State<PlayerController>
    {
        [SerializeField] private float _groundSpeed;


        private Rigidbody2D _rigidbody;
        private GroundCheck _groundCheck;
        private float _horizontal;
        private bool _inFly;
        private bool _reverseGravity;

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            _inFly = false;
            _reverseGravity = false;
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_groundCheck) _groundCheck = parent.GetComponent<GroundCheck>();
            ServiceLocator.Instance.Get<EventBus>().Subscribe<FlyStarted>(StartFly);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<ReverseGravitySignal>(ReverseGravity);
        }

        public override void CaptureInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
        }

        public override void Update()
        {
            Debug.Log(_groundCheck.Ground());
        }

        public override void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_horizontal * _groundSpeed, _rigidbody.velocity.y);
        }

        public override void TryChangeState()
        {
            if (_groundCheck.Ground())
            {
                if(_inFly)
                    _machine.SetState(typeof(FlyMovement));
                if(_reverseGravity)
                    _machine.SetState(typeof(ReversedGravity));
            }
             
        }

        public override void Exit()
        {
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<ReverseGravitySignal>(ReverseGravity);
        }

        private void StartFly(FlyStarted signal)
        {
            _inFly = true;
        }

        private void ReverseGravity(ReverseGravitySignal reverseGravitySignal)
        {
            _reverseGravity = true;
        }
    }
}