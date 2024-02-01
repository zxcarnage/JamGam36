using System;
using Command;
using CustomEventBus;
using CustomEventBus.Signals;
using StateMachine.StateMachines;
using StateMachine.States.GameStates;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomServiceLocator;
using Player;
using StateMachine.States.PlayerStates;

namespace EntryPoints
{
    public class TutorialEntryPoint : MonoBehaviour
    {
        private EventBus _eventBus;
        private TutorialInputHandler _tutorialInputHandler;
        private void Start()
        {
            _eventBus = new CustomEventBus.EventBus();
            _tutorialInputHandler = new TutorialInputHandler();
            //Initializing tutorial entry point services
            //Initializing Player
            ServiceLocator.Instance.Register(_tutorialInputHandler);
            ServiceLocator.Instance.Register(_eventBus);
            ServiceLocator.Instance.Get<GameStateMachine>().Init(typeof(Tutorial));
            ServiceLocator.Instance.Get<PlayerController>().Init(typeof(GroundMovement));
            
            _eventBus.Subscribe<FlyUnlockedSignal>(_tutorialInputHandler.UnlockFly);
            _eventBus.Subscribe<ReversedGravityUnlockedSignal>(_tutorialInputHandler.UnlockGravity);
            Debug.Log("Tutorial scene initialized!");
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<FlyUnlockedSignal>(_tutorialInputHandler.UnlockFly);
            _eventBus.Unsubscribe<ReversedGravityUnlockedSignal>(_tutorialInputHandler.UnlockGravity);
        }
    }
}