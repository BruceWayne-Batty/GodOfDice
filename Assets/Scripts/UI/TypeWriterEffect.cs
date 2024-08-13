using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public TextMeshProUGUI storyText;       // UI Text component to display the story
    public TextAsset textAsset;
    public UIManager uiManager;


    public float typingSpeed = 0.05f;  // Speed of typing (in seconds per character)
    //public float commaPauseDuration = 0.5f; // Duration of the pause for commas
    //public float PauseDuration = 1.0f; //Duration of the pause of dots

    private string[] lines;      // Array to hold each line from the text file
                                 //private bool isSkipping = false;    // Flag to check if the player is skipping
                                 //private bool effectEnd = false;


    void Awake()
    {
        // Automatically find and assign the UIManager
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }
    }

    public void Start()
    {
        //load the text
        lines = textAsset.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
    }


    public void StartTyping()
    {
        // Start the typewriter effect
        StartCoroutine(TypeStory());
    }


    IEnumerator TypeStory()
    {
        foreach (string line in lines)
        {
            for (int i = 0; i <= line.Length; i++)
            {
                storyText.text = line.Substring(0, i);

                // Skip the typing effect if the player presses the spacebar
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    Debug.Log("BUTTON pressed");
                //    storyText.text = line;
                //    break;
                //}

                //if (line[i] == ',')
                //{
                //    yield return new WaitForSeconds(commaPauseDuration);
                //}
                //else if (line[i] == '.')
                //{
                //    yield return new WaitForSeconds(commaPauseDuration);
                //}
                yield return new WaitForSeconds(typingSpeed);
            }

            // Wait for the player to press a key before showing the next line
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
        }

        uiManager.TransitionToState(SceneState.GameStart);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
        storyText.enabled = false;
    }
}
