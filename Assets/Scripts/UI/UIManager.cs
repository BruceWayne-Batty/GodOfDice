using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    BackgroundStory,
    GameStart,

}


public class UIManager : MonoBehaviour
{


    //Controlling Components
    public TypeWriterEffect typeWriter;

    //UI Components
    public GameObject BackgroundStory;

    private SceneState currentState;


    void Start()
    {
        TransitionToState(SceneState.BackgroundStory);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TransitionToState(SceneState newState)
    {
        currentState = newState;
        Debug.Log("Transitioning to state: " + newState);

        // Handle state-specific logic here

        //Transition to story
        if (currentState == SceneState.BackgroundStory)
        {
            BackgroundStory.SetActive(true);
            typeWriter.StartTyping();
        }


    }

}
