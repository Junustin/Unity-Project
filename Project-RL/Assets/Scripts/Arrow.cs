using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * 20 * Time.deltaTime,ForceMode.VelocityChange);
        
    }
}
