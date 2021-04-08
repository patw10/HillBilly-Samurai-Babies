using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour
{
    private bool timerReached = true;
    private float timer = 0;

    void Update()
    {
        timerReached = false;
        timer += Time.deltaTime;
        if (!timerReached && timer > 0.75)
        {
            timer = 0;
            timerReached = true;
            Destroy(gameObject);
        }
    }
}
