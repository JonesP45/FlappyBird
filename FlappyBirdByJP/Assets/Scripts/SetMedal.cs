using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMedal : MonoBehaviour
{
    public Sprite bronze;
    public Sprite argent;
    public Sprite or;
    public Sprite platine;

    // Start is called before the first frame update
    void Start()
    {
        int score = GameState.Instance.getScorePlayer();
        if (score >= 40)
            gameObject.GetComponent<SpriteRenderer>().sprite = platine;
        else if (score >= 30)
            gameObject.GetComponent<SpriteRenderer>().sprite = or;
        else if (score >= 20)
            gameObject.GetComponent<SpriteRenderer>().sprite = argent;
        else if (score >= 10)
            gameObject.GetComponent<SpriteRenderer>().sprite = bronze;
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
