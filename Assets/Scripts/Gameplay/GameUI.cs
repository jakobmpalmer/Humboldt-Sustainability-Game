
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    GameObject gameMaster;
    //public Canvas gameCanvas;
    public GameObject[] playerCards;
    public GameObject[] players;
    public int startingCurrency;

    public void Start(){
        gameMaster = GameObject.Find("GameMaster");
        // Button btn = this.GetComponent<Button>();
        Button btn = GameObject.Find("DrawBtn").GetComponent<Button>();
        Button nextTurnButton = GameObject.Find("EndTurnBtn").GetComponent<Button>();
        btn.onClick.AddListener(DrawCards);
        nextTurnButton.onClick.AddListener(EndTurn);

    }

    void DrawCards(){
            
            string buttonName = this.name;
            Debug.Log ("You have clicked the " + buttonName + " button!");
            
            //gameMaster.GetComponent<GameScript>().DrawCards(this.transform, 1);
            gameMaster.GetComponent<GameScript>().DrawCards(this.transform, 1);
            Debug.Log("Drew Cards...");
            //gameMaster.GetComponent<GameScript>().SendToPlayerArea();  
	}

    void EndTurn(){
        gameMaster.GetComponent<GameScript>().EndTurn();
    }

}