using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UniverseCardHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Vector2 offset;
    public Vector2 startingPos;

    public Color prevCardColor;
    void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 0f);
    }
    void OnMouseExit() {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
        Debug.Log("Mouse is no longer on GameObject.");
    }

    void OnMouseDown() {
        
    }

    void OnMouseUp() {
//        this.gameObject.GetComponent<CardDisplay>().selected = true;
        GameObject.Find("GameBoard").GetComponent<GameBoardScript>().SetCurrentCard(this.gameObject);
        GameObject.Find("Canvas").GetComponent<GameUI>().UpdateInspectorUniverse(this.gameObject);
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
        Debug.Log("End Drag");
        RectTransform gameBoard = GameObject.Find("GameBoard").GetComponent<RectTransform>();
        Debug.Log("GameBoard Position:: " + gameBoard.transform.position.x + ", " + gameBoard.transform.position.y);
        Debug.Log("LocalPosition:: " + gameBoard.transform.localPosition.x + ", " + gameBoard.transform.localPosition.y);

            this.transform.position = startingPos;
        
    }

    public void OnDrop(PointerEventData eventData){
        
    }


    // void OnMouseEnter(){
	//     //GetComponent<Renderer>().material.color = Color.red;
    //     gameObject.GetComponent<Image>().color = Color.red;
    // }

}
