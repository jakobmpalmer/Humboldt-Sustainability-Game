using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHover : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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
        this.transform.SetParent(this.transform, false);
        startingPos = this.transform.position;
        //offset = new Vector2(this.transform.position.x - eventData.position.x, this.transform.position.y - eventData.position.y);
    }

    public void OnDrag(PointerEventData eventData){
        Debug.Log("Dragging" + eventData.position * Time.deltaTime);
        //this.transform.position = (eventData.position * Time.deltaTime);
        this.transform.position = new Vector3(eventData.position.x, eventData.position.y, 0) * Time.deltaTime;
    }

    public void OnEndDrag(PointerEventData eventData){
        Debug.Log("End Drag");
        this.transform.position = startingPos;
    }


    // void OnMouseEnter(){
	//     //GetComponent<Renderer>().material.color = Color.red;
    //     gameObject.GetComponent<Image>().color = Color.red;
    // }

}
