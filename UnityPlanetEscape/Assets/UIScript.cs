using System.Collections;
using System.Collections.Generic;
using Ship;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject currentHPObj,maxHPObj,currentResourcesObj,fuel,resources;
    public ShipLogic ShipLogic;
    private Text currentHP,maxHP;
    private Text currentResources;
    [SerializeField] public bool IsInSpace;
    void Start()
    {
        currentHP = currentHPObj.GetComponent<Text>();
        maxHP = maxHPObj.GetComponent<Text>();
        currentResources = currentResourcesObj.GetComponent<Text>();
    }

    void Update()
    {
        PrintHP();   
        PrintResources();
        changeIcons();
    }

    void PrintHP()
    {
        currentHP.text = "" + ShipLogic.CurrentFuel;
        maxHP.text = "/ " + ShipLogic.MaxFuel;
    }

    void PrintResources()
    {
        //todo
        currentResources.text = "100K";
    }

    void changeIcons()
    {
        if (IsInSpace)
        {
            fuel.SetActive(true);
            resources.SetActive(false);
            //todo pasekHP
        }
        else
        {
            fuel.SetActive(false);
            resources.SetActive(true);
            //todo pasekHP
        }
        
    }
    
}
