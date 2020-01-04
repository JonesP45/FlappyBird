using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayManager : MonoBehaviour
{
    public static ButtonPlayManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (SceneManager.GetActiveScene().name.Equals("Scene1-Init") || SceneManager.GetActiveScene().name.Equals("Scene3-Game"))
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

    public void Hidden()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void Remove()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        Destroy(gameObject);
    }
}
