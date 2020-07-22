﻿using System.Collections;
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

    public GameObject namingPanel;
    public GameObject sessionNames;
    public GameObject playerEntry;
    public Button submitBtn;

    public GameObject bankArea;




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
        //namingPanel = GameObject.Find("NamingPanel");
        // for (int i = 1; i < MAX_NUM_PLAYERS; i++)
        // {
        //     buttons[i].onClick.AddListener(() => SetPlayers(i));;
        //     Debug.Log("button " + i);            
        // }
        buttons[0].onClick.AddListener(SetPlayersTwo);
        buttons[1].onClick.AddListener(SetPlayersThree);
        buttons[2].onClick.AddListener(SetPlayersFour);
        buttons[3].onClick.AddListener(SetPlayersFive);
        buttons[4].onClick.AddListener(SetPlayersSix);
        buttons[5].onClick.AddListener(SetPlayersSeven);
        buttons[6].onClick.AddListener(SetPlayersEight);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPlayersOne(){
        SetPlayers(1);
        GetComponent<GameScript>().numPlayers = 1;
        
        setupCanva.SetActive(false);
        this.enabled = false;
    }
    void SetPlayersTwo(){
        SetPlayers(2);
        GetComponent<GameScript>().numPlayers = 2;
        //setupCanva.SetActive(false);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        //this.enabled = false;
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(2);
    }
    void SetPlayersThree(){
        SetPlayers(3);
        GetComponent<GameScript>().numPlayers = 3;
        GetComponent<GameScript>().enabled = (true);
        //setupCanva.SetActive(false);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        //this.enabled = false;
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(3);
        
    }
    void SetPlayersFour(){
        SetPlayers(4);
        GetComponent<GameScript>().numPlayers = 4;
        GetComponent<GameScript>().enabled = (true);
        //setupCanva.SetActive(false);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        //this.enabled = false;
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(4);
    }
    void SetPlayersFive(){
        SetPlayers(5);
        GetComponent<GameScript>().numPlayers = 5;
        GetComponent<GameScript>().enabled = (true);
        //setupCanva.SetActive(false);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        //this.enabled = false;
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(5);
    }

    void SetPlayersSix(){
        SetPlayers(6);
        GetComponent<GameScript>().numPlayers = 6;
        GetComponent<GameScript>().enabled = (true);
        //setupCanva.SetActive(false);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        //this.enabled = false;
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(6);
    }

    void SetPlayersSeven(){
        SetPlayers(7);
        GetComponent<GameScript>().numPlayers = 7;
        GetComponent<GameScript>().enabled = (true);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(7);
    }

    void SetPlayersEight(){
        SetPlayers(8);
        GetComponent<GameScript>().numPlayers = 8;
        GetComponent<GameScript>().enabled = (true);
        setupPanel.SetActive(false);
        namingPanel.SetActive(true);
        submitBtn.onClick.AddListener(SubmitBtn);
        GetPlayerNames(8);
    }

    void SubmitBtn(){     
         Debug.Log("About to setup player names")    ;
         SetPlayerNames();
         Debug.Log("Set Player Names Complete.");
         GetComponent<GameScript>().enabled = (true);
         namingPanel.SetActive(false);
         Debug.Log("Set naming panel false Complete.");
         setupCanva.SetActive(false);
         Debug.Log("Set setup canva false Complete.");
         this.enabled = false;
    }

    void SetPlayers(int numPlayers){
        int j;
        players = new GameObject[numPlayers];
        Debug.Log("Setting Players");
        for (int i = 0; i < numPlayers; i++)
        {
            j = i+1;
            players[i] = new GameObject("Player" + j);
            Debug.Log("New Player " + i);
            players[i].transform.position = new Vector3 (0,0,0);
            players[i].transform.localScale = new Vector3(1,1,1);
            players[i].transform.SetParent(playersGroup.transform, false);
            players[i].AddComponent<PlayerScript>();
            GameObject deck = new GameObject("Deck");
            Debug.Log("New Deck " + i);
            deck.transform.SetParent(players[i].transform, false);
            //deck.transform.localScale = new Vector3(1,1,1);
            players[i].GetComponent<PlayerScript>().money = 10000000;            
        }
            GameObject.Find("Timer").GetComponent<TimerScript>().ChangeTimer();
            Debug.Log("Timer Begun");
    }

    void GetPlayerNames(int num){
        float yOff = playerEntry.GetComponent<RectTransform>().rect.height /2 + 25;//* namingPanel.GetComponentInParent<Canvas>().transform.localScale.y / 2;
        float xOff = namingPanel.transform.GetChild(0).GetComponent<RectTransform>().rect.width / 4;;
        bool offset = false;
        int j = 0;
        if(num >= 4){
            offset = true;
            namingPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(namingPanel.transform.GetChild(0).GetComponent<RectTransform>().rect.width + 150, namingPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y);
        }
        
        Vector3 spawnLoc;
        GameObject player;
        for (int i = 0; i < num; i++)
        {           
                //xOff = namingPanel.transform.GetChild(0).GetComponent<RectTransform>().rect.width / 4;
            
                //xOff = -1 * namingPanel.transform.GetChild(0).GetComponent<RectTransform>().rect.width / 4;
            


            if(offset){
                if(i > 4){
                    spawnLoc = new Vector3(namingPanel.transform.position.x + xOff, namingPanel.transform.position.y+ 85 - (yOff * j), namingPanel.transform.position.z);
                    j++;
                } else if(i == 4){
                    j = 0;
                    spawnLoc = new Vector3(namingPanel.transform.position.x + xOff, namingPanel.transform.position.y+ 85 - (yOff * j), namingPanel.transform.position.z);
                    j++;
                } else{
                    spawnLoc = new Vector3(namingPanel.transform.position.x - xOff, namingPanel.transform.position.y+ 85 - (yOff * j), namingPanel.transform.position.z);
                    j++;
                }

            } else {
                spawnLoc = new Vector3(namingPanel.transform.position.x, namingPanel.transform.position.y+ 85 - (yOff * i), namingPanel.transform.position.z);
            }

            
            int k = i+1;
            //player = Instantiate(playerEntry, spawnLoc, Quaternion.identity, namingPanel.transform);
            player = Instantiate(playerEntry, spawnLoc, Quaternion.identity, sessionNames.transform);
            player.GetComponentInChildren<Text>().text = "Player " + k + ": ";            
        }

    }

    void SetPlayerNames(){
        Debug.Log("Finding child components");
        //RectTransform[] playerNames = sessionNames.gameObject.GetComponents<RectTransform>();
        InputField[] playerNames = sessionNames.gameObject.GetComponentsInChildren<InputField>();
        Debug.Log("Got player Names.. " + playerNames.Length);
        for (int i = 0; i < playerNames.Length; i++)
        {   
            //Debug.Log("Setting player " + i+ " to " + playerNames[i].GetComponentInChildren<InputField>().text);
            //players[i].GetComponent<PlayerScript>().name = playerNames[i].GetComponent<InputField>().text;

            Debug.Log("Setting player " + i+ " to " + playerNames[i].text);
            players[i].GetComponent<PlayerScript>().name = playerNames[i].text;
            bankArea.transform.GetChild(i).GetComponent<Text>().text = players[i].name + ": " + players[i].GetComponent<PlayerScript>().money;
        }
    }

}
