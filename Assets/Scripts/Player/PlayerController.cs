using System;
using CustomServiceLocator;
using StateMachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerTriggerHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(GroundCheck))]
    public class PlayerController : StateMachine<PlayerController>, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }
    }
}