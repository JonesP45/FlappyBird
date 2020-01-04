using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamManager : MonoBehaviour
{
    public static ParamManager Instance;

    private GameObject bird;
    public GameObject GreenBird;
    public GameObject BlueBird;
    public GameObject PurpleBird;

    public const string Easy = "Easy";
    public const string Normal = "Normal";
    public const string Hard = "Hard";
    public string difficulty;

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
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        bird = GreenBird;
        difficulty = Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGreenBird()
    {
        bird = GreenBird;
    }

    public void SetBlueBird()
    {
        bird = BlueBird;
    }

    public void SetPurpleBird()
    {
        bird = PurpleBird;
    }

    public GameObject getBird()
    {
        return bird;
    }

    public void SetEasy()
    {
        difficulty = Easy;
    }

    public void SetNormal()
    {
        difficulty = Normal;
    }

    public void SetHard()
    {
        difficulty = Hard;
    }
    public string getDifficulty()
    {
        return difficulty;
    }
}
