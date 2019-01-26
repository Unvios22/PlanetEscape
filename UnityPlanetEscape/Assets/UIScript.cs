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
    public GameObject window;
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
        ChangeIcons();
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

    void ChangeIcons()
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
    public void OpenWindow()
    {
        window.SetActive(true);
    }
    public void CloseWindow()
    {
        window.SetActive(false);
    }
    
    
}
