using System;
using UnityEngine;

namespace Triggers
{
    public class EndTutorialTrigger : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D other)
        {
            gameObject.SetActive(false);
        }
    }
}