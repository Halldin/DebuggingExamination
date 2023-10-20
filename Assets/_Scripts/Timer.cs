using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float roundLength;
    [SerializeField] TextMeshProUGUI timerText;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(Time.time < startTime + roundLength){

            //Calculate the remaining time by comparing the time at the start of the round to the current time.
            float t = 1 - Mathf.InverseLerp(startTime, startTime + roundLength, Time.time);
            int remainingTime = Mathf.FloorToInt(t * roundLength);

            timerText.text = remainingTime.ToString();
        }else{

            //If time runs out, reload the scene.
            if(FindObjectOfType<WinstreakManager>() != null){
                FindObjectOfType<WinstreakManager>().Win();
                enabled = false;
            }else{
                print("Scene Loader not detected! Play from Main Menu.");
            }
        }
    }
}
