using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamManager : MonoBehaviour
{
    //singleton
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
        //on instancie le singleton
        if (Instance == null)
        {
            Instance = this;
        }
        //on le detruit
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //le bird et la difficulté de base
        bird = GreenBird;
        difficulty = Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //getters et setters
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
