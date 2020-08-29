using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardScript : MonoBehaviour
{

    [SerializeField] GameObject gameboardBorder;
    public GameObject currentCard;
    public GameObject lastPlayed;
    public bool cardStacked;
    // Start is called before the first frame update
    void Start()
    {
        cardStacked = true;
        Debug.Log("Card is stacked!!");
        //currentCard = GameObject.Find("firstCard");
        currentCard = null;
        lastPlayed = GameObject.Find("FirstCardSpot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameBoard.");
        
        if ((currentCard != null) && (Vector3.Distance(currentCard.transform.position, this.transform.position) < 91)){
        //if(GameObject.Find("card-template(Clone)").GetComponent<CardDisplay>().selected){
            Debug.Log("Current card over gameboard");
            gameboardBorder.GetComponent<Image>().color = Color.yellow;
            //lastPlayed = currentCard;
            // currentCard = null;
        } else{
            //Debug.Log(Vector3.Distance(currentCard.transform.position, this.transform.position) + " hereee");
        }
    }

    void OnMouseExit() {
	    //GetComponent<Renderer>().material.color = Color.black;
        //gameObject.GetComponent<Image>().color = new Color(197,197,197,1);
        gameboardBorder.GetComponent<Image>().color = new Color(0.77f,0.77f,0.77f,1f);
    }

    public void SetCurrentCard(GameObject thisCard){
        currentCard = thisCard;
    }
}
