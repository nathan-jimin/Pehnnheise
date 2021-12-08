using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool _paused = false;

    public SpriteRenderer img;

    public void pauseGame()
    {
        if(_paused)
        {
            Time.timeScale = 1;
            _paused = false;
            img.color = new Color (1, 1, 1, 0);
        }
        else
        {
            Time.timeScale = 0;
            _paused = true;
            //SceneManager.LoadScene(5);
            img.color = new Color (1, 1, 1, 255);
        }
    }
}
