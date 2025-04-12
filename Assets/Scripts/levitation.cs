using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitation : MonoBehaviour{
    public float anitgravityForce = 9.81f;
    Rigidbody rb; 

    void Start(){
        re.GetComponent<Rigidbody>();
    }

    void FixedUpdate(){
        rb.addForceAtPosition(anitgravityForce * rb.mass * Vector3.up, rb.centerOfMass)
    }
}