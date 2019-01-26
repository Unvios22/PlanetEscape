using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLogic : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    [SerializeField] private float _Life = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        _Life -= Time.deltaTime;
        if (_Life < 0.0f)
        {
            gameObject.SetActive(false);
            _Life = 2.0f;
        }

    }

    void move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
