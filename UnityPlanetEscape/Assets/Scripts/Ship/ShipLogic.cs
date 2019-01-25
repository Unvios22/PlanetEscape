using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLogic : MonoBehaviour
{
    [SerializeField] private Camera _Camera;
    Vector3 mousePoz, worldPoz;
    private float speed = 5;
  
    void Start()
    {
        
    }

    
    void Update()
    {
        mouseLogic();
        transform.position = Vector3.MoveTowards(transform.position, worldPoz, speed * Time.deltaTime);
    }
    public void mouseLogic()
    {
        mousePoz = Input.mousePosition;
        

        if (Input.GetMouseButtonDown(0)) 
        {
            worldPoz = _Camera.ScreenToWorldPoint(new Vector3(mousePoz.x, mousePoz.y, 5f));
            
           //todo ->
           // transform.position = worldPoz;
            
            


        }


    }
}
