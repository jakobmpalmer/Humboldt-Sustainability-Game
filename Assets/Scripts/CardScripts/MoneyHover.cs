using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHover : MonoBehaviour
{
    GameScript gameScript;
    void Start(){
        gameScript = GameObject.Find("GameMaster").GetComponent<GameScript>();
    }


     void OnMouseEnter() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 0f);
        //GetComponent<SpriteRenderer>().sortingOrder = 10;
        // GetComponent<CanvasRenderer>().sortingLayerName = "SortingLayerName";
        // GetComponent<CanvasRenderer>().sortingOrder = 1;
    }

     void OnMouseDown() {
        TotalCosts();
        // this.gameObject.GetComponent<CardDisplay>().selected = true;
        // GameObject.Find("GameBoard").GetComponent<GameBoardScript>().SetCurrentCard(this.gameObject);
        // GameObject.Find("Canvas").GetComponent<GameUI>().UpdateInspector(this.gameObject);
        // GameObject.Find("Canvas").GetComponent<GameUI>().SetSecretStatus(false);
        // GameObject.Find("Canvas").GetComponent<GameUI>().FlipInspector();
    }

    void OnMouseUp() {
        Destroy(this.gameObject);
        //prevCardColor = this.GetComponent<Image>().color;        
    }

    void TotalCosts(){

    }


}
