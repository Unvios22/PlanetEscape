using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovmentScript : MonoBehaviour {

    [SerializeField] GameObject target;
    [SerializeField] float z;
    public float smoothTime = 0.3F;

    Vector3 zPosVector;

    Transform player;
    Rigidbody rig;

    Vector3 velocity;

    private void Start()
    {
        if (z == 0)
            z = -10;
        player = target.transform;
        rig = target.GetComponent<Rigidbody>();
        velocity = rig.velocity;
        zPosVector = new Vector3(0, 0, z);

    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + zPosVector, ref velocity, smoothTime);
    }

}
