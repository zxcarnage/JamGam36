using System;
using CustomServiceLocator;

namespace StateMachine.StateMachines
{
    public class GameStateMachine : StateMachine<GameStateMachine>, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }
    }
}