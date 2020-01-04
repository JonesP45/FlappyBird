using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("Scene3-Game");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scene3-Game");
        }
    }
}
