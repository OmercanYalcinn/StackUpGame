using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance { get; private set; }

    private bool thereIsMovement = false;

    [SerializeField]public InstantiateManager NewPieceLength;
    [SerializeField]private BlockManager NewNumberOfList;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

    void MoveManagerRun()
    {
        if (MoveManager.pressCount > 0 || NewPieceLength.PieceLength > 0) // Which means there is movement - pressCount and Death Condition
            thereIsMovement = true;
        
        if (thereIsMovement == true)
            GetComponent<MoveManager>().RunAndStopControl();
        
    }

    void DecideAndRunBlockNo()
    {
        if (NewNumberOfList.NumberOfListElements == 0)
            GetComponent<DeathManager>();
        if (NewNumberOfList.NumberOfListElements> 0)
            GetComponent<InstantiateManager>().CreatingCube();
    }
}
