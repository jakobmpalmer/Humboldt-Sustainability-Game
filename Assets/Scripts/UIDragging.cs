using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragging : EventTrigger {

    private bool dragging;

    public void FixedUpdate() {
        if (dragging) {
            //transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) * Time.deltaTime;
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0) * Time.deltaTime;
            Debug.Log("HERE-> " + Input.mousePosition.x + " \\ " + Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
         dragging = false;
        //GameObject playerArea = GameObject.Find("playerArea");


        // Debug.Log("Drag ended" + CardPosition);
        // if ((CardPosition.x) > minXDA && (CardPosition.x) < MAXXDA)
        // {
        //     this.transform.SetParent(playerArea.transform, false);
        //     Debug.Log("Card's Parent: " + this.transform.parent.name);
        //     dragging = false;
        // }

    }
}
