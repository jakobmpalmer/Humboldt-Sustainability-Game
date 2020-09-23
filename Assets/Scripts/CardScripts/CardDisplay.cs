using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;
    private int cardType;
    public Text nameText;
    public Text descriptionText;
    public Text priceText;
    public Text secretText;
    public Text energyText;

    public bool selected;
    float cardPrice, cardSavings;
    float energyCost;
    bool canPlay;
    public string cardSecret;
    public string cardDescription;
    public GameObject gameMaster;
    GameScript gameScript;
    public GameBoardScript gameBoardScpt;

    GameObject gameBoard;
    // Start is called before the first frame update
    void Start()
    {
        gameBoard = GameObject.Find("GameBoard");
        gameBoardScpt = gameBoard.GetComponent<GameBoardScript>();
        Debug.Log("-->> " + gameBoardScpt.cardStacked);
        //energyText = GameObject.Find("InspectorEnergy").GetComponent<Text>();
        cardPrice = card.price;
        cardSavings = (card.savesInMil * 1000000f );
        energyCost = card.energy;
        cardDescription = card.description.Replace("<newline>", "\n");
        Debug.Log("67 energycost" + energyCost);
        //this.gameObject.image.color = new Color32(255,255,255,0);
        nameText.text = card.cardName;
        descriptionText.text = cardDescription;
        //descriptionText.text = descriptionText.text.Replace("<tab>", "\t");
        priceText.text = cardPrice.ToString("c");
        energyText.text = energyCost + " Mwh";
        cardType = card.cardType;

        cardSecret = card.secret.Replace("<newline>", "\n");
        gameMaster = GameObject.Find("GameMaster");
        gameScript = gameMaster.GetComponent<GameScript>();
        //secretText.text = card.secret;
        
        switch (cardType)
        {
            case 1: // if cardType == 1
                    GetComponent<Image>().color = Color.blue;
                    Text[] cardText = GetComponentsInChildren<Text> ();
                    foreach(Text text in cardText){
                            text.color = Color.white;
                    }
                    Debug.Log("Card is blue!");
                    break;
            case 2: // if cardType == 2
                    GetComponent<Image>().color = new Color(255, 0, 181, 1);
                    Debug.Log("Card is Pink!");
                    break;
            case 3: // if cardType == 3
                    GetComponent<Image>().color = new Color(255, 128, 0, 1);
                    Debug.Log("Card is orange!");
                    break;
            case 0: // if cardType != (1,2,3)
                    GetComponent<Image>().color = Color.green;
                    Debug.Log("Card is Green!");
                    break;
        }
    }

    public bool CanPlay()
    {
        float playerMoney = gameScript.climateFund;//.currentPlayer.GetComponent<PlayerScript>().money;
        float gameEnergy = gameScript.energy;

        if(CheckMoney(playerMoney)){
            if(CheckEnergy(gameEnergy)){                
                return true;
            } else {print("Cant, energy too low");}
        }else {print("Cant, money too low");}
        return false;
    }

    bool CheckMoney(float thisMoney){
        //float playerMoney = GetComponentInParent<PlayerScript>().money;
        if((thisMoney >= cardPrice) ){
                Debug.Log("MoneyUpdate: " + thisMoney + " - " + cardPrice + " = " + (thisMoney - cardPrice));
                //playerMoney -= cardPrice;
                //totalEnergy -= energyCost;                
                return true;
        }
        Debug.Log("MONEY BREAK ->->->: " + thisMoney + " - " + cardPrice + " = " + (thisMoney - cardPrice));
        return false;
    }
    bool CheckEnergy(float thisEnergy){
        
        if((thisEnergy >= energyCost) ){
                Debug.Log("EnergyUpdate: " + thisEnergy + " - " + energyCost + " = " + (thisEnergy - energyCost));
                //gameEnergy -= energyCost;
                //totalEnergy -= energyCost;                
                return true;
        }
        Debug.Log("ENERGY BREAK->->->: " + thisEnergy + " - " + energyCost + " = " + (thisEnergy - energyCost));
        return false;
    }

    public void SubtractResources(){
        gameScript.energy -= energyCost;
        gameScript.climateFund -= cardPrice;
        //GetComponentInParent<PlayerScript>().money -= cardPrice;
    }
    public void UpdateResources(){
        //gameScript.energy -= energyCost;
        gameScript.climateFund -= cardPrice;

        gameScript.roundSavings += cardSavings;
        gameScript.energySavings += energyCost;
        //GetComponentInParent<PlayerScript>().money -= cardPrice;
    }

    public void PlayCard(){     
        gameBoardScpt = GameObject.Find("GameBoard").GetComponent<GameBoardScript>();   
        if(gameBoardScpt.cardStacked){
            gameBoardScpt.cardStacked = false;
            ResizeThisCard(3.0f);
            //MoveOverTime(gameObject, gameBoardScpt.lastPlayed, 3.0f);
            this.transform.SetParent(gameBoard.transform, false);
            StackOnBoard(gameObject, gameBoardScpt.lastPlayed, 1.0f);
            gameScript.ReduceCo2e(card.co2e);
            gameScript.AddCardToRoundDeck(this.gameObject);
            //Debug.Log("Reduced by " + card.co2e);
        } else {
            Debug.Log("Problem!Problem!");
            this.transform.position = GetComponent<CardHover>().startingPos;
        }
    }



    public void MoveAndStack(GameObject cardPrefab, GameObject playArea, int currentDeckSize){

        IEnumerator coroutine = MoveObject(cardPrefab, playArea, 1.0f);
        StartCoroutine(coroutine);
        //coroutine = StackObject(cardPrefab, playArea, 0.5f);
        coroutine = DeckStack(cardPrefab, playArea, 0.5f, currentDeckSize);
        StartCoroutine(coroutine);        
    }


     IEnumerator DeckStack(GameObject source, GameObject dest, float overTime, int currentSize)
    {
        yield return new WaitForSeconds(2);
        source.transform.SetParent(dest.transform, false);
        Vector3 sourcePos = source.GetComponent<RectTransform>().position;
        Vector3 destPos = dest.GetComponent<RectTransform>().position;

        float sourceWidth = source.GetComponent<RectTransform>().sizeDelta.x;
        float destWidth = dest.GetComponent<RectTransform>().sizeDelta.x;
        //Debug.Log("Width:: " + destWidth);

        //Debug.Log("MODD" + currentSize % 3);
        int currentMod = currentSize % 3;
        float xOff = currentMod * sourceWidth / 1.5f;

        destPos = new Vector3(destPos.x + ((destWidth / 2) - (sourceWidth / 2) - xOff),
                                destPos.y,
                                destPos.z);
        
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
            
            //source.transform.position = Vector3.Lerp(sourcePos, new Vector3(destPos.x, destPos.y, destPos.z), (Time.time - startTime)/overTime);      
            source.transform.localPosition = Vector3.Lerp(source.GetComponent<RectTransform>().position, -1 *destPos, (Time.time - startTime)/overTime);      
            //transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
            GameObject.Find("GameUI").GetComponent<GameUI>().nextTurnButton.interactable = false;  
            yield return null;
            //yield return new WaitForSeconds(1);
        }
        source.transform.SetParent(gameScript.currentPlayer.transform.GetChild(0), true);
        //source.transform.SetParent(gameScript.currentPlayer.transform, true);

        //Debug.Log("Setting interactable true");
        GameObject.Find("GameUI").GetComponent<GameUI>().nextTurnButton.interactable = true;  
        //Debug.Log("Setting interactable true!");
    }

    public void MoveOverTime(GameObject cardPrefab, GameObject playArea, float overTime){
            IEnumerator coroutine = MoveObject(cardPrefab, playArea, overTime);
            StartCoroutine(coroutine);
    }

    public void StackOnBoard(GameObject cardPrefab, GameObject playArea, float overTime){
            IEnumerator coroutine = BoardStack(cardPrefab, playArea, overTime);
            StartCoroutine(coroutine);
    }


    IEnumerator MoveObject(GameObject source, GameObject playerArea, float overTime)
    //IEnumerator MoveObject(GameObject source, GameObject destination, float overTime, int numCards)
    {
        
        //Vector3 destPos = destination.transform.position;
        Vector3 sourcePos = source.GetComponent<RectTransform>().position;
        
        yield return new WaitForSeconds(1);
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
            
            source.transform.position = Vector3.Lerp(source.GetComponent<RectTransform>().position, playerArea.transform.position, (Time.time - startTime)/overTime);
            yield return null;
        }
        source.transform.position = playerArea.transform.position;
        //Debug.Log("DoNE");
    }

    IEnumerator BoardStack(GameObject source, GameObject boardArea, float overTime)
    {

        // gameBoardScpt = GameObject.Find("GameBoard").GetComponent<GameBoardScript>();
        // Debug.Log(gameBoardScpt.cardStacked + " attempting card stacked");
        // while(gameBoardScpt.cardStacked == false){ //Check if other card is stacking
        //     yield return 1f;
        //     Debug.Log(gameBoardScpt.cardStacked + " <- ll");
        //     Debug.Log("waiting");
        // }

        
        // gameBoardScpt.cardStacked = false;
        Vector3 sourcePos = source.GetComponent<RectTransform>().position;
        gameBoardScpt = gameBoard.GetComponent<GameBoardScript>();
        
        yield return new WaitForSeconds(2);
        float startTime = Time.time;

        Vector3 destLocation = new Vector3( gameBoardScpt.lastPlayed.GetComponent<RectTransform>().localPosition.x + (gameBoardScpt.lastPlayed.GetComponent<RectTransform>().rect.width),// + (source.GetComponent<RectTransform>().rect.width / 2),
                                            gameBoardScpt.lastPlayed.GetComponent<RectTransform>().localPosition.y,// - (gameBoardScpt.lastPlayed.GetComponent<RectTransform>().rect.width),
                                            gameBoardScpt.lastPlayed.GetComponent<RectTransform>().localPosition.z);

        while(Time.time < startTime + overTime)
        { 
            //Debug.Log(source.GetComponent<RectTransform>().position.x + ", " + source.GetComponent<RectTransform>().position.y +  ") going to, (" + gameBoardScpt.lastPlayed.GetComponent<RectTransform>().position.x + ", " + gameBoardScpt.lastPlayed.GetComponent<RectTransform>().position.y);
            //Debug.Log("Width:SizeDelta, " + gameBoardScpt.lastPlayed.GetComponent<RectTransform>().rect.width + " :: " + gameBoardScpt.lastPlayed.GetComponent<RectTransform>().sizeDelta.x);
            source.transform.localPosition = Vector3.Lerp(source.GetComponent<RectTransform>().localPosition,
                                                        destLocation,
                                                                // boardArea.transform.position.y,
                                                                // boardArea.transform.position.z), 
                                                                (Time.time - startTime)/overTime);

            Debug.Log("DestLoc: (" + destLocation.x + ", " + destLocation.y + ", " + destLocation.z + ")");

            yield return null;
        }
        //source.transform.position = boardArea.transform.position;
        //source.transform.position = gameBoardScpt.lastPlayed.transform.position;
        source.GetComponent<CardHover>().DestroyScript();
        gameBoardScpt.lastPlayed = gameBoardScpt.currentCard;
        gameBoardScpt.currentCard = null;
        gameBoardScpt.cardStacked = true;
    }


    public void ResizeThisCard(float overTime){
            IEnumerator coroutine = ResizeCard(overTime);
            StartCoroutine(coroutine);
    }

    IEnumerator ResizeCard(float overTime){
        //yi  eld return new WaitForSeconds(1);
        ///(590000 / gameBoard.GetComponent<RectTransform>().sizeDelta.x )
        float cardScale =  card.co2e / (590000 );
        Debug.Log("CardScale: " + cardScale);

        Color startColor = nameText.color;
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
             //GetComponent<RectTransform>().localScale = Vector3.Lerp(GetComponent<RectTransform>().localScale, new Vector3(cardScale, 1f, 1f), overTime);
            GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(new Vector2(GetComponent<RectTransform>().sizeDelta.x, GetComponent<RectTransform>().sizeDelta.y), new Vector2(cardScale * 100, GetComponent<RectTransform>().sizeDelta.y), overTime);
            
            nameText.color = Color.Lerp(startColor, new Color(0,0,0,0), overTime);
            descriptionText.color = Color.Lerp(startColor, new Color(0,0,0,0), overTime);
            priceText.color  = Color.Lerp(startColor, new Color(0,0,0,0), overTime);
            energyText.color  = Color.Lerp(startColor, new Color(0,0,0,0), overTime);;

            //yield return null;
            yield return new WaitForSeconds(1);
        }
        //nameText.enabled = false;        
        // descriptionText.enabled = false;
        // priceText.enabled = false;
        // energyText.enabled = false;

        nameText.gameObject.SetActive(false);
        descriptionText.gameObject.SetActive(false);
        priceText.gameObject.SetActive(false);
        energyText.gameObject.SetActive(false);
    }

}
