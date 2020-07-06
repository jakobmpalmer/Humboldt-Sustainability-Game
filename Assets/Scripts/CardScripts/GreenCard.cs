using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Green Card")]
public class GreenCard : ScriptableObject
{
    public string cardName;
    public int cardType; // 0 = green, 1 == blue

    public int price;
    public string description;


    public void Print(){ 
        Debug.Log(cardName + " costs $" + price);
    }

}
