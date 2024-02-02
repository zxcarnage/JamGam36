using Command;
using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using StateMachine.StateMachines;
using UnityEngine;

namespace StateMachine.States.GameStates
{
    [CreateAssetMenu(fileName = "Tutorial", menuName = "State/GameState/Tutorial", order = 0)]
    public class Tutorial : State<GameStateMachine>
    {
        private TutorialInputHandler _tutorialInputHandler;
        private bool _tutorialEnded = false;
        private bool _cutsceneStarted = false;
        
        public override void Enter(GameStateMachine parent)
        {
            base.Enter(parent);
            if(_tutorialInputHandler == null) _tutorialInputHandler = ServiceLocator.Instance.Get<TutorialInputHandler>();
            
        }

        public override void CaptureInput()
        {
            _tutorialInputHandler.HandleInput();
        }

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void TryChangeState()
        {
            if(_tutorialEnded)
                _machine.SetState(typeof(MainGame));
            if(_cutsceneStarted)
                _machine.SetState(typeof(Cutscene));
        }

        public override void Exit()
        {
            
        }
    }
}