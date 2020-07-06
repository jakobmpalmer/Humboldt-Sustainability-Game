using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{

    public Card card;
    private int cardType;
    public Text nameText;
    public Text descriptionText;
    public Text priceText;
    public Text secretText;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.image.color = new Color32(255,255,255,0);
        nameText.text = card.cardName;
        descriptionText.text = card.description;
        priceText.text = card.price.ToString();
        cardType = card.cardType;
        //secretText.text = card.secret;
        
        switch (cardType)
        {
            case 1: // if cardType == 1
                    GetComponent<Image>().color = Color.blue;
                    Text[] cardText = GetComponentsInChildren<Text> ();
                    foreach(Text text in cardText){
                            text.color = Color.white;
                    }
                    Debug.Log("Card is blue!");
                    break;
            case 2: // if cardType == 2
                    GetComponent<Image>().color = new Color(255, 153, 204, 10);
                    Debug.Log("Card is Pink!");
                    break;
            case 3: // if cardType == 3
                    GetComponent<Image>().color = new Color(255, 171, 69, 10);
                    Debug.Log("Card is orange!");
                    break;
            case 0: // if cardType != (1,2,3)
                    GetComponent<Image>().color = Color.green;
                    Debug.Log("Card is Green!");
                    break;
        }
    }

}
