using UnityEngine;

namespace StateMachine
{
    public abstract class State<T> : ScriptableObject where T : MonoBehaviour
    {
        protected T _machine;

        public virtual void Enter(T parent)
        {
            _machine = parent;
        }

        public abstract void CaptureInput();
        public abstract void Update();
        public abstract void FixedUpdate();
        public abstract void TryChangeState();
        public abstract void Exit();
    }
}