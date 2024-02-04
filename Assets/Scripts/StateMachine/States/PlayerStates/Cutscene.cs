using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using Player;
using UnityEngine;

namespace StateMachine.States.PlayerStates
{
    [CreateAssetMenu(fileName = "Cutscene", menuName = "State/Player State/Cutscene", order = 0)]
    public class Cutscene : State<PlayerController>
    {
        private SpriteDirectionSwapper _swapper;
        public override void Enter(PlayerController parent)
        {
            base.Enter(parent);
            ServiceLocator.Instance.Get<EventBus>().Subscribe<CutsceneEndedSignal>(EndCutscene);
            if (!_swapper) _swapper = parent.GetComponent<SpriteDirectionSwapper>();
            _swapper.enabled = false;
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
            _swapper.enabled = true;
            ServiceLocator.Instance.Get<EventBus>().Unsubscribe<CutsceneEndedSignal>(EndCutscene);
        }

        private void EndCutscene(CutsceneEndedSignal signal)
        {
            _machine.SetState(typeof(GroundMovement));
        }
    }
}