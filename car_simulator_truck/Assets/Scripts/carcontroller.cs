using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace carstimulator{
public class carcontroller : MonoBehaviour
{
    public float speed = 10;   //// CAR SPEED ///////
    public bool startcar; 
    private birdviewcamera run; 
    public Transform[] visualWheels;  /// 4 Wheels /// 
    public float rotationSpeed = 100f;   ///// Rotation Speed //////

    void Start(){
          run = FindObjectOfType<birdviewcamera>();     
    }
    void Update()
    {
      if (run != null && run.startcars){
    transform.Translate(Vector3.forward * speed * Time.deltaTime);    
      }
      wheelrotation();
    }

    void OnTriggerEnter(Collider other){
      Debug.Log("Debug.Log");
    }
    public void wheelrotation(){

        foreach(Transform t in visualWheels){
            t.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
    }
  }  
   


    

  