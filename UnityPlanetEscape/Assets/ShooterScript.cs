using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    [SerializeField] public GameObject bulletPrefab;
    public int amountToPool;
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = (GameObject)Instantiate(bulletPrefab);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void shoot()
    {
        GameObject bullet = GetPooledObject(); 
        if (bullet != null) {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
        //GameObject obj = ShooterScript.current.GetPooledObject();
        //Instantiate(PrefabOverride)
        //var bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
        
    }
    public GameObject GetPooledObject() {
//1
        for (int i = 0; i < pooledObjects.Count; i++) {
//2
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }
//3   
        return null;
    }
    
}
