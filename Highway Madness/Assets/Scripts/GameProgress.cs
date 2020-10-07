using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    //This script is for the progression slider inside of the ui.

    //Value on progress slider
    public float progress;
    //The slider
    public Slider slider;
    //Waittime between each slider movement
    public float waitTime;
    //How much gets added to slider value
    public float speed;
    //Gamestate script
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        //Get the slider component
        slider = GetComponent<Slider>();
        //Start the progression loop
        StartCoroutine(UpdateProgress());
    }

   
    //Update progress over time
    IEnumerator UpdateProgress()
    {
        //Slider reach max point = you win screen.
        if(progress >= 1)
        {
            gameState.SetWin();
        }
        //Certain value gets added to slider.
        else
        {
            progress += speed;
            slider.value = progress;   
        }
        //Wait certain time before function happens again.
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(UpdateProgress());
    }
}
