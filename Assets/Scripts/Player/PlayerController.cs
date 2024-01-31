using StateMachine;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(GroundCheck))]
    public class PlayerController : StateMachine<PlayerController>
    {
        
    }
}