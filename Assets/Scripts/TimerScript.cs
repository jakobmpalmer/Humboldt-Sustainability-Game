using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{


    float currentTime = 0f;
    float startingTime = 240f;

    public bool timesUp;
    public bool paused;

    public int min, sec;
    public string minutes, seconds;
    int timeIncrement;

    [SerializeField] Text countdownText;
    void Start()
    {
        paused = false;
        currentTime = startingTime;
    }

    void Update()
    {
        timeIncrement = paused ? 1 : 0;
        //currentTime -= 1 * Time.deltaTime;
        currentTime -= timeIncrement * Time.deltaTime;

        min = Mathf.FloorToInt(currentTime / 60);
        sec = Mathf.FloorToInt(currentTime % 60);

        if(min < 10){
            minutes = "0" + min.ToString();
        } else {
            minutes = min.ToString();
        }

        if(sec < 10) {
            seconds = "0" + sec.ToString();
        } else {
            seconds = sec.ToString();
        }

        //countdownText.text = Mathf.Round(currentTime).ToString();
        if(currentTime <= 0){
            //currentTime = 0;
            minutes = "00";
            seconds = "00";
            timesUp = true;
            countdownText.color = Color.red;
        } else if(currentTime <= 30){
            countdownText.color = Color.yellow;
        }

        countdownText.text = minutes + ":" + seconds;
    }

    public void ChangeTimer(){
        paused = paused ? false : true;
    }
}
