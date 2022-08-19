using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    void StartButton()
    {
        if (Input.GetButtonDown("StartButton"))
            SceneManager.LoadScene("PlayingScene");
    }
    
    // Display Replay Button if we dead - controlling ActiveList.Count -
    public void RePlayButton()
    {
        if (Input.GetButtonDown("RestartButton"))
            SceneManager.LoadScene("RePlayScene");
    }
    
}
