using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ShipLogic : MonoBehaviour
{
    
    [SerializeField] private Camera _Camera;
    Vector3 mousePoz, worldPoz,velocity;
    private float speed = 90f;
    Rigidbody rb;
    [SerializeField] private float fuel;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
        mouseLogic();
        lookAtMouse();
        if (Input.GetKey(KeyCode.W))
        {
           var mouseDir = worldPoz - gameObject.transform.position;
            mouseDir = mouseDir.normalized;
            if (fuel > 0)
            {
                rb.AddForce(mouseDir * speed * Time.deltaTime);
                fuel -= Time.deltaTime;
            }
        }

    }
    public void mouseLogic()
    {
        mousePoz = Input.mousePosition;
        worldPoz = _Camera.ScreenToWorldPoint(new Vector3(mousePoz.x, mousePoz.y, 5f));
        
    }

    void lookAtMouse()
    {
        var newWorldPoz = worldPoz;
        newWorldPoz.Normalize();
        float rot_z = Mathf.Atan2(newWorldPoz.y, newWorldPoz.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90f);
    }

    
}
