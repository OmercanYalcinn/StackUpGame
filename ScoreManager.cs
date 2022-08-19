using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int score = 0;

    private void ScoreCount()
    {
        if (MoveManager.pressCount % 2 == 1)    //Increasing according to Movement on X axis
            score++;
        else                                    //Increasing according to Movement on Z axis
            score++;
        
        Debug.Log("Score: " + score);
    }
    
}
