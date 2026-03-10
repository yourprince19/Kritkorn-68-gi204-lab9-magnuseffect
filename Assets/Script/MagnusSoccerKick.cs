using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusSoccerKick : MonoBehaviour
{
    public float kickForce;

    public float spinAmount;

    public float magnusStrength = 0.5f;

    Rigidbody rb;

    bool isShot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isShot)
        {
            rb.AddForce(Vector3.forward * kickForce,ForceMode.Impulse);
            
            rb.AddTorque(Vector3.up * spinAmount);
            isShot = true;
        }
    }

    void FixedUpdate()
    {
        if (isShot)
        {
            Vector3 magnusForce = Vector3.Cross(rb.angularVelocity, rb.velocity) * magnusStrength;
            rb.AddForce((magnusForce));
        }
    }
}
