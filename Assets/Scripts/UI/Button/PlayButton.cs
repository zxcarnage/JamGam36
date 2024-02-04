using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Button
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private UnityEngine.UI.Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(PlayButtonClicked);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PlayButtonClicked);
        }

        private void PlayButtonClicked()
        {
            SceneManager.LoadScene(Scenes.TutorialScene.ToString());
        }
    }
}