﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Vector2 offset;
    public Vector2 startingPos;
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

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("Begin Drag");
        Debug.Log("ThisTransform: " + this.name);
        this.transform.SetParent(this.transform, false);
        startingPos = this.transform.localPosition;
        //offset = new Vector2(this.transform.position.x - eventData.position.x, this.transform.position.y - eventData.position.y);        
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging" + eventData.position);// * Time.deltaTime);
        //this.transform.position = (eventData.position * Time.deltaTime);
        //this.transform.localPosition = new Vector3(eventData.position.x, eventData.position.y, 0);// * Time.deltaTime;
        this.transform.localPosition = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("End Drag");
        RectTransform gameBoard = GameObject.Find("GameBoard").GetComponent<RectTransform>();
        Debug.Log("OnDrop" + gameBoard.transform.position.x);
        Debug.Log("Position" + gameBoard.transform.position.x + ", " + gameBoard.transform.position.y);
        Debug.Log("LocalPosition" + gameBoard.transform.localPosition.x + ", " + gameBoard.transform.localPosition.y);

        if (!RectTransformUtility.RectangleContainsScreenPoint(gameBoard, Input.mousePosition))
        {
            Debug.Log("Dropped on board.");
        } else {
            this.transform.localPosition = startingPos;
        }
    }

    public void OnDrop(PointerEventData eventData){
        
    }


    // void OnMouseEnter(){
	//     //GetComponent<Renderer>().material.color = Color.red;
    //     gameObject.GetComponent<Image>().color = Color.red;
    // }

}
