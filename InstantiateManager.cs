using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    // PLAYING SCREEN
    
    public GameObject _comingCube;
    public GameObject _levelUpCubes;

    private Vector3 scaleChange;

    static BlockManager NumberOfActiveList = new BlockManager();
    
    private float pieceLength = 2 / 16 * NumberOfActiveList.NumberOfListElements; /* Cube width and height is 2 * NumberOfListElements */
    
    
    public float PieceLength
    {
        get { return pieceLength; }
        set { pieceLength = value; }
    }
    
    private void Awake()
    {
        scaleChange = new Vector3(-pieceLength, 0, -pieceLength);
    }

    public void CreatingCube()
    {
        Instantiate(_comingCube, MoveManager.pressCount % 2 == 1 ? new Vector3(-3.5f, 0, 0) : new Vector3(0, 0, 3.5f), Quaternion.identity);
    }

    public void CreatingLevelTrigger()
    {
        Instantiate(_levelUpCubes, new Vector3(0,0,0), Quaternion.identity);
    }
}
