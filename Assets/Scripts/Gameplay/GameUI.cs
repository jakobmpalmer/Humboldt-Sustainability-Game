
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    GameObject gameMaster;
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

    public void Start(){
        gameMaster = GameObject.Find("GameMaster");
        gameTimer = GameObject.Find("Timer");
        // Button btn = this.GetComponent<Button>();
        Button btn = GameObject.Find("DrawBtn").GetComponent<Button>();
        Button nextTurnButton = GameObject.Find("EndTurnBtn").GetComponent<Button>();
        Button pausePlayerBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        btn.onClick.AddListener(DrawCards);
        nextTurnButton.onClick.AddListener(EndTurn);
        pausePlayerBtn.onClick.AddListener(PausePlay);

    }

    void DrawCards(){
            
            string buttonName = this.name;
            Debug.Log ("You have clicked the " + buttonName + " button!");
            
            gameMaster.GetComponent<GameScript>().DrawCards(this.transform, 1);
            //gameMaster.GetComponent<GameScript>().DrawCards(gameMaster.GetComponent<GameScript>().currentPlayer.transform.GetChild(0).gameObject.transform, 1);
            //gameMaster.GetComponent<GameScript>().DrawCards(this.transform, 1);
            Debug.Log("Drew Cards...");
            //gameMaster.GetComponent<GameScript>().SendToPlayerArea();  
	}

    void EndTurn(){
        gameMaster.GetComponent<GameScript>().EndTurn();
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

}