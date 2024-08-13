using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "GameScene" with the name of your game scene
        SceneManager.LoadScene("MainGame");
    }

    public void ExitGame()
    {
        // This will only work in a built application, not in the editor
        Application.Quit();

        // If running in the Unity editor, log a message
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}