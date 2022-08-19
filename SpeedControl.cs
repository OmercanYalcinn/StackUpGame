using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    private float durationChange = 0.2f;

    private void DecideVelocity()
    {
        if (MoveManager.pressCount > 10)
        {
            MoveManager.duration = MoveManager.duration - durationChange;
        }
    }
}
