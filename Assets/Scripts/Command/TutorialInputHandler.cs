using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using UnityEngine;

namespace Command
{
    public class TutorialInputHandler : IService
    {
        private EventBus _eventBus;
        private bool _flyUnlocked;
        private bool _reverseUnlocked;
        private bool _crawlUnlocked;

        public TutorialInputHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void UnlockFly(FlyUnlockedSignal flyUnlockedSignal)
        {
            _flyUnlocked = true;
        }

        public void UnlockCrawl(CrawlUnlockedSignal crawlUnlockedSignal)
        {
            _crawlUnlocked = true;
        }

        public void UnlockGravity(ReversedGravityUnlockedSignal reversedGravityUnlockedSignal)
        {
            _reverseUnlocked = true;
        }

        public void HandleInput()
        {
            if(Input.GetKey(KeyCode.Space) && _flyUnlocked)
                _eventBus.Invoke(new FlyStarted());
            if(Input.GetMouseButtonDown(1) && _reverseUnlocked)
                _eventBus.Invoke(new ReverseGravitySignal());
            if(Input.GetKey(KeyCode.LeftShift) && _crawlUnlocked)
                if(Input.GetKey(KeyCode.D))
                    _eventBus.Invoke(new CrawlFrontSignal());
                else if (Input.GetKey(KeyCode.A))
                    _eventBus.Invoke(new CrawlBackSignal());
        }
    }
}