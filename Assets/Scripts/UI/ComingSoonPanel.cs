using System;
using CustomServiceLocator;
using UnityEngine;

namespace UI
{
    public class ComingSoonPanel : MonoBehaviour, IService
    {
        private void Awake()
        {
            ServiceLocator.Instance.Register(this);
            gameObject.SetActive(false);
        }
    }
}