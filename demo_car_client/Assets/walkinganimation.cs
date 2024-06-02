using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkinganimation : MonoBehaviour
{
    public Animator anim;
    public Transform t;
    public GameObject blink;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {     if(t.position.z > -8.9)
        {
            anim.SetBool("Walk", true);
        }
        StartCoroutine(blinkstart(1f));
        blink.SetActive(false);
    }
    private IEnumerator blinkstart(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            blink.SetActive(true);
        }
    }
}
