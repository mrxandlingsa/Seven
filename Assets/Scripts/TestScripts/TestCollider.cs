using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError(other.gameObject.name);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.LogError(other.gameObject.name);
        Debug.LogError(other.gameObject.tag);
    }
}
