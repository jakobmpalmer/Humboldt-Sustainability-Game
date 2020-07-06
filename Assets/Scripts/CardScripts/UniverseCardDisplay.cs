using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    UniverseCardDisplay
    This class is responsible for displaying UniverseCards. Using the 
    Universe ScriptableObject each UniverseCard gameobject component is
    set to its corresponding value. This includes Universe Card title (Do-niverse/Don't-iverse),
    year, and description.
    
    
    Gameplay:
    These cards check in with the future realities, showing both
    the impact intervention will have, and the impact a lack thereof
    will have.
*/




public class UniverseCardDisplay : MonoBehaviour
{
    public UniverseCard uCard;
    public Text titleText;
    public Text yearText;
    public Text descText;
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.image.color = new Color32(255,255,255,0);
        titleText.text = (uCard.doniverse) ? "DO-NIVERSE" : "DON'T-IVERSE";

        yearText.text = uCard.year.ToString();
        
        descText.text = uCard.content;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
