using Command;
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
        private void Start()
        {
            var eventBus = new CustomEventBus.EventBus();
            var tutorialInputHandler = new TutorialInputHandler();
            //Initializing tutorial entry point services
            //Initializing Player
            ServiceLocator.Instance.Register(tutorialInputHandler);
            ServiceLocator.Instance.Register(eventBus);
            ServiceLocator.Instance.Get<GameStateMachine>().Init(typeof(Tutorial));
            ServiceLocator.Instance.Get<PlayerController>().Init(typeof(GroundMovement));
            Debug.Log("Tutorial scene initialized!");
        }
    }
}