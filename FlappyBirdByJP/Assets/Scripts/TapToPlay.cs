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
        if (Input.touchCount > 0) // gestion du lancement de la scene 3 avec phone
        {
            Touch theTouch = Input.GetTouch(0);

            //si le doight touche l'écran, on la scene 3
            if (theTouch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene("Scene3-Game");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) // gestion du lancement de la scene 3 avec ordi
        {
            SceneManager.LoadScene("Scene3-Game");
        }
    }
}
