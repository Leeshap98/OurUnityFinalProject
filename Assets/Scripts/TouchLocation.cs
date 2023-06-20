using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation 
{
    public int touchId;
    public GameObject Ball;

    public TouchLocation(int newTouchId, GameObject newBall)
    {
        touchId = newTouchId;
        Ball = newBall;
    }
}
