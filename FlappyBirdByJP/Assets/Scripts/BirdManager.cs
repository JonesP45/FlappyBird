using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdManager : MonoBehaviour
{
    //singleton
    public static BirdManager Instance;

    //le bird
    public GameObject bird;

    void Awake()
    {
        //instancie le singleton
        if (Instance == null)
        {
            Instance = this;
            AddBird();
        }
        //detruit et met à jour le singleton
        else if (SceneManager.GetActiveScene().name.Equals("Scene2-Menu"))
        {
            Destroy(Instance.gameObject);
            Instance = this;
            AddBird();
        }
        //detruit le singleton
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
        //si le bird est en vie et qu'on est dans la scène 3
        if (!GameState.Instance.getIsDead() && SceneManager.GetActiveScene().name.Equals("Scene3-Game"))
        {
            bird.GetComponent<Rigidbody2D>().isKinematic = false;
            //si le jeu est en pause, on déactive le script qui permet au bird de sauter
            if (GameState.Instance.getIsPause())
            {
                bird.GetComponent<TouchAction>().enabled = false;
            }
            else
            {
                bird.GetComponent<TouchAction>().enabled = true;
            }

        }
        if (SceneManager.GetActiveScene().name.Equals("Scene1-Init"))
        {
            Destroy(Instance.gameObject);
        }
    }

    //onn ajoute le bon bird (green, blue or purple)
    void AddBird()
    {
        bird = Instantiate(ParamManager.Instance.getBird());
        bird.SetActive(true);
        bird.transform.parent = transform;
    }
}
