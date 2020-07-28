using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Vector2 offset;
    public Vector2 startingPos;

    public Color prevCardColor;
    void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 0f);
    }
    void OnMouseExit() {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void OnMouseDown() {
        this.gameObject.GetComponent<CardDisplay>().selected = true;
        GameObject.Find("GameBoard").GetComponent<GameBoardScript>().SetCurrentCard(this.gameObject);
        GameObject.Find("Canvas").GetComponent<GameUI>().UpdateInspector(this.gameObject);
    }

    void OnMouseUp() {
        
        //prevCardColor = this.GetComponent<Image>().color;        
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("Begin Drag");
        Debug.Log("ThisTransform: " + this.transform.position);
        //this.transform.SetParent(this.transform, false);
        //startingPos = this.transform.localPosition;
        startingPos = this.transform.position;
        //offset = new Vector2(this.transform.position.x - eventData.position.x, this.transform.position.y - eventData.position.y);        
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

            if(GetComponent<CardDisplay>().CanPlay()){
                Debug.Log("Can Play!");
                
                Debug.Log(this.transform.position.x + ", " + this.transform.position.y + " |VS| loc: " + this.transform.localPosition.x + ", " + this.transform.localPosition.y);
                
                //GetComponent<CardHover>().enabled = false;
                //this.transform.position = new Vector3(-1 * gameBoard.sizeDelta.x / 2, 0, 0);
                
                // GetComponent<CardDisplay>().MoveOverTime(gameObject, GameObject.Find("GameBoard"), 1.0f);
                // this.transform.SetParent(gameBoard.transform, false);
                // Debug.Log("Resize.. begun");
                // GetComponent<CardDisplay>().ResizeThisCard(2.0f);
                // Debug.Log("Resize.. complete");
                // GetComponent<CardDisplay>().StackOnBoard(gameObject, GameObject.Find("GameBoard"), 1.0f);
                // Debug.Log("-----> MOVED");    
                GetComponent<CardDisplay>().PlayCard();        
                //this.enabled = false;
                Destroy(this);
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


    // void OnMouseEnter(){
	//     //GetComponent<Renderer>().material.color = Color.red;
    //     gameObject.GetComponent<Image>().color = Color.red;
    // }

}
