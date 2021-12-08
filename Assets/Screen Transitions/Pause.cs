using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool _paused = false;

    public void pauseGame()
    {
        if(_paused)
        {
            Time.timeScale = 1;
            _paused = false;
        }
        else
        {
            Time.timeScale = 0;
            _paused = true;
            //SceneManager.LoadScene(5);
        }
    }
}
