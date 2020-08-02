
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public GameObject gameMaster;
    GameScript gameScript;
    GameObject gameTimer;
    //public Canvas gameCanvas;
    public GameObject[] playerCards;
    public GameObject[] players;
    public int startingCurrency;

    //public Card inspectCard;
    public Text inspectTitle;
    public Text inspectContent;
    public Text inspectPrice;
    public Text inspectDisp;
    public Button nextTurnButton;

    public GameObject bankDisplay;

    public Text Co2eDisplay;
    int turnNum;

    public void Start(){
        turnNum = 1;
        //gameMaster = GameObject.Find("GameMaster");
        gameScript = gameMaster.GetComponent<GameScript>();
        gameTimer = GameObject.Find("Timer");
        // Button btn = this.GetComponent<Button>();
        Button btn = GameObject.Find("DrawBtn").GetComponent<Button>();
        nextTurnButton = GameObject.Find("EndTurnBtn").GetComponent<Button>();
        Button pausePlayerBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        btn.onClick.AddListener(DrawCards);
        nextTurnButton.onClick.AddListener(EndTurn);
        pausePlayerBtn.onClick.AddListener(PausePlay);

    }

    void DealCards(int numCards){
        gameScript.DrawCards(this.transform, numCards);
    }

    void DrawCards(){
            
            string buttonName = this.name;
            Debug.Log ("You have clicked the " + buttonName + " button!");
            
            gameScript.DrawCards(this.transform, 1);
            //gameScript.currentPlayer.GetComponent<PlayerScript>().DrawCards(this.transform, 1);
            Debug.Log("Drew Cards...");
            nextTurnButton.interactable = false;  
	}

    void EndTurn(){
        gameScript.EndTurn();
        if(turnNum < gameScript.numPlayers){DealCards(3);}
        turnNum++;
    }

    void PausePlay(){
        gameTimer.GetComponent<TimerScript>().ChangeTimer();
    }

    public void UpdateInspector(GameObject inspectCard){
        CardDisplay cardDisp = inspectCard.GetComponent<CardDisplay>();
        //inspectTitle.enabled = true;
        inspectTitle.text = cardDisp.nameText.text.ToString();        
        //inspectContent.enabled = true;
        inspectContent.text = cardDisp.descriptionText.text.ToString();
        //inspectPrice.enabled = true;
        inspectPrice.text = cardDisp.priceText.text.ToString();
        inspectDisp.enabled = false;
    }

    public void UpdateInspectorUniverse(GameObject inspectCard){
        UniverseCardDisplay cardDisp = inspectCard.GetComponent<UniverseCardDisplay>();
        //inspectTitle.enabled = true;
        inspectTitle.text = cardDisp.titleText.text.ToString() + " " + cardDisp.yearText.text.ToString();        
        //inspectContent.enabled = true;
        inspectContent.text = cardDisp.descText.text.ToString();
        //inspectPrice.enabled = true;
        inspectPrice.text = " ";
        inspectDisp.enabled = false;
    }

    public void UpdateCo2e(){
        Co2eDisplay.text = gameScript.currentCo2e.ToString();
    }

    public void UpdateBank(){
        Text[] bankTexts = bankDisplay.GetComponentsInChildren<Text>();
        for(int i = 0; i < gameScript.numPlayers;i++){
            bankTexts[i].text = gameScript.playersList[i].GetComponent<PlayerScript>().money.ToString();
        }
    }

}