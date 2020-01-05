using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPausePlayManager : MonoBehaviour
{
    //singleton
    public static ButtonPausePlayManager Instance;

    void Awake()
    {
        //instancie le singleton 
        if (Instance == null)
        {
            Instance = this;
        }
        //detruit le singleton
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //detruit le singleton quand le bird est mort
    public void Delete()
    {
        Destroy(gameObject);
    }
}
