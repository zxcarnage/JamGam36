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

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            _inFly = false;
            if (!_rigidbody) parent.GetComponent<Rigidbody2D>();
            if (!_groundCheck) parent.GetComponent<GroundCheck>();
            ServiceLocator.Instance.Get<EventBus>().Subscribe<FlyStarted>(StartFly);
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
            _rigidbody.velocity = new Vector2(_horizontal * _groundSpeed, _rigidbody.velocity.y);
        }

        public override void TryChangeState()
        {
            if(_inFly && _groundCheck.Ground())
                _machine.SetState(typeof(FlyMovement));
        }

        public override void Exit()
        {
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<FlyStarted>(StartFly);
        }

        private void StartFly(FlyStarted signal)
        {
            _inFly = true;
        }
    }
}