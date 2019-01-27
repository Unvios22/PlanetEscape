using System.Collections;
using System.Collections.Generic;
using Shooting;
using UnityEngine;

public class LaserBullet : MonoBehaviour {
    // Start is called before the first frame update
    public float cameraHeight;
    public float cameraWidth;
    public ShootingLaserFromPlanet ShootingLaserFromPlanet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y >= cameraHeight||gameObject.transform.position.x>=cameraWidth) {
            Destroy(gameObject);
            ShootingLaserFromPlanet.laserBulletCount--;
        }  
    }
}
