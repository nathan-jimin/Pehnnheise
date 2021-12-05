using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{

    private Vector2 screenBoundaries;
    // Start is called before the first frame update
    void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBoundaries.x*-1, screenBoundaries.x);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBoundaries.y*-1, screenBoundaries.y);
        transform.position = viewPos;
    }
}
