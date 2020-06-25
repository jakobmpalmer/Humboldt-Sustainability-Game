using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenCard : MonoBehaviour
{
    public int thisSize;
    private GameObject thisCard;

    // Start is called before the first frame update
    void Start()
    {
        thisCard = this.gameObject;
        RectTransform rt = thisCard.GetComponent<RectTransform>();//.Set(0,0);
        rt.sizeDelta = new Vector3(120,120,0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
