using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSetup : MonoBehaviour
{
    const int MAX_NUM_PLAYERS = 5;

    public GameObject[] players;

    GameObject setupCanva;
    GameObject setupPanel; 
    public Button[] buttons;
    GameObject playersGroup;




    int numPlayers;
    // Start is called before the first frame update
    void Start()
    {
        playersGroup = GameObject.Find("Players");
        setupCanva = GameObject.Find("GameSetupCanvas");
        setupCanva.SetActive(true);
        setupPanel = GameObject.Find("PlayerSetupPanel");
        setupPanel.SetActive(true);
        buttons = setupPanel.GetComponentsInChildren<Button>();
        // for (int i = 1; i < MAX_NUM_PLAYERS; i++)
        // {
        //     buttons[i].onClick.AddListener(() => SetPlayers(i));;
        //     Debug.Log("button " + i);            
        // }
        buttons[0].onClick.AddListener(SetPlayersOne);
        buttons[1].onClick.AddListener(SetPlayersTwo);
        buttons[2].onClick.AddListener(SetPlayersThree);
        buttons[3].onClick.AddListener(SetPlayersFour);
        buttons[4].onClick.AddListener(SetPlayersFive);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayersOne(){
        SetPlayers(1);
        GetComponent<GameScript>().numPlayers = 1;
        GetComponent<GameScript>().enabled = (true);
        setupCanva.SetActive(false);
        this.enabled = false;
    }
    void SetPlayersTwo(){
        SetPlayers(2);
        GetComponent<GameScript>().numPlayers = 2;
        GetComponent<GameScript>().enabled = (true);
        setupCanva.SetActive(false);
        this.enabled = false;
    }
    void SetPlayersThree(){
        SetPlayers(3);
        GetComponent<GameScript>().numPlayers = 3;
        GetComponent<GameScript>().enabled = (true);
        setupCanva.SetActive(false);
        this.enabled = false;
    }
    void SetPlayersFour(){
        SetPlayers(4);
        GetComponent<GameScript>().numPlayers = 4;
        GetComponent<GameScript>().enabled = (true);
        setupCanva.SetActive(false);
        this.enabled = false;
    }
    void SetPlayersFive(){
        SetPlayers(5);
        GetComponent<GameScript>().numPlayers = 5;
        GetComponent<GameScript>().enabled = (true);
        setupCanva.SetActive(false);
        this.enabled = false;
    }

    void SetPlayers(int numPlayers){
        int j;
        players = new GameObject[numPlayers];
        for (int i = 0; i < numPlayers; i++)
        {
            j = i+1;
            players[i] = new GameObject();
            players[i].name = "Player" + j;
            players[i].transform.SetParent(playersGroup.transform);
            players[i].AddComponent<PlayerScript>();
        }

    }

}
