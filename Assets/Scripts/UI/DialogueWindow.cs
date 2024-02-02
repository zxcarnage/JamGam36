using System;
using CustomServiceLocator;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DialogueWindow : MonoBehaviour, IService
    {
        [SerializeField] private TMP_Text _dialogueText;
        [SerializeField] private TMP_Text _dialogueFace;
        [SerializeField] private Image _secondFace;

        private void Start()
        {
            ServiceLocator.Instance.Register(this);
            gameObject.SetActive(false);
        }

        public void ShowDialogueText(string newText)
        {
            _dialogueText.text = newText;
        }

        public void ChangeFace(string newFace)
        {
            _dialogueFace.text = newFace;
        }

        public void SetSecondPortrait(Sprite secondFace)
        {
            if (!secondFace)
            {
                _secondFace.gameObject.SetActive(false);
                return;
            }
            _secondFace.sprite = secondFace;
        }
    }
}