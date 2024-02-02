using System;
using UnityEngine;

namespace Player
{
    //Костыль
    public class SpriteDirectionSwapper : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _model;

        private void Update()
        {
            _model.flipX = Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A) && _model.flipX;
        }
    }
}