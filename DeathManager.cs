using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    private BlockManager NewNumberOfList = new BlockManager();
    
    void UnderstandTheDeath()
    {
        switch (NewNumberOfList.NumberOfListElements)
        {
            case > 0:
                GetComponent<InstantiateManager>();
                break;
            case 0:
                GetComponent<UImanager>().RePlayButton();
                break;
        }
    }
    
}
