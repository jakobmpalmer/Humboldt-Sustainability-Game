﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
   void Start(){
	    //GetComponent<Renderer>().material.color = Color.black;
        //gameObject.GetComponent<Image>().color = Color.white;
    }

    void OnMouseEnter(){
	    //GetComponent<Renderer>().material.color = Color.red;
        gameObject.GetComponent<Image>().color = Color.red;
    }

    void OnMouseExit() {
	    //GetComponent<Renderer>().material.color = Color.black;
        gameObject.GetComponent<Image>().color = Color.white;
    }

}
