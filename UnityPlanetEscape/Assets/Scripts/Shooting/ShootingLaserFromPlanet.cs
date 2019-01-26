using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ShootingLaserFromPlanet : MonoBehaviour {
    public GameObject laserBullet;

    private int laserBulletCount;
    public int maxLaserBulletCount = 5;

    public int forcePower = 100;
//    [SerializeField]GameObject target;
//    [SerializeField] GameObject pocisk;
//    Vector3 targetStartPosition;
//    Vector3 direction;
//    [SerializeField]float minDistance;
//    [SerializeField]float maxDistance;
//    float distance;
//    Camera cam;
//    Vector3 mousePosition;
//    Vector3 temp;

//
    private void Start() {

        //laserBulletRb.GetComponent<Rigidbody2D>();
//        cam = Camera.main;
//        targetStartPosition = target.transform.position;
    }

//
    private void Update() {
        if (Input.GetKeyDown("space") && laserBulletCount < maxLaserBulletCount) {
            var inst = Instantiate(laserBullet, transform.position, Quaternion.identity);
            inst.GetComponent<Rigidbody2D>().AddForce(transform.up * forcePower);
            laserBulletCount++;
        }
    }


//        if (Input.GetMouseButton(0))
//        {
//            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
//            mousePosition.z = 0;
//            distance = Vector3.Distance(transform.position, mousePosition);
//            if (distance >= minDistance && distance <= maxDistance)
//            {
//                target.transform.position = mousePosition;
//            }
//            else if(distance > maxDistance)
//            {
//                if (mousePosition.x == 0)
//                    mousePosition.x = 0.00001f;  
//                float x = Mathf.Sqrt((maxDistance * maxDistance) / (1 + (mousePosition.y / mousePosition.x) * (mousePosition.y / mousePosition.x)));
//                float y = x * (mousePosition.y / mousePosition.x);
//                temp = new Vector3(x, y, 0);
//                if (Vector3.Distance(mousePosition, temp) > Vector3.Distance(mousePosition, -temp))
//                    target.transform.position = (-temp);
//                else
//                    target.transform.position = temp;
//
//            }
//            else if (distance < minDistance && distance >= 0.05f)
//            {
//                if (mousePosition.x == 0)
//                    mousePosition.x = 0.00001f;
//                float x = Mathf.Sqrt((minDistance * minDistance) / (1 + (mousePosition.y / mousePosition.x) * (mousePosition.y / mousePosition.x)));
//                float y = x * (mousePosition.y / mousePosition.x);
//                temp = new Vector3(x, y, 0);
//                if (Vector3.Distance(mousePosition, temp) > Vector3.Distance(mousePosition, temp * (-1)))
//                    target.transform.position = temp * (-1);
//                else
//                    target.transform.position = temp;
//            }
//
//        }
//        else if (Input.GetMouseButtonUp(0))
//        {
//            // 1 liczenie siły na podstawie odległości (najprawdopodobniej wystarczy "kierunek")
//            direction = transform.position - target.transform.position;
//            // 2 spawnowanie pocisku
//            var inst = Instantiate(pocisk, transform.position, Quaternion.identity);
//            // 3 nadawanie siły aby pocisk se poleciał
//            inst.GetComponent<Rigidbody2D>().AddForce(direction * 100f);
//            // 4 reset pozycji cięciwy
//            target.transform.position = targetStartPosition;
//        }
    }
    
    


