using System;
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

        public SpriteRenderer PlayerModel => _playerModel;
        
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
        }
    }
}