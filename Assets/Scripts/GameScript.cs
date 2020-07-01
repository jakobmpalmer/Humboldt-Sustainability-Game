using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{

    public GreenCard cardObject;
    public GreenCard[] greenCards;
    public GameObject cardTemplate;
    private GameObject cardPrefab;
    
    public Canvas mainCanvas;
    // Start is called before the first frame update
    void Start()
    {
        //DrawCards(mainCanvas.transform, 2);
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
            int rand = Random.Range(0, greenCards.Length);
            Debug.Log("your random: " + rand);
            
            //cardPrefab = new
            cardPrefab = Instantiate(cardTemplate, new Vector3(i * 200.0F, i * -25, 0), Quaternion.identity);
            //cardPrefab.AddComponent<CardDisplay>();
            cardPrefab.transform.SetParent(newParent, false);
            // cardPrefab.GetComponent<CardDisplay>().card = cardObject;
            cardPrefab.GetComponent<CardDisplay>().card = greenCards[rand];
            cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
            cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
            cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
            //cardPrefab.GetComponent<CardDisplay>().cardType = gameObject.cardType;

            greenCards = RemoveCards(greenCards, rand);

        }
    }

    GreenCard[] RemoveCards(GreenCard[] deck, int removeInt){
        GreenCard[] tempArray = deck;
        deck = new GreenCard[deck.Length - 1];
        for (int i = 0; i < deck.Length; i++)
        {
            Debug.Log("Temp " + tempArray.Length);
            Debug.Log("Deck " + deck.Length);
            if (i != removeInt) {
                deck[i] = tempArray[i];
                Debug.Log("Adding " + tempArray[i]);
            }
            else {
                Debug.Log("Skipping: " + tempArray[i].cardName.ToString() + " at position " + i);
                i++;
                Debug.Log("Instead, " + tempArray[i].cardName.ToString() + "added from " + i);
                deck[i - 1] = tempArray[i];
            } 

        }
        return deck;
    }

    void DrawDotiverse(){

    }

    void DrawDontiverse(){

    }
}
