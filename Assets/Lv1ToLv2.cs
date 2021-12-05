using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lv1ToLv2 : MonoBehaviour
{
    private static int score;
    void Update()
    {
        score = PlayerCollectCoin.scoreValue;
        if(score == 4)
        {
            SceneManager.LoadScene(2);
        }
    }
}
