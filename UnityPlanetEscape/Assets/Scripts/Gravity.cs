using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody2D rig;

    public static List<Gravity> Attractors;

    const float G = 6.674f;

    private void FixedUpdate()
    {

        foreach(Gravity attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }

    }

    private void OnEnable()
    {
        if (Attractors == null)
            Attractors = new List<Gravity>();
        Attractors.Add(this);
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Attract(Gravity other)
    {
        Rigidbody2D rbOther = other.GetComponent<Rigidbody2D>();
        Vector3 direction = rig.position - rbOther.position;

        float distance = direction.magnitude;

        if (distance == 0)
            return;

        float forceMagnitude = G * (rig.mass * rbOther.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbOther.AddForce(force);
    }



}
