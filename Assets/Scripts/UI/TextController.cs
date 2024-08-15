using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextAsset textAsset;  //Reference TextAsset
    public UIManager uiManager;  //UiManager of the Game



    /***Effect Parameters***/

    //For Typing Effect
    public float typingSpeed = 0.05f;



    //For Pulse Effect
    public float pulseDuration = 0.5f;
    public float pulseScale = 1.2f;


    //Store TextAsset Content
    private string[] lines;


    //Controlled UI text
    private TextMeshProUGUI uiText;


    void Awake()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        if(uiText == null)
        {
            Debug.Log("uitext not found");
        }
        // Automatically find and assign the UIManager
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

    }







    //Start the Emphasize Effect
    public void EmphasizeText()
    {
        StartCoroutine(PulseText());
    }


    // Start the typewriter effect
    public void StartTyping()
    {
        //Load TextAsset
        lines = textAsset.text.Split(new[] { "\r\n", "\r", "\n" }, System.StringSplitOptions.None);
        StartCoroutine(TypeStory());
    }


    //Coroutine for Enphasize
    private IEnumerator PulseText()
    {
        Vector3 originalScale = uiText.transform.localScale;
        Vector3 targetScale = originalScale * pulseScale;
        float timer = 0f;

        while (timer < pulseDuration)
        {
            timer += Time.deltaTime;
            uiText.transform.localScale = Vector3.Lerp(originalScale, targetScale, Mathf.PingPong(timer, pulseDuration / 2));
            yield return null;
        }

        uiText.transform.localScale = originalScale;
    }



    //Coroutine for TypeWriter
    IEnumerator TypeStory()
    {
        foreach (string line in lines)
        {
            for (int i = 0; i <= line.Length; i++)
            {
                uiText.text = line.Substring(0, i);

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

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));

        //change the scene state to "Select Gear"
        uiManager.TransitionToState(SceneState.SelectGear);
    }
}
