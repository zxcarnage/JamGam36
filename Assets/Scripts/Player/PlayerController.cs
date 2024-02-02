using System;
using System.Collections.Generic;
using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using StateMachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerTriggerHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CollisionCheck))]
    public class PlayerController : StateMachine<PlayerController>, IService
    {
        [SerializeField] private SpriteRenderer _playerModel;
        [SerializeField] private Animator _animator;

        [SerializeField] private SpriteRenderer _tutorial;
        //костыль
        [SerializeField] private List<Sprite> _tutorialImages;
        private EventBus _eventBus;

        public SpriteRenderer PlayerModel => _playerModel;
        public Animator Animator => _animator;
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }

        private void OnEnable()
        {
            _eventBus = ServiceLocator.Instance.Get<EventBus>();
            _eventBus.Subscribe<FlyUnlockedSignal>(ShowFlyButton);
            _eventBus.Subscribe<HideTutorialButtonSignal>(HideButton);
            _eventBus.Subscribe<ReversedGravityUnlockedSignal>(ShowReversedGravityButton);
            _eventBus.Subscribe<CrawlUnlockedSignal>(ShowCrawlButton);
        }

        private void OnDisable()
        {
            _eventBus.Unsubscribe<FlyUnlockedSignal>(ShowFlyButton);
            _eventBus.Unsubscribe<ReversedGravityUnlockedSignal>(ShowReversedGravityButton);
            _eventBus.Unsubscribe<CrawlUnlockedSignal>(ShowCrawlButton);
        }

        //Вся ебаторию с ивент басом здесь убрать, сделал к дедлайну костыли

        private void ShowFlyButton(FlyUnlockedSignal signal)
        {
            _tutorial.sprite = _tutorialImages[0];
        }

        private void ShowReversedGravityButton(ReversedGravityUnlockedSignal signal)
        {
            _tutorial.sprite = _tutorialImages[1];
        }

        private void HideButton(HideTutorialButtonSignal signal)
        {
            _tutorial.sprite = null;
        }

        private void ShowCrawlButton(CrawlUnlockedSignal signal)
        {
            _tutorial.sprite = _tutorialImages[2];
        }
    }
}