using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntryPoints
{
    public class BootstrapEntryPoints : MonoBehaviour
    {
        private void Start()
        {
            //Show loading screen
            //Initializing some saves services etc.
            Debug.Log("Bootstrap scene initialized!");
            SceneManager.LoadScene(Scenes.MainMenu.ToString());
        }
    }
}
