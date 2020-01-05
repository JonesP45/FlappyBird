using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManagement : MonoBehaviour
{
    public static BackManagement Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    SceneManager.LoadScene("Scene1-Init");
                    GameObject.FindGameObjectWithTag("floor").GetComponent<FloorScroll>().enabled = true;
                }
            }
        }
    }
}
