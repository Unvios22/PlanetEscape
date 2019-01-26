using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidAtack : MonoBehaviour {
    
    public GameObject asteroid;
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(Spauning());
    }

    IEnumerator Spauning() {
        if(count<25){
            Vector2 start = Random.insideUnitCircle*20;
            Instantiate(asteroid, start,Quaternion.identity);
            asteroid.SetActive(true);
            count++;     
        } 
        yield return new WaitForSeconds(1f);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,20);
    }
}
