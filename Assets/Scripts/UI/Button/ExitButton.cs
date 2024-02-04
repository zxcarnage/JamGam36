using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Button
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(ExitButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ExitButtonClicked);
        }

        private void ExitButtonClicked()
        {
            Application.Quit();
        }
    }
}