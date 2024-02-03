using Command;
using CustomEventBus;
using CustomEventBus.Signals;
using StateMachine.StateMachines;
using StateMachine.States.GameStates;
using UnityEngine;
using CustomServiceLocator;
using Player;
using StateMachine.States.PlayerStates;
using Cutscene = StateMachine.States.PlayerStates.Cutscene;

namespace EntryPoints
{
    public class TutorialEntryPoint : MonoBehaviour
    {
        private EventBus _eventBus;
        private TutorialInputHandler _tutorialInputHandler;

        private void Awake()
        {
            CreateServices();
            RegisterServices();
        }

        private void Start()
        {
            InitMachines();

            SubscribeUnlocks();
            Debug.Log("Tutorial scene initialized!");
        }

        private void CreateServices()
        {
            _eventBus = new EventBus();
            _tutorialInputHandler = new TutorialInputHandler(_eventBus);
        }

        private void SubscribeUnlocks()
        {
            _eventBus.Subscribe<FlyUnlockedSignal>(_tutorialInputHandler.UnlockFly);
            _eventBus.Subscribe<ReversedGravityUnlockedSignal>(_tutorialInputHandler.UnlockGravity);
            _eventBus.Subscribe<CrawlUnlockedSignal>(_tutorialInputHandler.UnlockCrawl);
        }
        
        private void RegisterServices()
        {
            ServiceLocator.Instance.Register(_tutorialInputHandler);
            ServiceLocator.Instance.Register(_eventBus);
        }

        private void InitMachines()
        {
            ServiceLocator.Instance.Get<GameStateMachine>().Init(typeof(EntryDialogue));
            ServiceLocator.Instance.Get<PlayerController>().Init(typeof(Cutscene));
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<FlyUnlockedSignal>(_tutorialInputHandler.UnlockFly);
            _eventBus.Unsubscribe<ReversedGravityUnlockedSignal>(_tutorialInputHandler.UnlockGravity);
        }
    }
}