using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundManager : MonoBehaviour
{
    public static BackGroundManager Instance;

    public GameObject quad;

    public Material bkDay;
    public Material bkNight;

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
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBackgrounds();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("Scene1-Init"))
        {
            Destroy(Instance.gameObject);
        }
    }

    void SetBackgrounds()
    {
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

    void StartBackGroundDay()
    {
        quad.GetComponent<Renderer>().material = bkDay;
    }

    void StartBackGroundNight()
    {
        quad.GetComponent<Renderer>().material = bkNight;
    }
}
