using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public bool canPlay;

    public int currency;
    public List<GameObject> playerDeck;

    public GameObject cardTemplate;
    private GameObject cardPrefab;

    GameObject gameMaster;
    GameScript gameScript;

    public List<Card> cardDeck;

    public GameObject playerArea;



    





    // Start is called before the first frame update
    void Start()
    {
        playerDeck = new List<GameObject>();
        gameMaster = GameObject.Find("GameMaster");
        gameScript = gameMaster.GetComponent<GameScript>();
        cardDeck = gameScript.cardDeck;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // public void DrawCards(Transform newParent, int num){
    //     for (int i = 0; i < num; i++)
    //     {
    //         //New Card choice
    //         int rand = Random.Range(0, cardDeck.Count);
    //         Debug.Log("your random: " + rand);
            
    //         cardPrefab = Instantiate(cardTemplate, new Vector3(i * 200.0F, i * -25, 0), Quaternion.identity);
    //         cardPrefab.transform.SetParent(newParent, false);
    //         // cardPrefab.GetComponent<CardDisplay>().card = cardObject;
    //         cardPrefab.GetComponent<CardDisplay>().card = cardDeck[rand];
    //         cardPrefab.GetComponent<CardDisplay>().nameText = cardPrefab.GetComponentsInChildren<Text>()[0];
    //         cardPrefab.GetComponent<CardDisplay>().descriptionText = cardPrefab.GetComponentsInChildren<Text>()[2];
    //         cardPrefab.GetComponent<CardDisplay>().priceText = cardPrefab.GetComponentsInChildren<Text>()[1];
    //         //cardPrefab.GetComponent<CardDisplay>().cardType = gameObject.cardType;

    //         //cardDeck = RemoveCards(cardDeck, rand);
    //         playerDeck.Add(cardPrefab);
    //         cardDeck.RemoveAt(rand);

    //         gameScript.DealerMoveCards();
    //         // IEnumerator coroutine = MoveObject(cardPrefab, 1.0f);
    //         // //IEnumerator coroutine = MoveObject(cardPrefab, playerArea, 1.0f, playerDeck.Count);
    //         // StartCoroutine(coroutine);
    //         // coroutine = StackObject(cardPrefab, 1.0f);
    //         // StartCoroutine(coroutine);
    //         // // if(playerDeck.Count == 1){                
    //         // //     cardPrefab.transform.position.x = -345;
    //         // // } else {
    //         // //     cardPrefab.transform.position.x = playerDeck[playerDeck.Count - 1].transform.position.x + 100;
    //         // // }

    //     }
    // }

}
