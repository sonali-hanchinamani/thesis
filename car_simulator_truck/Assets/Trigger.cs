using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TrafficCar")){
        Debug.Log("HERE");
        }
     
    }
}
