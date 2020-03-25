using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespectUI : MonoBehaviour
{
    public GameObject respectAmount;
    public Text respectAmountText;

    // Start is called before the first frame update
    void Start()
    {
        //finding the text
        respectAmount = GameObject.Find("RespectAmount");
        respectAmountText = respectAmount.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //updating the respect amount
        respectAmountText.text = "Respect: " + RespectManager.RespectValue.ToString();
    }
}
