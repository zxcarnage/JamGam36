﻿using CustomEventBus;
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
        private Animator _animator;
        private bool _flyUp;
        private float _horizontal;
        private float _elapsedTime;
        
        private static readonly int InFly = Animator.StringToHash("InFly");

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_animator) _animator = parent.Animator;
            _animator.SetBool(InFly, true);
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
            _animator.SetBool(InFly, false);
        }
    }
}