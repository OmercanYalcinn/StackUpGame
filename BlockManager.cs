using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class BlockManager : MonoBehaviour
{
    public GameObject targetParent;
    
    private string nameTagCube = "Cube";
    private string nameTagofQuadrangular = "Quadrangular";
    
    public List<GameObject> activeTargets;
    public List<GameObject> allTargets;

    private int numberOfListElements;

    public int NumberOfListElements
    {
        get { return numberOfListElements; }
        set { numberOfListElements = value; }
    }

    private void Start()
    {
        if (targetParent == null) return;
        for (var i = 0; i < targetParent.transform.childCount; i++)
        {
            allTargets.Add(targetParent.transform.GetChild(i).gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == nameTagofQuadrangular)
            TriggeringBlocks(other);
    }

    private void OnTriggerExit(Collider other)
    {
        UnTriggeringBlocks(other);
    }

    private void UnTriggeringBlocks(Collider other)
    {
        activeTargets.Remove(other.gameObject);
        allTargets.Add(other.gameObject);
    }

    private void TriggeringBlocks(Collider other)
    {
        allTargets.Remove(other.gameObject);
        activeTargets.Add(other.gameObject);
    }
    
    public void CarryAndFallOnX()
    {
        for (var index = 0; index < allTargets.Count; index++)
        {
            var piecesCubes = allTargets[index];
            // check the list - Is it empty?
            if (piecesCubes == null)
                return; // Perfect Condition for Player

            var targetCubeTransform = piecesCubes.transform;
            
            Debug.Log("You have just carried the pieces");
            targetCubeTransform.position = 
                new Vector3(transform.position.x > 0 ? targetCubeTransform.position.x + 2 : targetCubeTransform.position.x - 2, targetCubeTransform.position.y, targetCubeTransform.position.z);

            // after cary them, enable them
            piecesCubes.GetComponent<MeshRenderer>().enabled = true;

            // then change the color to red - "color meshRenderer üzerine gelir o yüzden onu çağırarak renk değişimi yapmak gerekir!!" -
            piecesCubes.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.1f);
            Debug.Log("Color has changed to RED");

            // falling piece by piece
            targetCubeTransform.DOMove(new Vector3(piecesCubes.transform.position.x, -3, 0), allTargets.Count - index).SetEase(Ease.InCubic);

            // destroy the cube pieces after 5 seconds which is the probably perfect time for destroying 
            Destroy(piecesCubes, allTargets.Count + 5f);
        }
    }
    
    public void CarryAndFallOnZ()
    {
        for (var i = 0; i < activeTargets.Count; i++)
        {

            var pieceCubes = activeTargets[i];
                
            if (pieceCubes == null) return; // Worst Condition for Player which is GAMEOVER??
            var activeCubesTransform = pieceCubes.transform;
                    
            // Decide the carry position and carry them with 90 degree rotation
            activeCubesTransform.position = 
                new Vector3(activeCubesTransform.position.x, activeCubesTransform.position.y, transform.position.z > 0 ? activeCubesTransform.position.z + 2 : activeCubesTransform.position.z - 2); 
            //.rotation 90 degree - Rotasyonla uğraşma, onun yerine hazır üret, Instantiate et onu da, ismini de TriggerDetecter olsun, X e ve Y ye uygun Instantiate et bir yerlerde --

            // after we carry the object, we can enable the piece cubes
            activeTargets[i].GetComponent<MeshRenderer>().enabled = true;
            
            // then change the color to red - "color meshRenderer üzerine gelir o yüzden onu çağırarak renk değişimi yapmak gerekir!!" -
            pieceCubes.GetComponent<MeshRenderer>().material.DOColor(Color.blue, 0.1f);

            // falling piece by piece
            // There should be a for loop to gezmek all list and while we gezmek with i index, add this index into time into DOTween code line and call it under the CarryAndFall methods
            activeCubesTransform.DOMove(new Vector3(0, -3, pieceCubes.transform.position.z), activeTargets.Count - i).SetEase(Ease.InCubic);

            // destroy the cube pieces after 5 seconds which is the probably perfect time for destroying 
            Destroy(pieceCubes, activeTargets.Count + 5f);
        }
    }
    
}
