using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsNewBest : MonoBehaviour
{
    public Sprite newBest;
    // Start is called before the first frame update
    void Start()
    {
        if (GameState.Instance.getNewBest())
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newBest;
        }
        else
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
