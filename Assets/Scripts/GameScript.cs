using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScript : MonoBehaviour
{

    public GreenCard cardObject;
    //public GreenCard[] greenCards;
    public List<GreenCard> greenCards;
    
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
            int rand = Random.Range(0, greenCards.Count);
            Debug.Log("your random: " + rand);
            
            cardPrefab = Instantiate(cardTemplate, new Vector3(i * 200.0F, i * -25, 0), Quaternion.identity);
            cardPrefab.transform.SetParent(newParent, false);
            // cardPrefab.GetComponent<CardDisplay>().card = cardObject;
            cardPrefab.GetComponent<CardDisplay>().card = greenCards[rand];
            cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
            cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
            cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
            //cardPrefab.GetComponent<CardDisplay>().cardType = gameObject.cardType;

            //greenCards = RemoveCards(greenCards, rand);
            playerDeck.Add(cardPrefab);
            greenCards.RemoveAt(rand);

            
            IEnumerator coroutine = MoveObject(cardPrefab, playerArea, 1.0f, playerDeck.Count);
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

    // public void SendToPlayerArea(){
    //     float timeOfTravel=5; //time after object reach a target place 
    //     float currentTime=0; // actual floting time 
    //     float normalizedValue = 0f;

    //     Debug.Log("PlayerDeck.Count: " + playerDeck.Count);
    //     for (int i = 0; i < playerDeck.Count; i++)
    //     {
    //         while (currentTime <= timeOfTravel) { 
    //             currentTime += Time.deltaTime; 
    //             normalizedValue=currentTime/timeOfTravel; // we normalize our time 
    //         }
    //         //greenCards[i].GetComponent<RectTransform>().localPosition = Vector3.Lerp(greenCards[i].GetComponent<RectTransform>().localPosition, playerArea.transform.localPosition, normalizedValue);      
    //         playerDeck[i].GetComponent<RectTransform>().localPosition = Vector3.Lerp(playerDeck[i].GetComponent<RectTransform>().localPosition, playerArea.transform.localPosition, normalizedValue);      
    //     }
    // }

    // public void AddToDeck(GameObject[] cardsToAdd, List<GameObject> playerDeck){
    //     for (int i = 0; i < cardsToAdd.Count; i++)
    //     {
    //         playerDeck.Add(cardsToAdd[i]);
    //     }
    // }

    // private IEnumerator WaitAndPrint(float waitTime)
    // {
    //     yield return new WaitForSeconds(waitTime);

    //     float timeOfTravel=5; //time after object reach a target place 
    //     float currentTime=0; // actual floting time 
    //     float normalizedValue = 0f;

    //     Debug.Log("PlayerDeck.Count: " + playerDeck.Count);
    //     for (int i = 0; i < playerDeck.Count; i++)
    //     {
    //         while (currentTime <= timeOfTravel) { 
    //             currentTime += Time.deltaTime; 
    //             normalizedValue=currentTime/timeOfTravel; // we normalize our time 
    //         }
    //         //greenCards[i].GetComponent<RectTransform>().localPosition = Vector3.Lerp(greenCards[i].GetComponent<RectTransform>().localPosition, playerArea.transform.localPosition, normalizedValue);      
    //         playerDeck[i].GetComponent<RectTransform>().localPosition = Vector3.Lerp(playerDeck[i].GetComponent<RectTransform>().localPosition, playerArea.transform.localPosition, normalizedValue);      
    //     }


    //     print("Coroutine ended: " + Time.time + " seconds");
    // }


    IEnumerator MoveObject(GameObject source, GameObject destination, float overTime, int numCards)
    {
        Vector3 destPos = destination.transform.position;
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


}
