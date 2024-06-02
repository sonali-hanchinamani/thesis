using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace carstimulator{


public class overtake : MonoBehaviour
{
    public float speed = 10f; // Car speed
    public bool startcar;
    private birdviewcamera run;
    public Transform[] visualWheels; // 4 wheels
    public float rotationSpeed = 100f; // Rotation speed

    public bool isTurning = false; // Flag to check if the car is currently turning

    void Start()
    {
        run = FindObjectOfType<birdviewcamera>();
    }

    void Update()
    {
        if (run != null && run.startcars)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        wheelrotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("turn")){
        if (!isTurning)
        {
            StartCoroutine(TurnCarSmoothly(Quaternion.Euler(transform.eulerAngles + new Vector3(0, -5f, 0)), 1f));
        
        }
        }
        if(other.CompareTag("turnstop")){
         if (!isTurning)
        {
            StartCoroutine(TurnCarSmoothly(Quaternion.Euler(0f, 0f, 0f), 1f)); 
        }
        }
    }

    public void wheelrotation()
    {
        foreach (Transform t in visualWheels)
        {
            t.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }

    private IEnumerator TurnCarSmoothly(Quaternion targetRotation, float duration)
    {
        isTurning = true;
        Quaternion initialRotation = transform.rotation;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isTurning = false;
    }
}

}