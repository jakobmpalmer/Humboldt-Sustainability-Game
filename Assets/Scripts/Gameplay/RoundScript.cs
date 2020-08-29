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

    public object[] doniverseCards, dontiverseCards;
    public List<UniverseCard> doniverseDeck, dontiverseDeck;

    // Start is called before the first frame update
    void Start()
    {
        roundShowing = true;
        gameScript = gameMaster.GetComponent<GameScript>();
        gameUIScript = gameUI.GetComponent<GameUI>();
        timerScript = gameTimer.GetComponent<TimerScript>();

        doniverseCards = Resources.LoadAll("Cards/Doniverse", typeof(UniverseCard));
        dontiverseCards = Resources.LoadAll("Cards/Dontiverse", typeof(UniverseCard));

        int doCount = 0;
        int dontCount = 0;
        foreach (UniverseCard card in doniverseCards){
            doniverseDeck.Add(card);
            doCount++;
            Debug.Log("loading card, " + doCount);
        }
        foreach (UniverseCard card in dontiverseCards){
            dontiverseDeck.Add(card);
            dontCount++;
        }
        Debug.Log("DoniverseCards:" + doCount);
        Debug.Log("DontiverseCards:" + dontCount);
        
    }

    public void SetRoundInfo(float moneySave, int num, float energySave){
        Debug.Log(savingsText.text + ",/,");
        //Debug.Log(gameScript.roundSavings.ToString("c"));
        // savingsText.text = "Savings: " + gameScript.roundSavings.ToString("c");
        savingsText.text = "Money Saved: " + moneySave.ToString("c");
        Debug.Log("energy save");
        energySavingText.text = "Energy Saved: " + energySave + " MWh";
        roundText.text = "Round " + (num);
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
            SetUniverseCards();
            universeDisplays.SetActive(true);
            roundShowing = false;
        } else {
            gameUIScript.UpdateBank();
            universeDisplays.SetActive(false);
            roundsCanva.SetActive(false);
            timerScript.SetTime(240f);
            timerScript.endOfRound = false;
            roundShowing = true;
        }
        
    }

    void SetUniverseCards(){
        GameObject doniverse = universeDisplays.transform.GetChild(0).gameObject;
        GameObject dontiverse = universeDisplays.transform.GetChild(1).gameObject;

        Text[] doTexts = doniverse.GetComponentsInChildren<Text>();
        Text[] dontTexts = dontiverse.GetComponentsInChildren<Text>();

        Text doTitle = doTexts[0];
        Text doContent = doTexts[1];

        Text dontTitle = dontTexts[0];
        Text dontContent = dontTexts[1];

        // Debug.Log("rNum : " + gameScript.roundNum);
        // Debug.Log("dontiverseYear: " + doniverseDeck[gameScript.roundNum].year.ToString());

        doTitle.text = "Year " + doniverseDeck[gameScript.roundNum - 1].year.ToString();
        doContent.text = doniverseDeck[gameScript.roundNum].content.Replace("<newline>", "\n\n");

        dontTitle.text = "Year " + dontiverseDeck[gameScript.roundNum - 1].year.ToString();
        dontContent.text = dontiverseDeck[gameScript.roundNum - 1].content.Replace("<newline>", "\n\n");
    }


}
