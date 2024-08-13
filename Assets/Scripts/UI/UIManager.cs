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


    public TypeWriterEffect typeWriter;
    private SceneState currentState;


    void Start()
    {
        currentState = SceneState.BackgroundStory;
        typeWriter.StartTyping();
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
        //To Do
    }

}
