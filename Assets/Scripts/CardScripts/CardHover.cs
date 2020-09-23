using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Vector2 offset;
    public Vector2 startingPos;

    public Color prevCardColor;

    GameObject thisCardDisplay;
    float clickTime;
    float prevClick;

    // void Start(){
    //     thisCardDisplay = GetComponent<CardDisplay>();
    // }
    void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 0f);
        //GetComponent<SpriteRenderer>().sortingOrder = 10;
        // GetComponent<CanvasRenderer>().sortingLayerName = "SortingLayerName";
        // GetComponent<CanvasRenderer>().sortingOrder = 1;
    }
    void OnMouseExit() {
        this.clickTime = Time.time;
        float clickDelay = 3.0f;
        Debug.Log("ClickTime: " + clickTime);
        Debug.Log("PrevClick: " + clickTime);

        if(clickTime - prevClick < clickDelay){
            Debug.Log("Double clicked!");
        }
        //The mouse is no longer hovering over the GameObject so output this message each frame
        GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
        Debug.Log("Mouse is no longer on GameObject.");
        //GetComponent<SpriteRenderer>().sortingOrder = 0;
        prevClick = clickTime;
    }

    void OnMouseDown() {

        this.gameObject.GetComponent<CardDisplay>().selected = true;
        GameObject.Find("GameBoard").GetComponent<GameBoardScript>().SetCurrentCard(this.gameObject);
        GameObject.Find("Canvas").GetComponent<GameUI>().UpdateInspector(this.gameObject);
        GameObject.Find("Canvas").GetComponent<GameUI>().SetSecretStatus(false);
        GameObject.Find("Canvas").GetComponent<GameUI>().FlipInspector();
    }

    void OnMouseUp() {
        
        //prevCardColor = this.GetComponent<Image>().color;        
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("Begin Drag");
        Debug.Log("ThisTransform: " + this.transform.position);        
        startingPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log("Dragging" + eventData.position + " |VS| " + this.transform.localPosition);// * Time.deltaTime);
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Dragging" + mousePos + " |VS| " + this.transform.position);// * Time.deltaTime);
        //this.transform.localPosition = Input.mousePosition;
        // this.transform.localPosition = new Vector3(mousePos.x + startingPos.x, mousePos.y + startingPos.y, 0);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        //this.transform.position = new Vector3(mousePos.x + startingPos.x, mousePos.y + startingPos.y, 0);

    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("End Drag");
        GameObject gameBoardObj = GameObject.Find("GameBoard");
        GameBoardScript gameBoardScpt = gameBoardObj.GetComponent<GameBoardScript>();
        RectTransform gameBoard = gameBoardObj.GetComponent<RectTransform>();
        //Debug.Log("GameBoard Position:: " + gameBoard.transform.position.x + ", " + gameBoard.transform.position.y);
        //Debug.Log("LocalPosition:: " + gameBoard.transform.localPosition.x + ", " + gameBoard.transform.localPosition.y);

         if (RectTransformUtility.RectangleContainsScreenPoint(gameBoard.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
        //if (RectTransformUtility.RectangleContainsScreenPoint(gameBoard, Input.mousePosition))
        {   

            Debug.Log("Dropped on board.");
            Debug.Log("GameBoard Position:: " + gameBoard.transform.position.x + ", " + gameBoard.transform.position.y);
            Debug.Log("LocalPosition:: " + gameBoard.transform.localPosition.x + ", " + gameBoard.transform.localPosition.y);

            //if(GetComponent<CardDisplay>().CheckEnergy() && GetComponent<CardDisplay>().CheckMoney()){
            if(GetComponent<CardDisplay>().CanPlay()){
                Debug.Log("Can Play!");
                // Debug.Log(playerMoney + " - " + cardPrice + " = " + (playerMoney - cardPrice));
                //  Debug.Log(playerMoney + " - " + cardPrice + " = " + (playerMoney - cardPrice));
                //playerMoney -= cardPrice;
                
                //GetComponent<CardDisplay>().SubtractResources();
                GetComponent<CardDisplay>().UpdateResources();

                Debug.Log(this.transform.position.x + ", " + this.transform.position.y + " |VS| loc: " + this.transform.localPosition.x + ", " + this.transform.localPosition.y);
                              
                GetComponent<CardDisplay>().PlayCard();     
                GameObject.Find("GameUI").GetComponent<GameUI>().UpdateBank();
                //this.enabled = false;
                GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
                //Destroy(this);
                Debug.Log("THIS SHOULD NEVER PRINT. Enabled = false");
            } else {
                Debug.Log("Cannot play...");
                GameObject.Find("GameMaster").GetComponent<GameScript>().ShowErrorMessage("Not Enough Resources!", 1.0f);
                this.transform.position = startingPos;
            }
        } else {
            // this.transform.localPosition = startingPos;
            this.transform.position = startingPos;
        }
    }

    public void OnDrop(PointerEventData eventData){
        
    }

    public void DestroyScript(){
        Destroy(this);
    }


    // void OnMouseEnter(){
	//     //GetComponent<Renderer>().material.color = Color.red;
    //     gameObject.GetComponent<Image>().color = Color.red;
    // }

}
