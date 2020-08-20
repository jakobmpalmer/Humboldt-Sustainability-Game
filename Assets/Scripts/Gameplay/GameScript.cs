using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScript : MonoBehaviour
{

    //public Card cardObject;
    //public GreenCard[] cardDeck;
    public List<Card> cardDeck;
    
    public GameObject cardTemplate;
    private GameObject cardPrefab;
    
    public Canvas mainCanvas;

    public GameObject playerArea;

    public List<GameObject> playerDeck;

    public int numPlayers;

    GameSetup gameSetupScript;
    
    public GameObject players;
    public GameObject[] playersList;

    public GameObject currentPlayer;
    public int nextPlayerNum;

    public GameObject bankArea;

    //bool DEBUG = true;
    public float energy;

    public float currentCo2e;

    public float roundSavings;
    public float energySavings;

    public float winningCo2e = 590000;
    public float climateFund;
    public GameObject gameUIObject;
    GameUI gameUI;

    public int roundNum;

    public GameObject gameTimer;
    public GameObject roundCanvas;
    TimerScript timerScript;
    bool allCardsLoaded;

    void Start()
    {
        climateFund = 10000000f;
        roundSavings = 0f;
        energySavings = 0f;
        roundNum = 1;
        allCardsLoaded = false;
        //(DEBUG) : Debug.Log("") ? "NO DEBUG";
        currentCo2e = 590000f;
        
        //DrawCards(mainCanvas.transform, 2);
        playerDeck = new List<GameObject>();
        //LoadResources();
        players = GameObject.Find("Players");
        currentPlayer = players.transform.GetChild(0).gameObject;
        playersList = new GameObject[numPlayers];
        for (int i = 0; i < numPlayers; i++)
        {
            playersList[i] = players.transform.GetChild(i).gameObject;            
            //bankArea.transform.GetChild(i).GetComponent<Text>().text = playersList[i].GetComponent<PlayerScript>().name;
        }
        Debug.Log("Setting currentplayer..");
        currentPlayer = playersList[0];      
        Debug.Log("Set currentplayer!");  
        currentPlayer.GetComponent<PlayerScript>().canPlay = true;
        nextPlayerNum = 1;     

        LoadGreenBlue();
        Debug.Log("Resources Loaded");


        gameUI = gameUIObject.GetComponent<GameUI>();
        gameUI.UpdateCo2e();
        gameUI.UpdateBank();
        
        


        // DrawCards(currentPlayer.transform, 3);
        // //GameObject.Find("Timer").GetComponent<TimerScript>().ChangeTimer();
        timerScript = gameTimer.GetComponent<TimerScript>();
        // timerScript.ChangeTimer();
        // Debug.Log("Timer Begun");   
    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void DealCards(){
    //     for(int i = 0; i < numPlayers; i++){
            
    //     }
    // }

//Invoked on button click
    public void DrawCards(Transform newParent, int num){

        if(cardDeck.Count <= 0){
          if(!allCardsLoaded){
            LoadOrangePink();
            allCardsLoaded = true;
          } else {
              Debug.Log("out of cards!!");
              return;
          }
            
        } 

        if(currentPlayer == null){
            currentPlayer = players.transform.GetChild(0).gameObject;
        }


        for (int i = 0; i < num; i++)
        {
            //New Card choice
            int rand = Random.Range(0, cardDeck.Count - 1);
            Debug.Log("your random: " + rand);
            
            cardPrefab = Instantiate(cardTemplate, new Vector3(i * 200.0F, i * -25, 0), Quaternion.identity);
            cardPrefab.transform.SetParent(newParent, false); // Parents card to gameUI to make it visible on spawn.
            
            cardPrefab.GetComponent<CardDisplay>().card = cardDeck[rand];
            cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
            cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
            cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
            cardPrefab.GetComponent<CardDisplay>().energyText = cardPrefab.GetComponentsInChildren<Text>()[3];
            //Debug.Log("GS energyText crteated: " + cardPrefab.GetComponent<CardDisplay>().energyText.text.ToString());
            //cardPrefab.GetComponent<CardDisplay>().cardType = gameObject.cardType;

            //cardDeck = RemoveCards(cardDeck, rand);
            //playerDeck.Add(cardPrefab);
            
            currentPlayer.GetComponent<PlayerScript>().playerDeck.Add(cardPrefab);
            cardDeck.RemoveAt(rand);

            //cardPrefab.transform.SetParent(currentPlayer.transform.GetChild(0), true);
           
            // IEnumerator coroutine = MoveObject(cardPrefab, 1.0f);
            // StartCoroutine(coroutine);
            // coroutine = StackObject(cardPrefab, 1.0f);
            // StartCoroutine(coroutine);
            GameObject destRow;
            int currentDeckSize = currentPlayer.GetComponent<PlayerScript>().playerDeck.Count;
            if(currentDeckSize < 3){
                destRow = GameObject.Find("DeckRowOne");
                Debug.Log("<4 CardDeckCount: " + currentDeckSize);
            } else if (currentDeckSize < 6) {
                destRow = GameObject.Find("DeckRowTwo");
                Debug.Log("<8 CardDeckCount: " + currentDeckSize);
            } else {
                destRow = GameObject.Find("DeckRowThree");
                Debug.Log("ELSE CardDeckCount: " + currentDeckSize);
            }
            cardPrefab.GetComponent<CardDisplay>().MoveAndStack(cardPrefab, destRow, currentDeckSize);
        }   
    }

    void DrawDotiverse(){

    }

    void DrawDontiverse(){

    }

    public void ReduceCo2e(float reduction){
        currentCo2e -= reduction;
        gameUI.UpdateCo2e();
    }

    public void LoadResources(){
        object[] greenCards = Resources.LoadAll(("Cards/Green"), typeof(Card));
        object[] blueCards = Resources.LoadAll(("Cards/Blue"), typeof(Card));
        object[] orangeCards = Resources.LoadAll(("Cards/Orange"), typeof(Card));
        object[] pinkCards = Resources.LoadAll(("Cards/Pink"), typeof(Card));
        int count = 0;

        foreach (Card card in greenCards){
            count++;
            cardDeck.Add(card);
        }
        //Debug.Log("Count after green: " + count);

        foreach (Card card in blueCards){
            count++;
            cardDeck.Add(card);
        }
        //Debug.Log("Count after blue: " + count);

        foreach (Card card in orangeCards){
            count++;
            cardDeck.Add(card);
        }
        //Debug.Log("Count after orange: " + count);

        foreach (Card card in pinkCards){
            count++;
            cardDeck.Add(card);
        }
        //Debug.Log("Count after pink: " + count);
    }

    void LoadGreenBlue(){
        object[] greenCards = Resources.LoadAll(("Cards/Green"), typeof(Card));
        object[] blueCards = Resources.LoadAll(("Cards/Blue"), typeof(Card));

        foreach (Card card in greenCards){
            cardDeck.Add(card);
        }

        foreach (Card card in blueCards){
            cardDeck.Add(card);
        }
    }

    void LoadOrangePink(){
        object[] orangeCards = Resources.LoadAll(("Cards/Orange"), typeof(Card));
        object[] pinkCards = Resources.LoadAll(("Cards/Pink"), typeof(Card));

        foreach (Card card in orangeCards){
            cardDeck.Add(card);
        }

        foreach (Card card in pinkCards){
            cardDeck.Add(card);
        }
    }

    public void EndTurn(){
        Debug.Log("Chosing player" + nextPlayerNum);
        currentPlayer.transform.GetChild(0).gameObject.SetActive(false);
        currentPlayer = playersList[nextPlayerNum];
        currentPlayer.transform.GetChild(0).gameObject.SetActive(true);
        if(nextPlayerNum == numPlayers-1){
            nextPlayerNum = 0;
        } else {
            nextPlayerNum++;
        }
        Debug.Log("Next Player num " + nextPlayerNum);


        //GameObject.Find("GameMaster").GetComponent<GameScript>().ShowErrorMessage("Not Enough Resources!", 1.0f);        
        ShowSlideMessage(currentPlayer.name + "'s Turn!", "PlayerTurnTitle", "PlayerTitleDest", 1.0f);
        IEnumerator playerTurnCoroutine = ShowPlayerTurn(2);
        StartCoroutine(playerTurnCoroutine);
    }


//         ShowSlideMessage(currentPlayer.name + "'s Turn!", "PlayerTurnTitle", "PlayerTitleDest", 1.0f);
//         IEnumerator playerTurnCoroutine = ShowPlayerTurn(2);
//         StartCoroutine(playerTurnCoroutine);
    public void ShowErrorMessage(string message, float overTime){
        IEnumerator coroutine = SlideMessage(message, GameObject.Find("ErrorMessage"), GameObject.Find("ErrorDestination"), overTime);
        StartCoroutine(coroutine);
    }

    public void ShowSlideMessage(string message, string msgObj, string dest, float overTime){
        IEnumerator coroutine = SlideMessage(message, GameObject.Find(msgObj), GameObject.Find(dest), overTime);
        StartCoroutine(coroutine);
    }

    

    public void NextRound(){
        roundCanvas.SetActive(true); 
        roundCanvas.GetComponent<RoundScript>().SetRoundInfo(roundSavings, roundNum, energySavings);
        energy += energySavings;
        climateFund += roundSavings;
        timerScript.paused = true;
        //timerScript.SetTime(240f);
    }

    public void EndRound(){
        timerScript.SetTime(3f);
    }

    IEnumerator ShowPlayerTurn(float showFor)
    //IEnumerator MoveObject(GameObject source, GameObject destination, float overTime, int numCards)
    {
        Image playerTurnTitle = GameObject.Find("PlayerTurnTitle").GetComponent<Image>();
        Text playerTurnText = GameObject.Find("PlayerTurnText").GetComponent<Text>();
        //Vector3 destPos = destination.transform.position;
        playerTurnTitle.enabled = (true);
        playerTurnText.enabled = true;
        playerTurnText.text = currentPlayer.name + "'s Turn!";
        yield return new WaitForSeconds(showFor);
        playerTurnText.enabled = false;
        playerTurnTitle.enabled = (false); 
        
    }


    IEnumerator SlideMessage(string message, GameObject messageObj, GameObject target, float overTime){
        messageObj.GetComponent<Image>().enabled = true;
        messageObj.GetComponentInChildren<Text>().enabled = true;
        //messageObj.SetActive(true);
        //Vector3 destPos = destination.transform.position;
        Vector3 sourcePos = messageObj.GetComponent<RectTransform>().position;
        messageObj.GetComponentInChildren<Text>().text = message;
        Debug.Log("Message showing");
        
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {            
            messageObj.transform.position = Vector3.Lerp(messageObj.GetComponent<RectTransform>().position, target.transform.position, (Time.time - startTime)/overTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        // startTime = Time.time;
        // while(Time.time < startTime + overTime)
        // {            
        //     messageObj.transform.position = Vector3.Lerp(messageObj.GetComponent<RectTransform>().position, sourcePos, (Time.time - startTime)/overTime);
        //     yield return null;
        // }

        //messageObj.SetActive(false);
        messageObj.GetComponent<Image>().enabled = false;
        messageObj.GetComponentInChildren<Text>().enabled = false;
        //messageObj.transform.position = sourcePos;
        Debug.Log("DoNE");

    }




}
