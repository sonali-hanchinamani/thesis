using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;


namespace client
{

    public class colorchange : MonoBehaviour
    {
        public RawImage red;
        public Texture m_Texture;
        public AudioSource audiosource;
        public float timer = 0f;
        private bool timerRunning = false;
        private birdviewclient birdview;
        public void start()
        {
            red = GetComponent<RawImage>();
            birdview = FindObjectOfType<birdviewclient>();
        }
        void OnTriggerEnter(Collider c)
        {
            if (c.CompareTag("TrafficCar"))
            {
                Debug.Log(c.gameObject.name);
                red.texture = m_Texture;
                audiosource.Play();
                timer = 0;
                timerRunning = true;
            }
        }
        private void Update()
        {
            //if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1"))
            //    {
            //        Debug.Log("PrESS");
            //    }
            if (timerRunning)
            {
                timer += Time.deltaTime;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1"))
            {
                if (timerRunning)
                {
                    // Stop the timer
                    timerRunning = false;

                    // Save the time to a JSON file
                    SaveTimeToJson(timer);
                    birdview.isRunning = false;
                }
            }
        }
        void SaveTimeToJson(float time)
        {
            string directoryPath = Path.Combine("C:\\Users\\User\\Sonali\\demo_car_client\\Assets\\Timedata");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
            string filePath = Path.Combine(directoryPath, $"timeData_{timestamp}.json");

            TimeData timeData = new TimeData { time = time, scenario = "slowtrucknotovertaken" };
            string json = JsonUtility.ToJson(timeData, true);
            File.WriteAllText(filePath, json);
            Debug.Log($"Time saved to {filePath}: {json}");
        }
    }

    [System.Serializable]
    public class TimeData
    {
        public float time;
        public string scenario;
    }

}

