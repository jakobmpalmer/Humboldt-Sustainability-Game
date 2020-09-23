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
    public GameObject cardsPlayedPanel;
    public GameObject roundsCanva;
    bool roundShowing, cardsShowing;

    public GameObject gameTimer;
    TimerScript timerScript;

    public object[] doniverseCards, dontiverseCards;
    public List<UniverseCard> doniverseDeck, dontiverseDeck;

    public Text timerRoundTitle;

    public GameObject[] roundsCards;

    public bool cardsLeft;

    public GameObject moneyCardSpawn, noCardsText;

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

    public void GetRoundCards(){
        roundsCards = new GameObject[gameScript.thisRoundsCards.Count];
        gameScript.thisRoundsCards.CopyTo(roundsCards);
        gameScript.ResetRoundDeck();
    }

    public void SetRoundInfo(float moneySave, int num, float energySave){
        Debug.Log(savingsText.text + ",/,");
        //Debug.Log(gameScript.roundSavings.ToString("c"));
        // savingsText.text = "Savings: " + gameScript.roundSavings.ToString("c");
        savingsText.text = "Money Saved: " + moneySave.ToString("c");
        Debug.Log("energy save");
        energySavingText.text = "Energy Saved: " + energySave + " MWh";
        roundText.text = "Round " + (num);
        timerRoundTitle.text = "Round " + num + " Timer";
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
            cardsPlayedPanel.SetActive(true);            
            // gameScript.EndTurn();
            // gameUIScript.turnNum = 1;
            GetRoundCards();
            if(roundsCards.Length == 0){
                noCardsText.SetActive(true);
            } else {
                SpawnMoneyCards();
            }
            roundShowing = false;
            cardsShowing = true;
        } else if(cardsShowing){
        // } else if(cardsShowing && cardsLeft){
            cardsPlayedPanel.SetActive(false);
            noCardsText.SetActive(false);
            SetUniverseCards();
            universeDisplays.SetActive(true);
            timerScript.SetTime(240f);
            cardsShowing = false;
        } else {
            gameUIScript.UpdateBank();
            universeDisplays.SetActive(false);
            roundsCanva.SetActive(false);            
            timerScript.TimerPlay();
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

    public void SpawnMoneyCards(){
        int j = 0;
        for(int i = 0; i < roundsCards.Length; i++){   

            if(i == 3 || i == 7){
                j++;
            }   
            
            GameObject cardPrefab = Instantiate(gameScript.cardTemplate, new Vector3(moneyCardSpawn.GetComponent<RectTransform>().anchoredPosition.x + ((i * gameScript.cardTemplate.GetComponent<RectTransform>().sizeDelta.x) + 50), 
                                                                                        moneyCardSpawn.GetComponent<RectTransform>().anchoredPosition.y - (j * gameScript.cardTemplate.GetComponent<RectTransform>().sizeDelta.y),
                                                                                        0), Quaternion.identity);
                                    Debug.Log("Spawning Money cards @: " + moneyCardSpawn.GetComponent<RectTransform>().anchoredPosition.x + ", " + moneyCardSpawn.GetComponent<RectTransform>().anchoredPosition.y);
            cardPrefab.transform.SetParent(cardsPlayedPanel.transform, false); // Parents card to gameUI to make it visible on spawn.
            
            cardPrefab.GetComponent<CardDisplay>().card = roundsCards[i].GetComponent<CardDisplay>().card;
            cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
            cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
            cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
            cardPrefab.GetComponent<CardDisplay>().energyText = cardPrefab.GetComponentsInChildren<Text>()[3];
            
            Destroy(cardPrefab.GetComponent<CardHover>());
            cardPrefab.AddComponent<MoneyHover>();
        }
    }


}
