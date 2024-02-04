using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine.States.GameStates
{
    [CreateAssetMenu(fileName = "EndOfTutorialDialogue", menuName = "State/GameState/End Of Tutorial Dialogue", order = 0)]
    public class EndOfTutorialDialogue : Cutscene
    {
        public override void Exit()
        {
            base.Exit();
            SceneManager.LoadScene(Scenes.MainGame.ToString());
        }
    }
}