using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
    // Start is called before the first frame update

    GameObject asteroid;
    public float speed = 10.0f;
    public bool check;
    private Rigidbody _rigidbody;
    
    void Start() {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        asteroid = GameObject.Find("AsteroidCircle");
        StartCoroutine(Destroy());
        
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.AddRelativeForce(Random.insideUnitCircle * speed);
    }

    IEnumerator Destroy() {
        check = true;
        yield return new WaitForSeconds(1);
        check = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Planet")&&check) {
            asteroid.GetComponent<AsteroidAtack>().count -=1;
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("AsteroidField")) {
            asteroid.GetComponent<AsteroidAtack>().count -=1;
            Destroy(gameObject);
        }
    }
}
