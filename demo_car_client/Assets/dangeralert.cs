using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangeralert : MonoBehaviour
{
    public Transform truck;
    public GameObject dangeralertvisual;
    public float distance;

    public void Update()
    {
        var distance = Mathf.Abs(truck.position.z - transform.position.z);
        if (distance < 30f)
        {
            dangeralertvisual.SetActive(true);
        }
    }
}
