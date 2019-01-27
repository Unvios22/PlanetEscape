
using Ship;
using UnityEngine.UI;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] public bool IsInSpace;
    public bool isUIOpen;
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
        currentHP.text = "" + (int)ShipLogic.CurrentFuel1;
        maxHP.text = "/" + (int)ShipLogic.MaxFuel;
    }

    void PrintResources()
    {
        currentResources.text = "" + (int)GameController.resources;
    }

    void PrintFood()
    {
        currentFood.text = "" + (int)GameController.food;
    }

    void PrintPopulation()
    {
        currentPopulation.text = "" + (int)GameController.population;
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
    public void OpenWindow() {
        isUIOpen = true;
        window.SetActive(true);
        GameController.FreezeTime();
    }
    public void CloseWindow() {
        isUIOpen = false;
        window.SetActive(false);
        GameController.UnFreezeTime();
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
        currentHPinWIn.text = "" + (int)ShipLogic.CurrentFuel1;
        maxHPinWIn.text = "/ " + (int)ShipLogic.MaxFuel;
        //ppl capacity
        pplOnBoard.text = "" + (int)ShipLogic.maxPplOnBoard;
        //food
        currentFoodinWin.text = "" + (int)GameController.food;
        //resources
        currentResourcesinWIn.text = "" + (int)GameController.resources;
        //population
        currentPopulationinWin.text = "" + (int)GameController.population;
        


    }
    
    
}
