using UnityEngine;

namespace Shooting {
    public class ShootingLaserFromPlanet : MonoBehaviour {
    
        public GameObject laserBullet;
        public float planetRadius;
        public Transform targetPlanet;
        public int laserBulletCount;
        public int maxLaserBulletCount = 5;

        public int forcePower = 100;

        public float cameraHeight;

        public float cameraWidth;

        [SerializeField] GameObject planet;

        float maxDistanceFrom;

        Camera cam;

        Vector3 mousePosition;
        Vector3 temp;
        private float distance;

        private void Start() {
        
            //Vector2 origin = planet.gameObject.transform.position;
            //Vector2 onPlanet = Random.insideUnitCircle * planetRadius;
            //GameObject newGo =Instantiate(gameObject,onPlanet,Quaternion.identity) as GameObject;
        
            // newGo.transform.rotation=newGo.transform.rotation*Quaternion.Euler(90, 0, 0);

       
        
        
            cam = Camera.main;
            cameraHeight = cam.orthographicSize;
            cameraWidth = cameraHeight * cam.aspect;


            maxDistanceFrom = planet.GetComponent<CircleCollider2D>().radius;

        }

        private void Update() {

            //transform.LookAt(planet.transform.position.normalized);
            transform.LookAt(new Vector3(0,0,0));
        
        
        
        
        
            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            distance = Vector3.Distance(transform.position, mousePosition);

            if (mousePosition.x == 0)
                mousePosition.x = 0.00001f;
            float x = Mathf.Sqrt((maxDistanceFrom * maxDistanceFrom) / (1 + (mousePosition.y / mousePosition.x) * (mousePosition.y / mousePosition.x)));
            float y = x * (mousePosition.y / mousePosition.x);
            temp = new Vector3(x, y, 0) + planet.transform.position;
            if (Vector3.Distance(mousePosition, temp) > Vector3.Distance(mousePosition, -temp))
                transform.position = (-temp);
            else
                transform.position = temp;

            if (Input.GetKeyDown("space") && laserBulletCount < maxLaserBulletCount) {
                var inst = Instantiate(laserBullet, transform.position, Quaternion.identity);
                var LaserBulletScript = inst.GetComponent<LaserBullet>();
                LaserBulletScript.cameraHeight = cameraHeight + 0.5f;  // to przechodzi z ShootingLaserFromPlanet  do LaserBullet  (0.5 aby zniknął 0.5 m poza zasięgiem wzroku kamery)
                LaserBulletScript.cameraWidth = cameraWidth + 0.5f; // to samo tylko z szerokością
                LaserBulletScript.ShootingLaserFromPlanet = this;
                inst.GetComponent<Rigidbody2D>().AddForce(transform.up * forcePower);
                laserBulletCount++;
            
            }
        
        }

    }
}
    
    


