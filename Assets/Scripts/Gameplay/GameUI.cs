
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
    public Text inspectEnergy;
    public Button nextTurnButton;

    public GameObject playerTurnDisplay;

    public Text Co2eDisplay;
    public Text climateActionFund;
    public Text energyFund;
    
    public int turnNum;
    bool showingSecret;

    public GameObject flipInspectorButton;

    public void Start(){
        showingSecret = false;
        turnNum = 1;       
        gameScript = gameMaster.GetComponent<GameScript>();
        gameTimer = GameObject.Find("Timer");
        
        // Button btn = GameObject.Find("DrawBtn").GetComponent<Button>();
        // btn.onClick.AddListener(DrawCards);

        nextTurnButton = GameObject.Find("EndTurnBtn").GetComponent<Button>();
        nextTurnButton.onClick.AddListener(EndTurn);
        
        Button pausePlayerBtn = GameObject.Find("PlayBtn").GetComponent<Button>();
        pausePlayerBtn.onClick.AddListener(PausePlay);

        Button endRoundBtn = GameObject.Find("EndRoundBtn").GetComponent<Button>();
        endRoundBtn.onClick.AddListener(gameScript.EndRound);
                
        Button flipInspectorBtn = flipInspectorButton.GetComponent<Button>();
        flipInspectorBtn.onClick.AddListener(FlipInspector);
    }

    void DealCards(int numCards){
        // gameScript.DrawCards(this.transform, numCards, 10000000);
        gameScript.DrawCards(this.transform, numCards);
    }

    // void DrawCards(){
            
    //         string buttonName = this.name;
    //         Debug.Log ("You have clicked the " + buttonName + " button!");
    //         if(gameScript.cardDeck.Count >= 0){
    //             gameScript.DrawCards(this.transform, 1);

    //             //gameScript.currentPlayer.GetComponent<PlayerScript>().DrawCards(this.transform, 1);
    //             Debug.Log("Drew Cards...");
    //             nextTurnButton.interactable = false;  
    //         } else {
    //             Debug.Log("Out of cards! &*");
    //         }
	// }

    void EndTurn(){
        gameScript.EndTurn();
        //UpdateTurnDisplay();
        int numCards = (gameScript.roundNum == 1) ? 3 : 1;

        if(turnNum < gameScript.numPlayers){
            DealCards(numCards);
        }
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
        Debug.Log("here s " + cardDisp.energyText.text.ToString());
        //inspectEnergy.text = cardDisp.energyText.text.ToString();
        inspectEnergy = GameObject.Find("InspectorEnergy").GetComponent<Text>();
        inspectEnergy.text = cardDisp.energyText.text.ToString();

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

    public void UpdateTurnDisplay(){
        Text[] playerTurnTexts = playerTurnDisplay.GetComponentsInChildren<Text>();
        
        for(int i = 0; i < gameScript.numPlayers;i++){
            //GameObject playersTurnDisplay = bankDisplay.GetChild(i);
            playerTurnTexts[i].GetComponentInChildren<Text>().text = gameScript.playersList[i].gameObject.name; //+ ": " + gameScript.playersList[i].GetComponent<PlayerScript>().money.ToString("c");
            if(playerTurnTexts[i].text == gameScript.currentPlayer.ToString()){
                playerTurnDisplay.GetComponentInChildren<Image>().color = new Color32(255,255,225,100);
            } else {
                playerTurnDisplay.GetComponentInChildren<Image>().color = new Color32(255,255,225,0);
            }
        }

    }

    public void UpdateBank(){        
        climateActionFund.text = gameScript.climateFund.ToString("c");
        energyFund.text = gameScript.energy + " MWh";
    }

    // public void OnPointerClick(PointerEventData eventData) {
    //     if (eventData.name == Inspec) {
    //         FlipCard();
    //     }
    // }

    public void FlipInspector(){                

        GameObject currentCard = GameObject.Find("GameBoard").GetComponent<GameBoardScript>().currentCard;
        if(currentCard == null) {
            Debug.Log("currentCard = Nnull");
            return;
        }

        if(!showingSecret){
            inspectContent.text = currentCard.GetComponent<CardDisplay>().cardDescription;
            inspectTitle.enabled = true;
            inspectPrice.enabled = true;
            inspectEnergy.enabled = true;
            showingSecret = true;
        } else {
            inspectContent.text = currentCard.GetComponent<CardDisplay>().cardSecret;
            inspectTitle.enabled = false;
            inspectPrice.enabled = false;
            inspectEnergy.enabled = false;
            showingSecret = false;
        }
    }

    public void SetSecretStatus(bool secretStatus){
        showingSecret = secretStatus;
    }

}