using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdManager : MonoBehaviour
{
    public static BirdManager Instance;

    public GameObject bird;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            AddBird();
        }
        else if (SceneManager.GetActiveScene().name.Equals("Scene2-Menu"))
        {
            Destroy(Instance.gameObject);
            Instance = this;
            AddBird();
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
        if (!GameState.Instance.getIsDead() && SceneManager.GetActiveScene().name.Equals("Scene3-Game"))
        {
            bird.GetComponent<Rigidbody2D>().isKinematic = false;
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

    void AddBird()
    {
        bird = Instantiate(ParamManager.Instance.getBird());
        //bird.active = true;
        bird.SetActive(true);
        bird.transform.parent = transform;
    }

    public void SetTouchScript(bool b)
    {
        bird.GetComponent<TouchAction>().enabled = b;
    }
}
