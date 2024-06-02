using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planerotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotation speed of the car and plane
    public GameObject ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotate = rotationSpeed * Time.deltaTime;
        ob.transform.Rotate(Vector3.up, rotate);
    }
}
