using CustomServiceLocator;
using StateMachine.StateMachines;
using UI;
using UnityEngine;

namespace StateMachine.States.GameStates
{
    [CreateAssetMenu(fileName = "BlackScreenState", menuName = "State/GameState/Black Screen State", order = 0)]
    public class BlackScreenState : State<GameStateMachine>
    {
        [SerializeField] private float _blackScreenDuration;

        private float _elapsedTime;
        public override void Enter(GameStateMachine parent)
        {
            _machine = parent;
            _elapsedTime = 0.0f;
            ServiceLocator.Instance.Get<BlackScreen>().gameObject.SetActive(true);
        }

        public override void CaptureInput()
        {
        }

        public override void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _blackScreenDuration)
            {
                ServiceLocator.Instance.Get<BlackScreen>().gameObject.SetActive(false);
                _machine.SetState(typeof(EndOfTutorialDialogue));
            }
                
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
    }
}