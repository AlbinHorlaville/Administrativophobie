using UnityEngine;
using System.Collections.Generic;

public class ObjectCollector : MonoBehaviour
{
    public Vector3 teleportLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {}

    // Update is called once per frame
    void Update() {}

    private void OnTriggerEnter(Collider other)
    {
        if (teleportLocation != null && other != null)
        { 
            other.transform.position = teleportLocation;
        }
    }
}
