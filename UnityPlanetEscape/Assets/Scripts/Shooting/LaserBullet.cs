using UnityEngine;

namespace Shooting {
    public class LaserBullet : MonoBehaviour {
        // Start is called before the first frame update
        public float cameraHeight;
        public float cameraWidth;
        public ShootingLaserFromPlanet ShootingLaserFromPlanet;

        void Update()
        {
            if (gameObject.transform.position.y >= cameraHeight||gameObject.transform.position.x>=cameraWidth) {
                Destroy(gameObject);
                ShootingLaserFromPlanet.laserBulletCount--;
            }  
        }
    }
}
