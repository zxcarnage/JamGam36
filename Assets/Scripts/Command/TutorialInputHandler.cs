﻿using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using UnityEngine;

namespace Command
{
    public class TutorialInputHandler : IService
    {
        private bool _flyUnlocked;
        private bool _reverseUnlocked;

        public void UnlockFly(FlyUnlockedSignal flyUnlockedSignal)
        {
            _flyUnlocked = true;
        }

        public void UnlockGravity(ReversedGravityUnlockedSignal reversedGravityUnlockedSignal)
        {
            _reverseUnlocked = true;
        }

        public void HandleInput()
        {
            if(Input.GetKey(KeyCode.Space) && _flyUnlocked)
                ServiceLocator.Instance.Get<EventBus>().Invoke(new FlyStarted());
            if(Input.GetMouseButtonDown(1) && _reverseUnlocked)
                ServiceLocator.Instance.Get<EventBus>().Invoke(new ReverseGravitySignal());
        }
    }
}