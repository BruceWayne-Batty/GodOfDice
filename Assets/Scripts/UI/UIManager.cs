using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    BackgroundStory,
    SelectGear,

}


public class UIManager : MonoBehaviour
{


    //Controlling Components
    public TypeWriterEffect typeWriter;

    //UI Components-Panel
    public GameObject BackgroundStorySet;
    public GameObject SelectionPanel;


    //UI Components-Message
    public GameObject MessagePanel_Bottom;


    //Use scene state to decide the state of corresponding UI component
    private SceneState currentState;


    void Start()
    {
        TransitionToState(SceneState.BackgroundStory);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SkipStory()
    {
        TransitionToState(SceneState.SelectGear);
    }

    public void TransitionToState(SceneState newState)
    {
        currentState = newState;
        Debug.Log("Transitioning to state: " + newState);

        // Handle state-specific logic here

        //Transition to story
        switch (currentState)
        {
            case(SceneState.BackgroundStory):
                BackgroundStorySet.SetActive(true);
                BackgroundStorySet.GetComponentInChildren<TextController>().StartTyping();
                break;

            case (SceneState.SelectGear):
                BackgroundStorySet.SetActive(false);
                SelectionPanel.SetActive(true);
                MessagePanel_Bottom.SetActive(true);
                break;


            default:
                Debug.Log("Unknown Scene State");
                break;

        }

        


    }

}
