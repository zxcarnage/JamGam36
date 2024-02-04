
using System.Collections;
using CustomServiceLocator;
using UI;
using UnityEngine;

namespace StateMachine.States.GameStates
{
    [CreateAssetMenu(fileName = "CandleRevealedDialogue", menuName = "State/GameState/Candle Revealed Dialogue", order = 0)]
    public class CandleRevealedDialogue : Cutscene
    {

        public override void CaptureInput()
        {
            if(Input.GetMouseButtonDown(0))
                if (!TryContinueStory())
                    _machine.SetState(typeof(BlackScreenState));
        }
    }
}