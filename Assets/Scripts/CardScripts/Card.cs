using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "New Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardType; // 0 = green, 1 == blue

    public float price;
    public float co2e;
    public float energy;
    public bool costs;
    public string description;
    public string secret;


    public void Print(){ 
        Debug.Log(cardName + " costs $" + price);
    }

}
