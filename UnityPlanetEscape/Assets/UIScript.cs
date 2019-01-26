using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject currentHPObj,maxHPObj;
    public ShipLogic ShipLogic;
    Text currentHP,maxHP;
    void Start()
    {
        currentHP = currentHPObj.GetComponent<Text>();
        maxHP = maxHPObj.GetComponent<Text>();
    }

    void Update()
    {
        currentHP.text = "" + ShipLogic.CurrentFuel;
        maxHP.text = "/ " + ShipLogic.MaxFuel;
        
    }
}
