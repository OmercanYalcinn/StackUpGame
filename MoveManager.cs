using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class MoveManager : MonoBehaviour
{
    public GameObject comingCube;
    
    [SerializeField] public static int pressCount = 1;
    [SerializeField] public static float duration = 1.6f;

    private void Awake()
    {
        StartMovingAndDecide();
    }

    private void StartMovingAndDecide()
    {
        if (pressCount % 2 == 1)
            AutoMovingOnX();
        
        else
            AutoMovingOnZ();
    }

    private void Update()
    {
        RunAndStopControl();
    }

    public void RunAndStopControl()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pressCount % 2 == 1 /*ODD - X Axis*/)
            {
                StopOnX();
                GetComponent<BlockManager>().CarryAndFallOnX();
                ComingCubeDisabled();
                gameManager.Instance.NewPieceLength.GetComponent<InstantiateManager>().CreatingCube();
                gameManager.Instance.NewPieceLength.GetComponent<InstantiateManager>().CreatingLevelTrigger();
            }
            else   /*EVEN - Z Axis*/
            {
                StopOnZ();
                GetComponent<BlockManager>().CarryAndFallOnZ();
                ComingCubeDisabled();
                gameManager.Instance.NewPieceLength.GetComponent<InstantiateManager>().CreatingCube();
                gameManager.Instance.NewPieceLength.GetComponent<InstantiateManager>().CreatingLevelTrigger();
            }
        }
    }

    private void AutoMovingOnX()
    {
        transform.DOMoveX(3.5f, duration).SetId(001).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
    
    private void AutoMovingOnZ()
    {
        transform.DOMoveZ(-3.5f, duration).SetId(002).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void StopOnX()
    {
        DOTween.Pause(001);
        pressCount++;
    }

    private void StopOnZ()
    {
        DOTween.Pause(002);
        pressCount++;
    }
    
    void ComingCubeDisabled()
    {
        comingCube.GetComponent<MeshRenderer>().enabled = false;
    }

}
