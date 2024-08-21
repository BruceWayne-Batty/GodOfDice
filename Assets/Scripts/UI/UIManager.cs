using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    BackgroundStory,
    SelectGear,
    MainGame,
}


public class UIManager : MonoBehaviour
{


    //Controlling Components
    public SelectionController selectionController;
    public GearPanelController gearPanelController;

    //UI Components-Panel
    public GameObject BackgroundStorySet;
    public GameObject SelectionSet;
    public GameObject MainBoardSet;

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

        //Transition to SceneState
        switch (currentState)
        {
            case(SceneState.BackgroundStory):
                BackgroundStorySet.SetActive(true);
                BackgroundStorySet.GetComponentInChildren<TextController>().StartTyping();
                break;

            case (SceneState.SelectGear):
                BackgroundStorySet.SetActive(false);
                SelectionSet.SetActive(true);
                selectionController.StartGameSelection();
                MessagePanel_Bottom.SetActive(true);
                break;

            case(SceneState.MainGame):
                SelectionSet.SetActive(false);
                MessagePanel_Bottom.SetActive(false);
                MainBoardSet.SetActive(true);
                gearPanelController.InitialPanel();
                break;

            
            default:
                Debug.Log("Unknown Scene State");
                break;

        }

        


    }


    /***Functions To Load Image***/
    public static Sprite LoadSprite(string path)
    {
        // Load the texture from the path
        Texture2D texture = LoadTexture(path);
        if (texture == null) return null;

        // Create a sprite from the texture
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public static Texture2D LoadTexture(string filePath)
    {
        // Load image file data into a byte array
        byte[] fileData;
        if (System.IO.File.Exists(filePath))
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(2, 2);
            if (tex.LoadImage(fileData))
            {
                return tex;
            }
        }
        return null;
    }
}
