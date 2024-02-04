using UnityEngine;

namespace UI.Button
{
    public class CreditsButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;
        [SerializeField] private GameObject _creditsPanel;

        private void OnEnable()
        {
            _button.onClick.AddListener(CreditsButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CreditsButtonClicked);
        }

        private void CreditsButtonClicked()
        {
            _creditsPanel.SetActive(true);
        }
    }
}