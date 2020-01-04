using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPausePlayManager : MonoBehaviour
{
    public static ButtonPausePlayManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Scene2-Menu"))
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene1-Init"))
        {
            Destroy(Instance.gameObject);
        }
    }

    public void Hidden()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
