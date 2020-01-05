using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManagement : MonoBehaviour
{
    //singleton
    public static BackManagement Instance;

    void Awake()
    {
        //instancie le singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //pour ne pas le détruire quand on charge une scène
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the application run in Android
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (SceneManager.GetActiveScene().name.Contains("Init"))
                {
                    // Quit the application
                    Application.Quit();
                }
                else
                {
                    // Load the first scene
                    SceneManager.LoadScene("Scene1-Init");
                    GameObject.FindGameObjectWithTag("floor").GetComponent<FloorScroll>().enabled = true;
                }
            }
        }
    }
}
