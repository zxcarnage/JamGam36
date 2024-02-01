using System;
using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using Triggers;
using UnityEngine;

namespace Player
{
    //Only for debug, change trigger handler to after cutscene trigger invoke
    public class PlayerTriggerHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out FlyUnlockTrigger flyUnlockTrigger))
                ServiceLocator.Instance.Get<EventBus>().Invoke(new FlyUnlockedSignal());
            if(col.TryGetComponent(out ReverseGravityUnlockTrigger reverseGravityUnlockTrigger))
                ServiceLocator.Instance.Get<EventBus>().Invoke(new ReversedGravityUnlockedSignal());
            if(col.TryGetComponent(out UnlockCrawlTrigger unlockCrawlTrigger))
                ServiceLocator.Instance.Get<EventBus>().Invoke(new CrawlUnlockedSignal());
        }
    }
}