using System.Collections;
using System.Collections.Generic;
using Ship;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] public bool IsInSpace;
    public ShipLogic ShipLogic;
    public GameController GameController;
    //in-game UI
    public GameObject currentHPObj,maxHPObj,currentResourcesObj,fuel,resources,currentFoodObj,currentPopulationObj;
    public GameObject Bar;
    private Text currentHP,maxHP;
    private Text currentResources;
    private Text currentFood;
    private Text currentPopulation;
    public GameObject window;
    //Window UI
    //fuel
    public GameObject currentHPinWInObj, maxHPinWInObj,currentFoodInWinObj,currentResourcesInWinObj,currentPopulationinWinObj;
    private Text currentHPinWIn, maxHPinWIn,currentFoodinWin,currentResourcesinWIn,currentPopulationinWin;
    // pplOnBoard
    public GameObject PplOnBoardObj;
    private Text pplOnBoard;
    void Start()
    {
        currentHP = currentHPObj.GetComponent<Text>();
        maxHP = maxHPObj.GetComponent<Text>();
        currentResources = currentResourcesObj.GetComponent<Text>();
        currentHPinWIn = currentHPinWInObj.GetComponent<Text>();
        maxHPinWIn = maxHPinWInObj.GetComponent<Text>();
        pplOnBoard = PplOnBoardObj.GetComponent<Text>();
        currentFood = currentFoodObj.GetComponent<Text>();
        currentFoodinWin = currentFoodInWinObj.GetComponent<Text>();
        currentResourcesinWIn = currentResourcesInWinObj.GetComponent<Text>();
        currentPopulationinWin = currentPopulationinWinObj.GetComponent<Text>();
        currentPopulation = currentPopulationObj.GetComponent<Text>();
    }

    void Update()
    {
        PrintFuel();   
        PrintResources();
        PrintFood();
        ChangeIcons();
        PrintThingsInWindow();
        PrintPopulation();
        ChangeBool();
    }

    void PrintFuel()
    {
        currentHP.text = "" + ShipLogic.CurrentFuel1;
        maxHP.text = "/" + ShipLogic.MaxFuel;
    }

    void PrintResources()
    {
        currentResources.text = "" + GameController.resources;
    }

    void PrintFood()
    {
        currentFood.text = "" + GameController.food;
    }

    void PrintPopulation()
    {
        currentPopulation.text = "" + GameController.population;
    }

    void ChangeIcons()
    {
        if (IsInSpace)
        {
            fuel.SetActive(true);
            resources.SetActive(false);
            Bar.SetActive(true);
        }
        else
        {
            fuel.SetActive(false);
            resources.SetActive(true);
            Bar.SetActive(false);
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

    void ChangeBool()
    {
        if (GameController.stage == GameController.GameStage.Planet)
        {
            IsInSpace = false;
        }
        else
        {
            IsInSpace = true;
        }
    }

    public void PrintThingsInWindow()
    {
        //fuel
        currentHPinWIn.text = "" + ShipLogic.CurrentFuel1;
        maxHPinWIn.text = "/ " + ShipLogic.MaxFuel;
        //ppl capacity
        pplOnBoard.text = "" + ShipLogic.maxPplOnBoard;
        //food
        currentFoodinWin.text = "" + GameController.food;
        //resources
        currentResourcesinWIn.text = "" + GameController.resources;
        //population
        currentPopulationinWin.text = "" + GameController.population;
        


    }
    
    
}
