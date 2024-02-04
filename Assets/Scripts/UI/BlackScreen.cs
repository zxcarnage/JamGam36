using System;
using CustomServiceLocator;
using UnityEngine;

namespace UI
{
    public class BlackScreen : MonoBehaviour, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
            gameObject.SetActive(false);
        }
    }
}