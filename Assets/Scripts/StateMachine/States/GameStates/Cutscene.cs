using System.Collections.Generic;
using CustomEventBus;
using CustomEventBus.Signals;
using CustomServiceLocator;
using Ink.Runtime;
using StateMachine.StateMachines;
using UI;
using UnityEngine;

namespace StateMachine.States.GameStates
{
    public abstract class Cutscene : State<GameStateMachine>
    {
        [SerializeField] private TextAsset _dialogueJSON;
        [SerializeField] private Sprite _secondFaceImage;
        //Костыль
        [SerializeField] private bool _isTutorialStory;

        private DialogueWindow _dialogueWindow;
        private Story _currentStory;

        private const string SPEAKER_TAG = "speaker";

        public override void Enter(GameStateMachine parent)
        {
            base.Enter(parent);
            if (!_dialogueWindow) _dialogueWindow = ServiceLocator.Instance.Get<DialogueWindow>();
            EnterDialogue();
        }

        public override void CaptureInput()
        {
            if(Input.GetMouseButtonDown(0))
                if(!TryContinueStory())
                    _machine.SetState(_isTutorialStory? typeof(Tutorial) : typeof(MainGame));
        }

        public override void Update()
        {
        }

        public override void FixedUpdate()
        {
        }

        public override void TryChangeState()
        {
        }

        public override void Exit()
        {
            ExitDialogue();
        }

        private void ExitDialogue()
        {
            _dialogueWindow.gameObject.SetActive(false);
            ServiceLocator.Instance.Get<EventBus>().Invoke(new CutsceneEndedSignal());
        }

        private void EnterDialogue()
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new DialogueStartedSignal());
            _currentStory = new Story(_dialogueJSON.text);
            _dialogueWindow.gameObject.SetActive(true);
            _dialogueWindow.SetSecondPortrait(_secondFaceImage);
            TryContinueStory();
        }

        private bool TryContinueStory()
        {
            if (!_currentStory.canContinue)
                return false;
            var nextLine = _currentStory.Continue();
            HandleTags(_currentStory.currentTags);
            _dialogueWindow.ShowDialogueText(nextLine);
            return true;
        }

        private void HandleTags(List<string> currentTags)
        {
            foreach (string tag in currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    Debug.LogError("Tag could not be appropriately parsed: " + tag);
                }

                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey)
                {
                    case SPEAKER_TAG:
                        _dialogueWindow.ChangeFace(tagValue);
                        break;
                    default:
                        Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                        break;
                }
            }
        }
    }
}