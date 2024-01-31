using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using UnityEngine;

namespace Command
{
    public class TutorialInputHandler : IService
    {
        private bool _flyUnlocked;

        public void UnlockFly(FlyUnlockedSignal flyUnlockedSignal)
        {
            _flyUnlocked = true;
        }

        public void HandleInput()
        {
            if(Input.GetButtonDown(KeyCode.Space.ToString()) && _flyUnlocked)
                ServiceLocator.Instance.Get<EventBus>().Invoke(typeof(FlyStarted));
        }
    }
}