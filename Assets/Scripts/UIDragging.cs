using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragging : EventTrigger {

    private bool dragging;

    public void FixedUpdate() {
        if (dragging) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) * Time.deltaTime;
            Debug.Log("HERE-> " + Input.mousePosition.x + " \\ " + Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData) {
        dragging = false;
    }
}
