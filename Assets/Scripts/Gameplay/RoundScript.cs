using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundScript : MonoBehaviour
{

    public Text roundText;
    public Text savingsText;
    public Text energySavingText;
    public GameObject gameMaster;
    GameScript gameScript;
    public GameObject gameUI;
    GameUI gameUIScript;

    public GameObject nextRoundPanel;
    public GameObject universeDisplays;
    public GameObject roundsCanva;
    bool roundShowing;

    public GameObject gameTimer;
    TimerScript timerScript;
    // Start is called before the first frame update
    void Start()
    {
        roundShowing = true;
        gameScript = gameMaster.GetComponent<GameScript>();
        gameUIScript = gameUI.GetComponent<GameUI>();
        timerScript = gameTimer.GetComponent<TimerScript>();
    }

    public void SetRoundInfo(float moneySave, int num, float energySave){
        Debug.Log(savingsText.text + ",/,");
        //Debug.Log(gameScript.roundSavings.ToString("c"));
        // savingsText.text = "Savings: " + gameScript.roundSavings.ToString("c");
        savingsText.text = "Money Saved: " + moneySave.ToString("c");
        Debug.Log("energy save");
        energySavingText.text = "Energy Saved: " + energySave + " MWh";
        roundText.text = "Round " + (num+1);
    }

    // Update is called once per frame
    void Update()
    {        
        // float startTime = Time.time;
        // while(Time.time < startTime + 5){
        //     Debug.Log("..");
        // }
        // gameObject.SetActive(false);

    }

    void OnMouseDown() {  

        Debug.Log("Clicked Round Panel!");

        if(roundShowing){
            nextRoundPanel.SetActive(false);
            universeDisplays.SetActive(true);
            roundShowing = false;
        } else {
            gameUIScript.UpdateBank();
            universeDisplays.SetActive(false);
            roundsCanva.SetActive(false);
            timerScript.SetTime(240f);
        }
        
    }
}
