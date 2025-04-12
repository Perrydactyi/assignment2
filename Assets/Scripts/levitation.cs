using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitation : MonoBehaviour
{
    public float antigravityForce = 9.81f;  
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForceAtPosition(antigravityForce * rb.mass * Vector3.up, rb.worldCenterOfMass);
    }
}
