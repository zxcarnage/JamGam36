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
        private CollisionCheck _collisionCheck;
        private float _horizontal;
        private bool _grounded;

        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            if (!_rigidbody) _rigidbody = parent.GetComponent<Rigidbody2D>();
            if (!_collisionCheck) _collisionCheck = parent.GetComponent<CollisionCheck>();
            Subscribe();
        }

        private void Subscribe()
        {
            ServiceLocator.Instance.Get<EventBus>().Subscribe<FlyStarted>(StartFly);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<ReverseGravitySignal>(ReverseGravity);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<CrawlFrontSignal>(CrawlFront);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<CrawlBackSignal>(CrawlBackwards);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<DialogueStartedSignal>(DialogueStarted);
        }

        private void Unsubscribe()
        {
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<FlyStarted>(StartFly);
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<ReverseGravitySignal>(ReverseGravity);
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<CrawlFrontSignal>(CrawlFront);
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<CrawlBackSignal>(CrawlBackwards);
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<DialogueStartedSignal>(DialogueStarted);
        }

        public override void CaptureInput()
        {
            _horizontal = Input.GetAxis("Horizontal");
        }

        public override void Update()
        {
            _grounded = _collisionCheck.Ground();
        }

        public override void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_horizontal * _groundSpeed, _rigidbody.velocity.y);
        }

        public override void TryChangeState()
        {

        }

        public override void Exit()
        {
            Unsubscribe();
        }

        private void CrawlFront(CrawlFrontSignal signal)
        {
            if(_grounded && _collisionCheck.GetRightWall())
                _machine.SetState(typeof(CrawlFrontState));
        }

        private void CrawlBackwards(CrawlBackSignal signal)
        {
            if(_grounded && _collisionCheck.GetLeftWall())
                _machine.SetState(typeof(CrawlBackwardsState));
        }

        private void StartFly(FlyStarted signal)
        {
            if(_grounded)
                _machine.SetState(typeof(FlyMovement));
        }

        private void ReverseGravity(ReverseGravitySignal reverseGravitySignal)
        {
            if(_grounded)
                _machine.SetState(typeof(ReversedGravity));
        }

        private void DialogueStarted(DialogueStartedSignal signal)
        {
            _machine.SetState(typeof(Cutscene));
        }
    }
}