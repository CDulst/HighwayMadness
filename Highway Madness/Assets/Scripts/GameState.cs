using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    //Could have been a lot cleaner but, timeconstraints

    //check gamestate activity
    public bool StartScreen = true;
    public bool GameScene;
    public bool GameOver;
    public bool WinScene;
    //check if hit or won
    public bool Hit;
    public bool Won;
    //player en spawner objects that need to change behaviour based on gamestate
    public GameObject player;
    public GameObject enemySpawner;
    //the scene
    public Scene currentScene;
    //the ui
    public GameObject ui;
    //List with all the different UI canvases
    public List<GameObject> uiStates;
    //Player controller and audio. behaviour needs to change on gamestate
    public PlayerController playerController;
    public PlayerAudio playerAudio;




    // Start is called before the first frame update
    void Start()
    {
        //Get the current scene
        currentScene = SceneManager.GetActiveScene();
        //Get the components
        playerController = player.GetComponent<PlayerController>();
        playerAudio = player.GetComponent<PlayerAudio>();

     // Put all the different ui canvased that are children from the ui and put them in a list.
     foreach(Transform child in ui.transform)
        {
            Debug.Log(child.gameObject);
            uiStates.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if hit set gamestate as gameover
        if (Hit)
        {
            uiStates[2].SetActive(false);
            uiStates[1].SetActive(true);
            playerAudio.Crash();
            Hit = false;
        }
        // if hit set gamestate as won
        if (Won)
        {
            uiStates[2].SetActive(false);
            uiStates[3].SetActive(true);
            enemySpawner.SetActive(false);
            playerAudio.gameObject.SetActive(false);
            playerController.SetControlable(false);
        }
        //Check if space is checked
        if (Input.GetKey(KeyCode.Space))
        {
            //Space on starscreen starts game
            if (StartScreen)
            {
                uiStates[0].SetActive(false);
                uiStates[2].SetActive(true);
                StartScreen = false;
                GameScene = true;
                enemySpawner.SetActive(true);
                playerAudio.SetAudio();
                playerController.SetControlable(true);
            }
            //Space on gameover resets game.
            if (GameOver)
            {
                uiStates[1].SetActive(false);
                SceneManager.LoadScene(currentScene.name);
            }
            //Space on won resets game
            if (Won)
            {
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }

    //Gets called when collision, activates gameover state game.
    public void SetHit()
    {
        GameOver = true;
        Hit = true;
        GameScene = false;

    }

    //Gets called when progression complete, Activates win state.

    public void SetWin()
    {
        WinScene = true;
        Won = true;
        GameScene = false;
    }
}
