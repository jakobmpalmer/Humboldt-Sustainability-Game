using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorHover : MonoBehaviour
{

    public GameObject gameUIObj;
    GameUI gameUI;
    public int clicked;
    float clickdelay;
    float clicktime;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = gameUIObj.GetComponent<GameUI>();
        clicktime = 1f;
        clickdelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // if (Input.GetMouseButtonDown(0))
    //         {
    //             clicked++;
    //             if (clicked == 1) clicktime = Time.time;
    //         }
    
    //         {
    //             clicked = 0;
    //             clicktime = 0;
    //             return true;
    //         }

    void OnMouseDown() {
        Debug.Log("Clicked Inspector");
        clicked++;
        if (clicked == 1){
            clicktime = Time.time;
        }
        if (clicked > 1 && Time.time - clicktime < clickdelay){
            clicked = 0;
            clicktime = 0;
            gameUI.FlipInspector();
            Debug.Log("Flipping inspector ::  " + Time.time + " - " + clicktime + " < " + clickdelay);
        } else if (clicked > 2 || Time.time - clicktime > 1){ clicked = 0;
            clicked = 0;
            clicktime = 0;
        }
    }

}
