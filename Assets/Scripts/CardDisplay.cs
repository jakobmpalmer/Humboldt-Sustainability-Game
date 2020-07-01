﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public GreenCard card;
    private int cardType;
    public Text nameText;
    public Text descriptionText;
    public Text priceText;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.image.color = new Color32(255,255,255,0);
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        priceText.text = card.price.ToString();
        cardType = card.cardType;
        
        switch (cardType)
        {
            case 1: // if a is an integer
                    GetComponent<Image>().color = Color.blue;
                    Debug.Log("Card is blue!");
                    break;
            case 2: // if a is a string
                    GetComponent<Image>().color = Color.yellow;
                    Debug.Log("Card is yellow!");
                    break;
            case 3: // if a is a string
                    GetComponent<Image>().color = new Color(255.0f, 171.0f, 69.0f, 10.0f);
                    Debug.Log("Card is orange!");
                    break;
            case 0:
                    GetComponent<Image>().color = Color.green;
                    Debug.Log("Card is Green!");
                    break;
        }
    }

}