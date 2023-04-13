using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StartingPostion;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    void Start()
    {
        StartingPostion= transform.position;
    }

    
    void Update()
    { 
        //if(period == 0 ) { return; }
        if (period <= Mathf.Epsilon ) { return; }   /* this also can be used for not getting the nan error because if we add
                                                     float to 0 this causes to make the float of other values to run along with them so we can use 
                                                       mathf.epsilon */ 
        float cycles = Time.time/ period;  // continually growing over time

        const float tau = Mathf.PI * 2;    // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles*tau);  // going from -1 to 1

        //Debug.Log(rawSinWave);
        movementFactor = (rawSinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner

        Vector3 Offset = movementVector * movementFactor;
        transform.position = StartingPostion + Offset;
     }
}
