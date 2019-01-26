using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
public class ShipLogic : MonoBehaviour
{
    
    [SerializeField] private Camera _Camera;
    Vector3 mousePoz, worldPoz,velocity;
    private float speed = 90f;
    Rigidbody rb;
    [FormerlySerializedAs("fuel")] [SerializeField] private float currentFuel;
    [SerializeField] private float maxFuel;
    private float pplOnBoard;
    private float maxPplOnBoard;
    public ShooterScript ShooterScript;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
        mouseLogic();
        if (currentFuel > 0)
        lookAtMouse();
        if (Input.GetKey(KeyCode.W))
        {
           var mouseDir = worldPoz - gameObject.transform.position;
            mouseDir = mouseDir.normalized;
            if (currentFuel > 0)
            {
                rb.AddForce(mouseDir * speed * Time.deltaTime);
                currentFuel -= Time.deltaTime;
            }
        }

        if (currentFuel < 0)
            currentFuel = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShooterScript.shoot();
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nie żyjesz1");
        if (tag.Equals("obstacle"))
        {
            //todo nieżyjesz
            Debug.Log("Nie żyjesz2");
        }
    }

    public void UpgadeTank(float amount)
    {
        maxFuel += amount;
    }
    public void UpgadeCapacity(float amount)
    {
        maxPplOnBoard += amount;
    }

    public void Refuel()
    {
        
    }
    

    public float CurrentFuel => currentFuel;
    public float MaxFuel => maxFuel;
    
    
}
