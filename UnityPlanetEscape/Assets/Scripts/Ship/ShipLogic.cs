using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    Vector3 mousePoz;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        mouseLogic();
    }
    public void mouseLogic()
    {
        mousePoz = Input.mousePosition;
        var worldPoz = _Camera.ScreenToWorldPoint(new Vector3(mousePoz.x, mousePoz.y, 5f));

        if (Input.GetMouseButtonDown(0)) 
        {
           
            
           //todo ->
           //ship.transform.position = worldPoz;
            transform.position = worldPoz;
            
            
        }


    }
}
