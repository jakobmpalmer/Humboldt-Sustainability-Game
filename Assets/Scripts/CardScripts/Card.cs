using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "New Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardType; // 0 = green, 1 == blue

    public int price;
    public int co2e;
    public int energy;
    public bool saves;
    public string description;
    public string secret;


    public void Print(){ 
        Debug.Log(cardName + " costs $" + price);
    }

}
