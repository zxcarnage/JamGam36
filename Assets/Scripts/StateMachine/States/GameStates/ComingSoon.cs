using CustomServiceLocator;
using StateMachine.StateMachines;
using UI;
using UnityEngine;

namespace StateMachine.States.GameStates
{
    [CreateAssetMenu(fileName = "ComingSoon", menuName = "State/GameState/ComingSoon", order = 0)]
    public class ComingSoon : State<GameStateMachine>
    {
        public override void Enter(GameStateMachine parent)
        {
            base.Enter(parent);
            ServiceLocator.Instance.Get<ComingSoonPanel>().gameObject.SetActive(true);
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
            
        }
    }
}