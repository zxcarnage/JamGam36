using System;
using CustomEventBus;
using CustomServiceLocator;
using Player;
using StateMachine.StateMachines;
using StateMachine.States.GameStates;
using UnityEngine;
using Cutscene = StateMachine.States.PlayerStates.Cutscene;

namespace EntryPoints
{
    public class MainGameEntryPoint : MonoBehaviour
    {
        private EventBus _eventBus;
        private void Awake()
        {
            CreateServices();
            RegisterServices();
        }

        private void Start()
        {
            InitMachines();
        }

        private void CreateServices()
        {
            _eventBus = new EventBus();
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(_eventBus);
        }
        
        private void InitMachines()
        {
            ServiceLocator.Instance.Get<GameStateMachine>().Init(typeof(ComingSoon));
            ServiceLocator.Instance.Get<PlayerController>().Init(typeof(Cutscene));
        }
    }
}