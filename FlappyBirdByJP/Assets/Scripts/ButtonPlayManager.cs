using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlayManager : MonoBehaviour
{
    //singleton
    public static ButtonPlayManager Instance;

    void Awake()
    {
        //instancie le singleton
        if (Instance == null)
        {
            Instance = this;
        }
        //detruit et met à jour le singleton
        else if (SceneManager.GetActiveScene().name.Equals("Scene1-Init") || SceneManager.GetActiveScene().name.Equals("Scene3-Game"))
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        //detruit le singleton
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //cache le bouton pour qu'il n'apparaisse pas sur la scène suivante car le son joué lors du click su bouton est plus long que le chargement de la scène suivante
    public void Hidden()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    //détuit le bouton quand le son a fini
    public void Remove()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        Destroy(gameObject);
    }
}
