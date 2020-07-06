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

    // Start is called before the first frame update
    void Start()
    {
        //DrawCards(mainCanvas.transform, 2);
        playerDeck = new List<GameObject>();
        LoadResources();
        Debug.Log("Resources Loaded");
    }

    // Update is called once per frame
    void Update()
    {

    }

//Invoked on button click
    public void DrawCards(Transform newParent, int num){
        for (int i = 0; i < num; i++)
        {
            //New Card choice
            int rand = Random.Range(0, cardDeck.Count);
            Debug.Log("your random: " + rand);
            
            cardPrefab = Instantiate(cardTemplate, new Vector3(i * 200.0F, i * -25, 0), Quaternion.identity);
            cardPrefab.transform.SetParent(newParent, false);
            // cardPrefab.GetComponent<CardDisplay>().card = cardObject;
            cardPrefab.GetComponent<CardDisplay>().card = cardDeck[rand];
            cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
            cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
            cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
            //cardPrefab.GetComponent<CardDisplay>().cardType = gameObject.cardType;

            //cardDeck = RemoveCards(cardDeck, rand);
            playerDeck.Add(cardPrefab);
            cardDeck.RemoveAt(rand);

            
            IEnumerator coroutine = MoveObject(cardPrefab, 1.0f);
            //IEnumerator coroutine = MoveObject(cardPrefab, playerArea, 1.0f, playerDeck.Count);
            StartCoroutine(coroutine);
            coroutine = StackObject(cardPrefab, 1.0f);
            StartCoroutine(coroutine);
            // if(playerDeck.Count == 1){                
            //     cardPrefab.transform.position.x = -345;
            // } else {
            //     cardPrefab.transform.position.x = playerDeck[playerDeck.Count - 1].transform.position.x + 100;
            // }

        }
    }

    // GreenCard[] RemoveCards(GreenCard[] deck, int removeInt){
    //     GreenCard[] tempArray = deck;
    //     deck = new GreenCard[deck.Length - 1];
    //     for (int i = 0; i < deck.Length; i++)
    //     {
    //         Debug.Log("Temp " + tempArray.Length);
    //         Debug.Log("Deck " + deck.Length);
    //         if (i != removeInt) {
    //             deck[i] = tempArray[i];
    //             Debug.Log("Adding " + tempArray[i]);
    //         }
    //         else {
    //             Debug.Log("Skipping: " + tempArray[i].cardName.ToString() + " at position " + i);
    //             i++;
    //             Debug.Log("Instead, " + tempArray[i].cardName.ToString() + "added from " + i);
    //             deck[i - 1] = tempArray[i];
    //         } 

    //     }
    //     return deck;
    // }

    void DrawDotiverse(){

    }

    void DrawDontiverse(){

    }

    IEnumerator MoveObject(GameObject source, float overTime)
    //IEnumerator MoveObject(GameObject source, GameObject destination, float overTime, int numCards)
    {
        //Vector3 destPos = destination.transform.position;
        Vector3 sourcePos = source.GetComponent<RectTransform>().position;
        yield return new WaitForSeconds(1);
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
            
            //source.transform.position = Vector3.Lerp(sourcePos, new Vector3(destPos.x, destPos.y, destPos.z), (Time.time - startTime)/overTime);      
            source.transform.position = Vector3.Lerp(source.GetComponent<RectTransform>().position, playerArea.transform.position, (Time.time - startTime)/overTime);      
            //transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
            yield return null;
            //yield return new WaitForSeconds(1);
        }
        source.transform.position = playerArea.transform.position;
    }


    IEnumerator StackObject(GameObject source, float overTime)
    {
        int deckCount = playerDeck.Count;
        yield return new WaitForSeconds(3);
        Debug.Log("PlayerCount" + deckCount);
        Debug.Log("Stacking Object!");
        
        GameObject destination;
        Vector3 destPos;
        source.transform.SetParent(playerArea.transform, false);
        float xOffset = playerArea.GetComponent<RectTransform>().rect.width / 2;

        float yOffset = 0;
        if(deckCount >=6) {
            yOffset = 1;
        }

        if(deckCount == 1){

            destination = playerArea;            
            Debug.Log("xOffset: " + xOffset);
            //Debug.Log("MathyVersion: " + (destination.transform.position.x - xOffset);
            destPos = new Vector3(destination.transform.position.x - xOffset + 122, 0, 0);//destination.transform.position.y, destination.transform.position.z);
        } else {
            //source.transform.SetParent(playerDeck[playerDeck.Count-1].transform, false);
            destination = playerDeck[deckCount -1];
            destPos = new Vector3(
                destination.transform.position.x - xOffset + (100 * deckCount),
                yOffset * 100,
                0
            );
            // destination.transform.position.y, destination.transform.position.z);
        }
        
        
        Vector3 sourcePos = source.GetComponent<RectTransform>().position;
        
        float startTime = Time.time;
        while(Time.time < startTime + overTime)
        {
            
            //source.transform.position = Vector3.Lerp(sourcePos, new Vector3(destPos.x, destPos.y, destPos.z), (Time.time - startTime)/overTime);      
            source.transform.localPosition = Vector3.Lerp(source.GetComponent<RectTransform>().position, destPos, (Time.time - startTime)/overTime);      
            //transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
            yield return null;
            //yield return new WaitForSeconds(1);
        }
        //source.transform.position = playerArea.transform.position;
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
        Debug.Log("Count after green: " + count);

        foreach (Card card in blueCards){
            count++;
            cardDeck.Add(card);
        }
        Debug.Log("Count after blue: " + count);

        foreach (Card card in orangeCards){
            count++;
            cardDeck.Add(card);
        }
        Debug.Log("Count after orange: " + count);

        foreach (Card card in pinkCards){
            count++;
            cardDeck.Add(card);
        }
        Debug.Log("Count after pink: " + count);


    }


}
