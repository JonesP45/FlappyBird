using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundManager : MonoBehaviour
{
    //singleton
    public static BackGroundManager Instance;

    public GameObject quad;

    public Material bkDay;
    public Material bkNight;

    void Awake()
    {
        //instancie le singleton
        if (Instance == null)
        {
            Instance = this;
        }
        //detruit et met à jour le singleton
        else if (SceneManager.GetActiveScene().name.Equals("Scene2-Menu"))
        {
            Destroy(Instance.gameObject);
            Instance = this;
        }
        //detruit le singleton
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        //choisi un background aléatoirement 
        int alea = Random.Range(0, 2);
        if (alea == 0)
        {
            StartBackGroundDay();
        }
        else
        {
            StartBackGroundNight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene1-Init"))
        {
            Destroy(Instance.gameObject);
        }
    }

    //intancie le background "jour"
    void StartBackGroundDay()
    {
        quad.GetComponent<Renderer>().material = bkDay;
    }

    //intancie le background "nuit"
    void StartBackGroundNight()
    {
        quad.GetComponent<Renderer>().material = bkNight;
    }
}
