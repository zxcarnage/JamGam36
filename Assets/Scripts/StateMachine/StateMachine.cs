using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private List<State<T>> _states;
        
        private State<T> _activeState;

        public void Init(Type entryStateType)
        {
            SetState(entryStateType);
        }

        public void SetState(Type newStateType)
        {
            if(_activeState != null)
                _activeState.Exit();
            _activeState = _states.First(s => s.GetType() == newStateType);
            _activeState.Enter(GetComponent<T>());
        }

        private void Update()
        {
            _activeState.CaptureInput();
            _activeState.Update();
            _activeState.TryChangeState();
        }

        private void FixedUpdate()
        {
            _activeState.FixedUpdate();
        }
    }
}

