using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoardScript : MonoBehaviour
{

    [SerializeField] GameObject gameboardBorder;
    public GameObject currentCard;
    // Start is called before the first frame update
    void Start()
    {
        currentCard = GameObject.Find("firstCard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameBoard.");
        Debug.Log("XY" + currentCard.transform.position.x);
        //GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 0f);
        //this.gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
        // if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(),
        //                                                              new Vector2(currentCard.transform.position.x, currentCard.transform.position.y),
        //                                                              Camera.main)){
        if (Vector3.Distance(currentCard.transform.position, this.transform.position) < 91){
        //if(GameObject.Find("card-template(Clone)").GetComponent<CardDisplay>().selected){
            gameboardBorder.GetComponent<Image>().color = Color.yellow;
        } else{
            Debug.Log(Vector3.Distance(currentCard.transform.position, this.transform.position) + " hereee");
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
