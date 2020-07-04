
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
        btn.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick(){
            
            string buttonName = this.name;
            Debug.Log ("You have clicked the " + buttonName + " button!");
            
            gameMaster.GetComponent<GameScript>().DrawCards(this.transform, 1);
            Debug.Log("Drew Cards...");
            //gameMaster.GetComponent<GameScript>().SendToPlayerArea();  
	}

}